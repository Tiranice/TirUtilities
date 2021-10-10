using TirUtilities.Signals;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace TirUtilities.Controllers.Experimental
{
    ///<!--
    /// BoxSelect.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Oct 01, 2021
    /// Updated:  Oct 01, 2021
    /// -->
    /// <summary>
    ///
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