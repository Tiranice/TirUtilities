using System.Collections.Generic;
using UnityEngine;

namespace TirUtilities.UI
{
    ///<!--
    /// TabGroup.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson  
    /// Created:  Oct. 08, 2020
    /// Updated:  Feb. 22, 2021
    /// -->
    /// <summary>
    /// Derived from code written by Matt Gambell https://youtu.be/211t6r12XPQ
    /// 
    /// Maintains all tabs in child objects.
    /// </summary>
    public class TabGroup : MonoBehaviour
    {
        #region FIELDS

        [Header("All tabs associated with the group.")]
        public List<TabButton> tabButtons;
        [Tooltip("Tab unselected.")]
        [SerializeField] private Sprite _tabIdle;
        [Tooltip("Tab clicked.")]
        [SerializeField] private Sprite _tabSelected;
        [Tooltip("Defaluts to #c8c8c8")]
        [SerializeField] private Color _hoverColor = new Color(_shadeColor, _shadeColor, _shadeColor);

        private TabButton _selectedTab;
        private static readonly float _shadeColor = 200.0f / 255.0f;

        #endregion

        #region UNITY_MESSAGES

        private void Update() => TabNavigation();

        #endregion

        #region PRIVATE_METHODS

        /// <summary>
        /// Used to sort tabs in tabButtons list.
        /// </summary>
        /// <param name="tabA"></param>
        /// <param name="tabB"></param>
        /// <returns></returns>
        private static int CompareIndex(TabButton tabA, TabButton tabB)
        {
            int tabAIndex = tabA.transform.GetSiblingIndex();
            int tabBIndex = tabB.transform.GetSiblingIndex();

            // tabA is the top
            if (tabAIndex == 0)
            {
                // tabA and tabB are the same object.
                if (tabBIndex == 0) return 0;
                else return -1;
            }
            // tabB is the top
            else if (tabBIndex == 0) return 1;
            else return tabAIndex.CompareTo(tabBIndex);
        }

        /// <summary>
        /// Cycles through the tabs in order by sibling index.
        /// </summary>
        /// <remarks>
        /// Make sure that all tabs an pages in the menu are in the same order in the
        /// hierarchy that they are in the scene.
        /// </remarks>
        private void TabNavigation()
        {
            if (Input.GetKeyDown(KeyCode.Tab) && _selectedTab != null)
            {
                int index = _selectedTab.transform.GetSiblingIndex();
                TabButton button = (index < tabButtons.Count - 1) ? tabButtons[index + 1] : tabButtons[0];
                OnTabSelected(button);
            }
        }

        #endregion

        #region PUBLIC_METHODS

        /// <summary>
        /// Adds a button the the list of buttons managed by the tab group.
        /// </summary>
        /// <param name="button"></param>
        public void Subscribe(TabButton button)
        {
            if (tabButtons == null) tabButtons = new List<TabButton>();
            tabButtons?.Add(button);
            tabButtons.Sort(CompareIndex);
        }

        /// <summary>
        /// Call when the mouse hovers over a tab.
        /// </summary>
        /// <param name="button"></param>
        public void OnTabEnter(TabButton button)
        {
            ResetTabs();
            if (_selectedTab == null || button != _selectedTab) button.Background.color = _hoverColor;
        }

        /// <summary>
        /// Call when a tab is deselected or the mouse leaves the tab.
        /// </summary>
        public void OnTabExit() => ResetTabs();

        /// <summary>
        /// Call when a tab is selected.
        /// </summary>
        /// <param name="button"></param>
        public void OnTabSelected(TabButton button)
        {
            if (_selectedTab != null) _selectedTab.Deselect();

            _selectedTab = button;
            _selectedTab.Select();
            ResetTabs();
            _selectedTab.Background.color = Color.white;
            button.Background.sprite = _tabSelected;
        }

        /// <summary>
        /// Call to reset all tabs to their default state.
        /// </summary>
        public void ResetTabs()
        {
            foreach (var button in tabButtons)
            {
                if (_selectedTab != null && button.Equals(_selectedTab)) continue;
                button.Background.sprite = _tabIdle;
                button.Background.color = Color.white;
            }
        }

        #endregion
    }
}