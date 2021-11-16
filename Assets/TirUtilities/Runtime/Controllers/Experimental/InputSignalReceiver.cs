using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace TirUtilities.Controllers.Experimental
{
    using TirUtilities.Signals;
    ///<!--
    /// InputSignals.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  BlackPheonixSoftware
    /// Created:  Sep 26, 2021
    /// Updated:  Oct 13, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public class InputSignalReceiver : MonoBehaviour
    {
        #region Inspector Fields

        [Header("Debug")]
        [SerializeField] private bool _verboseLogging = false;

        [Header("Player Input Values")]
        [SerializeField, DisplayOnly] private Vector2 _move;
        [SerializeField, DisplayOnly] private Vector2 _look;
        [SerializeField, DisplayOnly] private bool _isJumping;
        [SerializeField, DisplayOnly] private bool _isSprinting;

        //[Header("Movement Settings")]
        //[SerializeField] private bool _analogMovement;

        #endregion

        #region Events & Signals

        [Header("Signals")]
        [SerializeField] private Vector2Signal _moveSignal;
        [SerializeField] private Vector2Signal _lookSignal;
        [SerializeField] private BoolSignal _jumpSignal;
        [SerializeField] private BoolSignal _sprintSignal;

        #endregion

        #region Input Messages

#if ENABLE_INPUT_SYSTEM
        public void OnMove(InputValue value) => MoveInput(value.Get<Vector2>());
        public void OnLook(InputValue value) => LookInput(value.Get<Vector2>());
        public void OnJump(InputValue value) => JumpInput(value.isPressed);
        public void OnSprint(InputValue value) => SprintInput(value.isPressed); 
#endif

        #endregion

        #region Input Methods

        public void MoveInput(Vector2 moveDirection)
        {
            _move = moveDirection;
            _moveSignal.Emit(moveDirection);

            if (_verboseLogging) Debug.Log($"Move Input => {moveDirection}");
        }

        public void LookInput(Vector2 lookDirection)
        {
            _look = lookDirection;
            _lookSignal.Emit(lookDirection);

            if (_verboseLogging) Debug.Log($"Look Input => {lookDirection}");
        }

        public void JumpInput(bool jumpState)
        {
            _isJumping = jumpState;
            _jumpSignal.Emit(jumpState);

            if (_verboseLogging) Debug.Log($"Jump Input => {jumpState}");
        }

        public void SprintInput(bool sprintState)
        {
            _isSprinting = sprintState;
            _sprintSignal.Emit(sprintState);

            if (_verboseLogging) Debug.Log($"Sprint Input => {sprintState}");
        }

        #endregion

        #region Cursor Lock
#if !UNITY_IOS || !UNITY_ANDROID
        private void OnApplicationFocus(bool hasFocus) => SetCursorLockState(hasFocus);

        private void SetCursorLockState(bool hasFocus)
        {
            Cursor.lockState = hasFocus ? CursorLockMode.Locked : CursorLockMode.None;
        }
#endif
        #endregion
    }
}
