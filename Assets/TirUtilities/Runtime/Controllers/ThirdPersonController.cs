using UnityEngine;
#if UNITY_INPUT_SYSTEM_1_0_2_OR_GREATER
using UnityEngine.InputSystem;
#endif

namespace TirUtilities.Controllers
{
    using TirUtilities.Extensions;
    ///<!--
    /// ThirdPersonController.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  April 22, 2021
    /// Updated:  April 22, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    [AddComponentMenu("TirUtilities/Controllers/Third Person Controller")]
    public class ThirdPersonController : MonoBehaviour
    {
        #region Inspector Fields

        [Header("Component References")]
        [Tooltip("The character controller that this component uses.")]
        [SerializeField] private CharacterController _controller;
        [Tooltip("The main camera.  Used to adjust movement direction.")]
        [SerializeField] private Camera _mainCamera;

        [Header("Settings")]
        [Tooltip("The speed of horizontal movement.")]
        [Range(0.0f, 64.0f)]
        [SerializeField] private float _speed = 5.0f;
        [Tooltip("Controls jump height.")]
        [Range(0.0f, 64.0f)]
        [SerializeField] private float _jumpPower = 3.0f;
        [Space]

        [Tooltip("When true, the forward of the controlled object will be set to the movement vector.")]
        [SerializeField] private bool _faceMoveDirection = true;
        [Space]

        [Tooltip("When true, the controlled object will fall when not grounded.")]
        [SerializeField] private bool _applyGravity;
        [Tooltip("Acceleration due to gravity.")]
        [SerializeField] private float _gravity = 9.81f;
        [Tooltip("Scales the effect of gravity.")]
        [SerializeField] private float _gravityScale = 2.0f;

        [Header("Debug")]
        [DisplayOnly]
        [SerializeField] private Vector2 _movementDirection;
        [DisplayOnly]
        [SerializeField] private Vector3 _verticalVelocity = new Vector3();

        #endregion

        #region Unity Messages

        private void Start() => Setup();

        private void FixedUpdate() => Move();

        #endregion

        #region Setup & Teardown

        private void Setup()
        {
            if (_mainCamera.IsNull()) _mainCamera = Camera.main;
            if (_controller.IsNull()) TryGetComponent(out _controller);
        }

        #endregion

        #region Private Methods

        private void Move()
        {
            if (ShouldStopFalling)
                _verticalVelocity.y = 0.0f;

            var movementVector = new Vector3(x: _movementDirection.x, 
                                             y: 0.0f,
                                             z: _movementDirection.y
                                             ).normalized;

            var releativeVector = _mainCamera.transform.rotation * movementVector;
            releativeVector.y = 0.0f;

            _controller.Move(releativeVector.normalized * Time.deltaTime * _speed);

            if (_faceMoveDirection && movementVector.NotZero())
                transform.forward = movementVector;

            if (_applyGravity) Fall();
        }

        private void Fall()
        {
            _verticalVelocity.y -= _gravity * _gravityScale * Time.deltaTime;
            _controller.Move(_verticalVelocity * Time.deltaTime);
        }

        #endregion

        #region Public Methods

#if UNITY_INPUT_SYSTEM_1_0_2_OR_GREATER
        public void SetMoveDirection(InputAction.CallbackContext context) => _movementDirection = context.ReadValue<Vector2>();

        public void Jump(InputAction.CallbackContext context)
        {
            if (context.performed && _controller.isGrounded)
                _verticalVelocity.y += Mathf.Sqrt(-_jumpPower * (-_gravity * _gravityScale));
        }
#else
        public void SetMoveDirection(Vector2 direction) => _movementDirection = direction;

        public void Jump()
        {
            if (_controller.isGrounded)
                _verticalVelocity.y += Mathf.Sqrt(-_jumpPower * (-_gravity * _gravityScale));
        }
#endif

        #endregion

        #region Bool Properties

        private bool ShouldStopFalling => _controller.isGrounded && _verticalVelocity.y < 0;

        #endregion
    }
}