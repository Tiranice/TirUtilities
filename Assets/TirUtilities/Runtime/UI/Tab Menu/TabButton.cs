using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
    /// TabButton.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Oct 08, 2020
    /// Updated:  Feb 22, 2021
    /// -->
    /// <summary>
    /// Derived from code written by Matt Gambell https://youtu.be/211t6r12XPQ
    /// 
    /// Contains all of the pointer event logic.
    /// </summary>
    [RequireComponent(typeof(Image))]
    public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        [SerializeField] private TabGroup _tabGroup;
        public Image Background { get; private set; }

        public UnityEvent onTabSelected;
        public UnityEvent onTabDeselected;

        private void Start()
        {
            Background = GetComponent<Image>();
            _tabGroup.Subscribe(this);
        }

        public void OnPointerEnter(PointerEventData eventData) => _tabGroup.OnTabEnter(this);

        public void OnPointerClick(PointerEventData eventData) => _tabGroup.OnTabSelected(this);

        public void OnPointerExit(PointerEventData eventData) => _tabGroup.OnTabExit();

        /// <summary>
        /// Invokes onTabSelected.
        /// </summary>
        public void Select() => onTabSelected.Invoke();

        /// <summary>
        /// Invokes onTabDeselected.
        /// </summary>
        public void Deselect() => onTabDeselected.Invoke();
    }
}