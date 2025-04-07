using UnityEngine;

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

namespace TirUtilities.UI
{
    ///<!--
    /// MenuPage.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
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
        [Header("State Data")]
        [Tooltip("That page's state scriptable object.  MUST be set in the inspector.")]
        [SerializeField] private MenuState _state;

        [Header("UI References")]
        [Tooltip("The child panel that holds the visual elements.")]
        [SerializeField] private GameObject _menuPanel;

        /// <summary> Activate the menu panel. </summary>
        [ContextMenu(nameof(ShowPanel))]
        public void ShowPanel() => _menuPanel.SetActive(true);

        /// <summary> Deactivate the menu panel. </summary>
        [ContextMenu(nameof(HidePanel))]
        public void HidePanel() => _menuPanel.SetActive(false);

        /// <summary> This page's <see cref="MenuState"/>. </summary>
        public MenuState State => _state;
    }
}