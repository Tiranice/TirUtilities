using UnityEngine;
#if UNITY_INPUT_SYSTEM_1_0_2_OR_GREATER
using UnityEngine.InputSystem;
#endif
using UnityEngine.SceneManagement;

namespace TirUtilities.Experimental
{
    ///<!--
    /// ApplicationStateMachine.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  June 15, 2021
    /// Updated:  Aug. 22, 2021
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

#if UNITY_INPUT_SYSTEM_1_0_2_OR_GREATER
        [SerializeField] private PlayerInput _playerInput;
#endif

        #endregion

        #region States

        private readonly PlayingState _playingState = new PlayingState();
        private readonly PausedState _pausedState = new PausedState();
        private readonly QuittingState _quittingState = new QuittingState();

        #endregion

        #region Unity Messages

        private void Start() => CurrentState = _playingState;

        private void Update() => InGame = !SceneManager.GetActiveScene().path.Equals(_mainMenuScene);

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
#if UNITY_INPUT_SYSTEM_1_0_2_OR_GREATER
        public void TooglePaused(InputAction.CallbackContext context)
        {
            if (context.performed && InGame)
            {
                if (CurrentState is PlayingState)
                    _pausedState.EnterState(this);
                else if (CurrentState is PausedState)
                    _playingState.EnterState(this);
            }
        }

        public void QuitGame(InputAction.CallbackContext context)
        {
            if (context.performed)
                _quittingState.EnterState(this);
        }
#endif
        #endregion

        #region Public Properties

        public ApplicationState CurrentState { get; set; }
        public bool InGame { get; set; } = false;

        #endregion
    }
}