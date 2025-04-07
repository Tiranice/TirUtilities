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
    using TirUtilities.Extensions;

    ///<!--
    /// PlayerController.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Sep 28, 2021
    /// Updated:  Oct 13, 2021
    /// -->
    /// <summary>
    /// Unfinished.  Use at your own risk.
    /// </summary>
    public class PlayerControllerRigidbody : MonoBehaviour
    {
        #region Inspector Fields

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField, Range(1.0f, 25.0f)] private float _speed;

        [SerializeField, DisplayOnly] private Vector2 _movementVector = Vector2.zero;
        //[SerializeField, DisplayOnly] private bool _movePressed = false;

        #endregion

        #region Events & Signals

        //[Header("Signals")]
        //[SerializeField] private Vector2Signal _moveInputSignal;

        #endregion

        #region Unity Messages

        private void Awake()
        {
            if (_rigidbody.IsNull()) TryGetComponent(out _rigidbody);

            //_moveInputSignal.AddReceiver(MoveReceiver);
        }
#if ENABLE_INPUT_SYSTEM
        private void FixedUpdate() => Move();
#endif
        #endregion

        #region Input Messages
#if ENABLE_INPUT_SYSTEM
        public void OnMove(InputValue value) => MoveReceiver(value.Get<Vector2>());
#endif
        #endregion

        #region Private Methods

        private void MoveReceiver(Vector2 input) => _movementVector = input;

        private void Move()
        {
            var move = _movementVector.normalized.y * Camera.main.transform.forward;
            move.y = 0.0f;
            _rigidbody.AddForce(move * _speed);
        }

        #endregion
    }
}