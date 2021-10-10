#if ENABLE_CINEMACHINE
using Cinemachine;
#endif
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace TirUtilities.Controllers.Experimental
{
    using TirUtilities.Extensions;
    using TirUtilities.Signals;
    ///<!--
    /// PlayerController.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  BlackPheonixSoftware
    /// Created:  Sep 26, 2021
    /// Updated:  Oct 01, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    [DisallowMultipleComponent, RequireComponent(typeof(CharacterController))]
#if ENABLE_INPUT_SYSTEM
    [RequireComponent(typeof(PlayerInput)), RequireComponent(typeof(InputSignalReceiver))] 
#endif
    public class PlayerController : MonoBehaviour
    {
        #region Constants

        private const float _LookThreshold = 0.01f;

        #endregion

        #region Data Structures

        [System.Serializable]
        private enum ControllerType { FirstPerson, ThirdPerson, }

        #endregion

        #region Inspector Fields

        [Header("Controls")]
        [SerializeField] private ControllerType _controllerType = ControllerType.FirstPerson;
        [Space]
        [SerializeField] private CharacterController _controller;
        [SerializeField] private bool _isStrafing;

        [Header("Speed")]
        [Tooltip("Move speed of the character in m/s")]
        [SerializeField] private float _walkSpeed = 2.0f;
        [Tooltip("Sprint speed of the character in m/s")]
        [SerializeField] private float _sprintSpeed = 5.335f;
        [SerializeField] private float _acceleration = 10.0f;
        [Tooltip("How fast the character turns to face movement direction"), Range(0.0f, 0.3f)]
        [SerializeField] private float _angularAcceleration = 0.12f;
        [Space]
        [SerializeField] private float _lookSpeed = 1.0f;

        [Header("Camera")]
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private CinemachineVirtualCamera _mainVCam;
        [SerializeField] private CinemachineVirtualCamera _sprintVCam;
        [Space]
        [Tooltip("How far in degrees can you move the camera up")]
        [SerializeField] private float _topClamp = 70.0f;
        [Tooltip("How far in degrees can you move the camera down")]
        [SerializeField] private float _bottomClamp = -30.0f;
        [Tooltip("Additional degrees to override the camera. Useful for fine tuning camera position when locked")]
        [SerializeField] private float _cameraAngleOverride = 0.0f;

        [Header("Cinemachine")]
        [Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
        [SerializeField] private GameObject _cinemachineCameraTarget;

        [Header("Animator")]
        [SerializeField] private Animator _animator;

        #endregion

        #region Animator

        private bool _hasAnimator = false;
        private float _animationBlend;

        // Animation IDs
        private int _animationSpeed;
        private int _animationMotionSpeed;

        #endregion

        #region Inputs

        private Vector2 _move;
        private Vector2 _look;
        private bool _isJumping;
        private bool _isSprinting;

        #endregion

        #region Cinemachine

        private float _cinemachineTargetYaw;
        private float _cinemachineTargetPitch;

        #endregion

        #region Movement

        [Header("Movement Debug")]
        [SerializeField, DisplayOnly] private float _speed;
        [SerializeField, DisplayOnly] private float _targetRotation;
        [SerializeField, DisplayOnly] private float _rotationSpeed;
        [SerializeField, DisplayOnly] private float _verticalSpeed;

        #endregion

        #region Events & Signals

        [Header("Signals")]
        [SerializeField] private Vector2Signal _moveSignal;
        [SerializeField] private Vector2Signal _lookSignal;
        [SerializeField] private BoolSignal _jumpSignal;
        [SerializeField] private BoolSignal _sprintSignal;

        #endregion

        #region Unity Messages

        private void Awake()
        {
            if (_mainCamera.IsNull()) _mainCamera = Camera.main;
            AssignReceivers();
            AssignAnimationIDs();
        }

        private void Start() => GetComponentReferences();

        private void Update() => Move();

        private void LateUpdate()
        {
            if (_controllerType == ControllerType.FirstPerson)
                CameraPOVRotation();
            else
                CameraRotation();
        }

        private void OnDestroy() => RemoveReceivers();

        #endregion

        #region Setup & Teardown

        private void GetComponentReferences()
        {
            _hasAnimator = TryGetComponent(out _animator);
            _controller = GetComponent<CharacterController>();
        }

        private void AssignReceivers()
        {
            if (_moveSignal.NotNull())
                _moveSignal.AddReceiver(MoveReceiver);

            if (_lookSignal.NotNull())
            _lookSignal.AddReceiver(LookReceiver);

            if (_jumpSignal.NotNull())
            _jumpSignal.AddReceiver(JumpReceiver);

            if (_sprintSignal.NotNull())
            _sprintSignal.AddReceiver(SprintReceiver);
        }

        private void RemoveReceivers()
        {
            if (_moveSignal.NotNull())
                _moveSignal.RemoveReceiver(MoveReceiver);

            if (_lookSignal.NotNull())
                _lookSignal.RemoveReceiver(LookReceiver);

            if (_jumpSignal.NotNull())
                _jumpSignal.RemoveReceiver(JumpReceiver);

            if (_sprintSignal.NotNull())
                _sprintSignal.RemoveReceiver(SprintReceiver);
        }

        private void AssignAnimationIDs()
        {
            _animationSpeed = Animator.StringToHash("Speed");
            _animationMotionSpeed = Animator.StringToHash("MotionSpeed");
        }

        #endregion

        #region Signal Receivers

        private void MoveReceiver(Vector2 value) => _move = value;
        private void LookReceiver(Vector2 value) => _look = value;
        private void JumpReceiver(bool value) => _isJumping = value;
        private void SprintReceiver(bool value) => _isSprinting = value;

        #endregion

        #region Movement Methods

        private void Move()
        {
            SetSpeed();
            if (_controllerType == ControllerType.ThirdPerson)
                SetMoveDirection3rdPerson();
            else
                SetMoveDirection1stPerson();

            SetCameraPriority();

            SetAnimationSpeed();
        }


        private void SetSpeed()
        {
            float targetSpeed = _isSprinting ? _sprintSpeed : _walkSpeed;

            // Lock backwards speed to 75% of walk speed.
            if (_move.y < 0) targetSpeed = _walkSpeed * 0.75f;

            // No input
            if (_move == Vector2.zero) targetSpeed = 0.0f;

            float currentHorizontalSpeed = new Vector3(
                _controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;

            float speedOffset = 0.1f;

            if (currentHorizontalSpeed < targetSpeed - speedOffset
                || currentHorizontalSpeed > targetSpeed + speedOffset)
            {
                _speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed, Time.deltaTime * _acceleration);

                _speed = Mathf.Round(_speed * 1e3f) * 1e-3f;
            }
            else _speed = targetSpeed;

            _animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime * _acceleration);
        }

        private void SetMoveDirection3rdPerson()
        {
            var inputDirection = new Vector3(_move.x, 0.0f, _move.y).normalized;

            float moveDirection = 0.0f;
            if (_move != Vector2.zero)
            {
                moveDirection = Mathf.Atan2(inputDirection.x, inputDirection.z)
                               * Mathf.Rad2Deg + _mainCamera.transform.eulerAngles.y;

                _targetRotation = _isStrafing ? _mainCamera.transform.rotation.eulerAngles.y 
                                              : moveDirection;

                float playerRotation = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                                                       _targetRotation,
                                                       ref _rotationSpeed,
                                                       _angularAcceleration);

                transform.rotation = Quaternion.Euler(0.0f, playerRotation, 0.0f);
            }

            var targetDirection = Quaternion.Euler(0.0f, moveDirection, 0.0f) * Vector3.forward;

            _verticalSpeed = _controller.isGrounded ? 0.0f : -9.81f;

            var movementVector = targetDirection.normalized
                                 * (_speed * Time.deltaTime)
                                 + (new Vector3(0.0f, _verticalSpeed, 0.0f) * Time.deltaTime);

            _controller.Move(movementVector);
        }

        private void SetMoveDirection1stPerson()
        {
            var inputDirection = new Vector3(_move.x, 0.0f, _move.y).normalized;

            if (_move != Vector2.zero)
                inputDirection = transform.right * _move.x + transform.forward * _move.y;

            _verticalSpeed = _controller.isGrounded ? 0.0f : -9.81f;

            var movementVector = inputDirection.normalized
                                 * (_speed * Time.deltaTime)
                                 + (new Vector3(0.0f, _verticalSpeed, 0.0f) * Time.deltaTime);

            _controller.Move(movementVector);
        }

        private void SetCameraPriority()
        {
            _mainVCam.Priority = _isSprinting ? 0 : 10;
        }

        private void SetAnimationSpeed()
        {
            if (_hasAnimator)
            {
                _animator.SetFloat(_animationSpeed, _animationBlend);
                _animator.SetFloat(_animationMotionSpeed, 1.0f);
            }
        }

        #endregion

        #region Camera Look Methods

        private void CameraRotation()
        {
            if (_look.sqrMagnitude >= _LookThreshold)
            {
                _cinemachineTargetYaw += _look.x * _lookSpeed * Time.deltaTime;
                _cinemachineTargetPitch += _look.y * _lookSpeed * Time.deltaTime;
            }

            _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
            _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, _bottomClamp, _topClamp);

            var lookRotation = Quaternion.Euler(_cinemachineTargetPitch + _cameraAngleOverride, _cinemachineTargetYaw, 0.0f);

            _cinemachineCameraTarget.transform.rotation = lookRotation;
        }

        private void CameraPOVRotation()
        {
            if (_look.sqrMagnitude < _LookThreshold) return;

            _cinemachineTargetYaw = _look.x * _lookSpeed * Time.deltaTime;
            _cinemachineTargetPitch += _look.y * _lookSpeed * Time.deltaTime;

            _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, _bottomClamp, _topClamp);

            _cinemachineCameraTarget.transform.localRotation = Quaternion.Euler(_cinemachineTargetPitch, 0.0f, 0.0f);

            transform.Rotate(Vector3.up * _cinemachineTargetYaw);
        }

        #endregion

        #region Static Methods

        private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
        {
            if (lfAngle < -360f) lfAngle += 360f;
            if (lfAngle > 360f) lfAngle -= 360f;
            return Mathf.Clamp(lfAngle, lfMin, lfMax);
        }

        #endregion
    }
}