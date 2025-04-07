using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

///<!--
///     Copyright (C) 2025  Devon Wilson
///
///     This program is free software: you can redistribute it and/or modify
///     it under the terms of the GNU Lesser General Public License as published
///     by the Free Software Foundation, either version 3 of the License, or
///     (at your option) any later version.
///
///     This program is distributed in the hope that it will be useful,
///     but WITHOUT ANY WARRANTY; without even the implied warranty of
///     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
///     GNU Lesser General Public License for more details.
///
///     You should have received a copy of the GNU General Public License
///     along with this program.  If not, see <https://www.gnu.org/licenses/>.
///-->

namespace TirUtilities.Controllers.Experimental
{
    using TirUtilities.Signals;
    ///<!--
    /// InputSignals.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Pheonix Creative
    /// Created:  Sep 26, 2021
    /// Updated:  Oct 13, 2021
    /// -->
    /// <summary>
    /// Unfinished.  Use at your own risk.
    /// </summary>
    public class InputSignalReceiver : MonoBehaviour
    {
        #region Inspector Fields

        [Header("Debug")]
        [SerializeField] private bool _verboseLogging = false;

        [Header("Player Input Values")]
#pragma warning disable IDE0052 // Remove unread private members
        [SerializeField, DisplayOnly] private Vector2 _move;
        [SerializeField, DisplayOnly] private Vector2 _look;
        [SerializeField, DisplayOnly] private bool _isJumping;
        [SerializeField, DisplayOnly] private bool _isSprinting;
#pragma warning restore IDE0052 // Remove unread private members

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
