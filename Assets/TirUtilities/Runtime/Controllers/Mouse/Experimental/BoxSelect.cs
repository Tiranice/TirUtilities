using TirUtilities.Signals;
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
    ///<!--
    /// BoxSelect.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Oct 01, 2021
    /// Updated:  Oct 01, 2021
    /// -->
    /// <summary>
    /// Unfinished.  Use at your own risk.
    /// </summary>
    public class BoxSelect : MonoBehaviour
    {
        #region Inspector Fields

#if ENABLE_INPUT_SYSTEM
        [SerializeField] private PlayerInput _playerInput;
#endif
        [SerializeField] private BoolSignal _selectBoxToggleSignal;
        [SerializeField] private Vector2Signal _mousePosSignal;

        #endregion

        #region Private Fields

        private bool _isSelecting;

        #endregion

        #region Input Action Listeners
#if ENABLE_INPUT_SYSTEM
        public void OnSelect(InputAction.CallbackContext context)
        {
            _isSelecting = context.performed;
            _selectBoxToggleSignal.Emit(_isSelecting);
        }

        public void OnBoxSelect(InputAction.CallbackContext context)
        {
            var mousePosition = context.ReadValue<Vector2>();
            _mousePosSignal.Emit(mousePosition);
        }
#endif
        #endregion
    }
}