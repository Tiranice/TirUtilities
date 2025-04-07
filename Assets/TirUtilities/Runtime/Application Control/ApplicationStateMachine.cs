#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif
using UnityEngine.SceneManagement;

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

namespace TirUtilities.Experimental
{
    using TirUtilities.Extensions;
    using TirUtilities.Signals;

    ///<!--
    /// ApplicationStateMachine.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Jun 15, 2021
    /// Updated:  Nov 16, 2021
    /// -->
    /// <summary>
    /// Controls the current state of the application.
    /// See also: <seealso cref="ApplicationState"/>
    /// </summary>
    public class ApplicationStateMachine : StateMachine
    {
        #region Inspector Fields

        /// <summary> Used to determine where or not InGame should be true. </summary>
        [SerializeField, ScenePath, Tooltip("Used to determine where or not InGame should be true.")]
        private string _mainMenuScene;

#if ENABLE_INPUT_SYSTEM

        [Header("Input System")]
#if ODIN_INSPECTOR
        [SerializeField] private InputActionAsset _inputActions;

        [ValueDropdown(nameof(GetNames)), DisableIf("@_inputActions == null"), SerializeField] 
        private string _playerActionMap = string.Empty;

        [ValueDropdown(nameof(GetNames)), DisableIf("@_inputActions == null"), SerializeField] 
        private string _uiActionMap = string.Empty;

        private IEnumerable<string> GetNames() =>
            _inputActions.NotNull() ? _inputActions.actionMaps.Select(m => m.name)
                                    : new string[] { string.Empty };
#else

        ///<summary> The action map used for player input. </summary>
        [SerializeField, Tooltip("The action map used for player input.")]
        private string _playerActionMap = string.Empty;

        /// <summary> The action map used for UI input. </summary>
        [SerializeField, Tooltip("The action map used for UI input.")]
        private string _uiActionMap = string.Empty;
#endif
#endif

        #endregion

        #region States

        private readonly PlayingState _playingState = new();
        private readonly PausedState _pausedState = new();
        private readonly QuittingState _quittingState = new();

        #endregion

        #region Events & Signals

        [Header("Signals")]
        [SerializeField] private Signal _playSignal;
        [SerializeField] private Signal _pauseSignal;
#if ENABLE_INPUT_SYSTEM
        [Space]
        [SerializeField] private Signal _playerPauseSignal;
        [SerializeField] private bool _enterUIModeOnPause = true;
#endif

        #endregion

        #region Unity Messages

        private void Awake() => Wakeup();

        private void Start() => Startup();

        //TODO : Change how InGame is set.
        private void Update() => InGame = !SceneManager.GetActiveScene().path.Equals(_mainMenuScene);

        private void OnDestroy() => Teardown();

        #endregion

        #region Setup & Teardown

        private void Wakeup()
        {
            AssignReceivers();
            AssignListeners();
        }

        private void Startup() => CurrentState = _playingState;

        private void AssignReceivers()
        {
#if ENABLE_INPUT_SYSTEM
            if (_playerPauseSignal.NotNull())
                _playerPauseSignal.AddReceiver(TogglePaused);
#endif
        }

        private void RemoveReceivers()
        {
#if ENABLE_INPUT_SYSTEM
            if (_playerPauseSignal.NotNull())
                _playerPauseSignal.RemoveReceiver(TogglePaused);
#endif
        }

        private void AssignListeners()
        {
            if (_playSignal.NotNull())
                _playingState.OnEnterState += _playSignal.Emit;
            if (_pauseSignal.NotNull())
                _pausedState.OnEnterState += _pauseSignal.Emit;
        }

        private void RemoveListeners()
        {
            if (_playSignal.NotNull())
                _playingState.OnEnterState -= _playSignal.Emit;
            if (_pauseSignal.NotNull())
                _pausedState.OnEnterState -= _pauseSignal.Emit;
        }

        private void Teardown()
        {
            RemoveReceivers();
            RemoveListeners();
        }

        #endregion

        #region Input Manager Methods

        /// <summary>
        /// Switches between the <see cref="PlayingState"/> and <see cref="PausedState"/>.
        /// </summary>
        public void TogglePaused()
        {
            if (!InGame) return;

            if (CurrentState is PlayingState)
                _pausedState.EnterState(this);
            else if (CurrentState is PausedState)
                _playingState.EnterState(this);
        }

        /// <summary> Enters the <see cref="QuittingState"/>. </summary>
        public void QuitGame() => _quittingState.EnterState(this);

        #endregion

        #region Input System Methods
#if ENABLE_INPUT_SYSTEM
        /// <summary>
        /// Switches between the <see cref="PlayingState"/> and <see cref="PausedState"/>.
        /// </summary>
        /// <remarks> Intended to be called from <see cref="PlayerInput"/> events. </remarks>
        public void TogglePaused(InputAction.CallbackContext context)
        {
            if (!context.performed || !InGame) return;

            if (CurrentState is PlayingState)
                _pausedState.EnterState(this);
            else if (CurrentState is PausedState)
                _playingState.EnterState(this);
        }

        /// <summary> Enters the <see cref="QuittingState"/>. </summary>
        /// <remarks> Intended to be called from <see cref="PlayerInput"/> events. </remarks>
        public void QuitGame(InputAction.CallbackContext context)
        {
            if (context.performed)
                _quittingState.EnterState(this);
        }
#endif
        #endregion

        #region Pause Control

        public void BlockPause() => BlockPauseState = true;
        public void AllowPause() => BlockPauseState = false;

        #endregion

        #region Public Properties

        public ApplicationState CurrentState { get; set; }
        //TODO : This report whether or not the active scene is one a set of menu scenes.
        public bool InGame { get; set; } = false;
        public bool BlockPauseState { get; private set; } = false;
#if ENABLE_INPUT_SYSTEM
        public bool EnterUIModeOnPause => _enterUIModeOnPause;

        ///<summary> The action map used for player input. </summary>
        public string PlayerActionMap => _playerActionMap;

        /// <summary> The action map used for UI input. </summary>
        public string UIActionMap => _uiActionMap;
#endif
        #endregion
    }
}
