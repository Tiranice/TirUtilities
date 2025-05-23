using System.Collections.Generic;
using System.Linq;

using UnityEngine;
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
    using TirUtilities.Extensions;

    using static TirLogger;
    ///<!--
    /// MenuStateMachine.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Jun 03, 2021
    /// Updated:  Aug 22, 2021
    /// -->
    /// <summary>
    /// Controls the state of a set of <see cref="MenuPage"/> objects in the scene.
    /// </summary>
    public class MenuStateMachine : StateMachine
    {
        #region Data Structures

        /// <summary> The set of states and the pages they link to. </summary>
        private readonly Dictionary<MenuState, MenuPage> _transitions = new();

        /// <summary> The states that were visited before the current one. </summary>
        private readonly Stack<MenuState> _history = new();

        #endregion

        #region Inspector Fields

        [Header("States and Pages")]
        [Tooltip("The menu state for the root menu page.")]
        [SerializeField] private MenuState _rootState;
        [SerializeField] private bool _enterRootStateOnStart = true;
        [Space]
        [Tooltip("All of the pages that this state machine manages.")]
        [SerializeField] private List<MenuPage> _menuPages;
        public List<MenuPage> MenuPages => _menuPages;


        [Header("Controls")]
        [Tooltip("The button that routes back to the previous menu page.")]
        [SerializeField] private Button _backButton;

        #endregion

        #region Private Fields

        [Header("Debug Display")]
        [DisplayOnly, SerializeField]
        private MenuPage _activePage;

        [DisplayOnly, SerializeField]
        private MenuPage _previousPage;

        #endregion

        #region Public Properties

        /// <summary> Get the currently active page. </summary>
        public MenuPage ActivePage => _activePage;

        /// <summary> Get the last active page. </summary>
        public MenuPage PreviousPage => _previousPage;

        #endregion

        #region Unity Messages

        private void Awake() => FetchMenuPages();
        private void Start() => InitTransitionTable();

        #endregion

        #region Setup & Teardown

        private void FetchMenuPages() => _menuPages = FindObjectsOfType<MenuPage>().ToList();

        /// <summary> Setup all table of menu pages and states. </summary>
        private void InitTransitionTable()
        {
            foreach (MenuPage page in _menuPages)
            {
                if (page.IsNull()) continue;
                if (_transitions.ContainsKey(page.State)) continue;

                _transitions[page.State] = page;
            }

            foreach (MenuState state in _transitions.Keys)
                _transitions[state].HidePanel();

            if (_enterRootStateOnStart)
                TransitionTo(_rootState);
        }

        #endregion

        #region State Methods

        /// <summary> Transitions the state machine to the given state. </summary>
        /// <param name="state"></param>
        public void TransitionTo(MenuState state)
        {
            if (_transitions.TryGetValue(state, out MenuPage page))
            {
                // Don't need the back button if at root state.
                _backButton.gameObject.SetActive(NotRootState(state));

                _previousPage = _activePage;
                _activePage = page;

                if (!_history.Contains(state))
                    _history.Push(state);

                state.EnterState(this);
            }

            bool NotRootState(MenuState target) => target != _rootState;
        }

        /// <summary> Go back to the previous page in the history. </summary>
        public void Back()
        {
            if (_history.Count <= 1)
                TransitionTo(_rootState);
            else
            {
                _history.Pop();
                TransitionTo(_history.Peek());
            }
        }

        public void OpenMenu() => TransitionTo(_rootState);

        public void ExitMenu()
        {
            TransitionTo(_rootState);
            if (_activePage.NotNull())
                _activePage.HidePanel();
        }

        #endregion
    }
}