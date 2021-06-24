using UnityEngine;

namespace TirUtilities.UI
{
    ///<!--
    /// MenuPage.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Created:  June 03, 2021
    /// Updated:  June 03, 2021
    /// -->
    /// <summary>
    /// Represents a UI canvas to the <see cref="MenuStateMachine"/>.
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("TirUtilities/UI/Menu Page")]
    public class MenuPage : MonoBehaviour
    {
        #region Inspector Fields

        [Header("State Data")]
        [Tooltip("That page's state scriptable object.  MUST be set in the inspector.")]
        [SerializeField] private MenuState _state;

        [Header("UI References")]
        [Tooltip("The child panel that holds the visual elements.")]
        [SerializeField] private GameObject _menuPanel;

        #endregion

        #region Public Methods

        /// <summary> Activate the menu panel. </summary>
        [ContextMenu(nameof(ShowPanel))]
        public void ShowPanel() => _menuPanel.SetActive(true);

        /// <summary> Deactivate the menu panel. </summary>
        [ContextMenu(nameof(HidePanel))]
        public void HidePanel() => _menuPanel.SetActive(false);

        #endregion

        #region Public Properties

        /// <summary> This page's <see cref="MenuState"/>. </summary>
        public MenuState State => _state;

        #endregion
    }
}