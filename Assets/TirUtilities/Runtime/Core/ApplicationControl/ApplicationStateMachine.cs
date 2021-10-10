#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

namespace TirUtilities.Experimental
{
    using TirUtilities.Extensions;
    using TirUtilities.Signals;
    using TirUtilities.UI;

    ///<!--
    /// ApplicationStateMachine.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  Jun 15, 2021
    /// Updated:  Oct 07, 2021
    /// -->
    /// <summary>
    /// Controls the current state of the application.
    /// See also: <seealso cref="ApplicationState"/>
    /// </summary>
    public class ApplicationStateMachine : StateMachine
    {
        #region Inspector Fields

        [SerializeField, ScenePath]
        private string _mainMenuScene;

#if ENABLE_INPUT_SYSTEM
        
        [Header("Input System")]
        [SerializeField] private InputActionAsset _inputActions;

#if ODIN_INSPECTOR
        [ValueDropdown(nameof(GetNames)), DisableIf("@_inputActions == null"), SerializeField] 
        private string _playerActionMap = string.Empty;

        [ValueDropdown(nameof(GetNames)), DisableIf("@_inputActions == null"), SerializeField] 
        private string _uiActionMap = string.Empty;

        private IEnumerable<string> GetNames() =>
            _inputActions.NotNull() ? _inputActions.actionMaps.Select(m => m.name)
                                    : new string[] { string.Empty };
#else
        [SerializeField] private string _playerActionMap = string.Empty;

        [SerializeField] private string _uiActionMap = string.Empty;
#endif
#endif

        #endregion

        #region States

        private readonly PlayingState _playingState = new PlayingState();
        private readonly PausedState _pausedState = new PausedState();
        private readonly QuittingState _quittingState = new QuittingState();

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
            _playingState.OnEnterState += _playSignal.Emit;
            _pausedState.OnEnterState += _pauseSignal.Emit;
        }

        private void RemoveListeners()
        {
            _playingState.OnEnterState += _playSignal.Emit;
            _pausedState.OnEnterState += _pauseSignal.Emit;
        }

        private void Teardown()
        {
            RemoveReceivers();
            RemoveListeners();
        }

        #endregion

        #region Input Manager Methods

        public void TogglePaused()
        {
            if (!InGame) return;

            if (CurrentState is PlayingState)
                _pausedState.EnterState(this);
            else if (CurrentState is PausedState)
                _playingState.EnterState(this);
        }

        public void QuitGame() => _quittingState.EnterState(this);

        #endregion

        #region Input System Methods
#if ENABLE_INPUT_SYSTEM
        public void TogglePaused(InputAction.CallbackContext context)
        {
            if (!context.performed || !InGame) return;

            if (CurrentState is PlayingState)
                _pausedState.EnterState(this);
            else if (CurrentState is PausedState)
                _playingState.EnterState(this);
        }

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
        public bool InGame { get; set; } = false;
        public bool EnterUIModeOnPause => _enterUIModeOnPause;
        public bool BlockPauseState { get; private set; } = false;

#if ENABLE_INPUT_SYSTEM
        public string PlayerActionMap => _playerActionMap;
        public string UIActionMap => _uiActionMap;
#endif

        #endregion
    }
}
