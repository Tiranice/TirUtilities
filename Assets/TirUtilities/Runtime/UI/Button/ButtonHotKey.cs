using UnityEngine;
using UnityEngine.UI;

namespace TirUtilities.UI.Buttons
{
    ///<!--
    /// ButtonHotKey.cs
    /// 
    /// Project   :  TirUtilities
    /// 
    /// Author    :  Devon Wilson
    /// Created on:  Feb. 22, 2021
    /// Updated on:  Feb. 22, 2021
    /// -->
    /// <summary>
    /// Invokes the OnClick event on a button.
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class ButtonHotKey : MonoBehaviour
    {
        #region Inspector Fields

        [SerializeField] private KeyCode _hotKey;
        [SerializeField] private Button _button;

        #endregion

        #region Unity Messages

        private void Awake() => TryGetComponent(out _button);

        private void Update()
        {
            if (ShouldInvokeOnClick) _button.onClick.Invoke();
        }

        #endregion

        #region Private Properties

        /// <summary>
        /// True is the hot-key has been pressed and the button is active.
        /// </summary>
        private bool ShouldInvokeOnClick => Input.GetKeyDown(_hotKey) && _button.IsActive();

        #endregion
    }
}