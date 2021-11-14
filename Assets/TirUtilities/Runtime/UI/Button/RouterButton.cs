using TirUtilities.Experimental;
using TirUtilities.Extensions;
using TirUtilities.Signals;
using UnityEngine;
using UnityEngine.UI;

namespace TirUtilities.UI.Buttons.Experimental
{
    ///<!--
    /// RouterButton.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Nov 02, 2021
    /// Updated:  Nov 02, 2021
    /// -->
    /// <summary>
    /// Provides a quick way to route to various common actions.
    /// <list type="bullet">
    /// <item>Load a level by calling <see cref="LevelLoadSignal.Emit"/></item>
    /// <item>
    /// Quit or toggle the game's paused state with an <see cref="ApplicationStateMachine"/>
    ///     <list type="bullet">
    ///     <item><see cref="ApplicationStateMachine.QuitGame"/></item>
    ///     <item><see cref="ApplicationStateMachine.TogglePaused"/></item>
    ///     </list>
    /// </item>
    /// <item>Change the active menu page with <see cref="MenuStateMachine.TransitionTo(MenuState)"/></item>
    /// </list>
    /// </summary>
    [AddComponentMenu("TirUtilities/UI/Buttons/Experimental/Router Button"), RequireComponent(typeof(Button))]
    public class RouterButton : MonoBehaviour
    {
        #region Data Structures

        /// <summary> The type of route for a <see cref="RouterButton"/> </summary>
        [System.Serializable]
        public enum RouteType { LevelSignal, Application, MenuState, }

        /// <summary>
        /// The <see cref="ApplicationStateMachine"/> action bound to a <see cref="RouterButton"/>
        /// </summary>
        [System.Serializable]
        public enum ButtonType { PlayPause, QuitGame, }

        #endregion

        [SerializeField, Tooltip("The type of action bound to this button.")]
        private RouteType _routeType = RouteType.LevelSignal;

        [Header("Route Settings")]

        #region Level Routing

        [SerializeField, ShowIf(nameof(_routeType), RouteType.LevelSignal)]
        [Tooltip("The level signal that is emitted by this button.")]
        private LevelLoadSignal _targetLevel;

        private void AssignLevelListeners()
        {
            if ((_routeType != RouteType.LevelSignal) || _targetLevel.IsNull()) return;

            _button.onClick.AddListener(_targetLevel.Emit);
        }

        private void RemoveLevelListeners()
        {
            if ((_routeType != RouteType.LevelSignal) || _targetLevel.IsNull()) return;

            _button.onClick.AddListener(_targetLevel.Emit);
        }

        #endregion

        #region Application Routing

        [SerializeField, ShowIf(nameof(_routeType), RouteType.Application)]
        [Tooltip("The state machine that will be routed to.")]
        private ApplicationStateMachine _applicationStateMachine;
        
        [SerializeField, ShowIf(nameof(_routeType), RouteType.Application)]
        [Tooltip("The action that will be bound to this button.")]
        private ButtonType _buttonType = ButtonType.QuitGame;

        private void AssignAppListeners()
        {
            if ((_routeType != RouteType.Application) || _applicationStateMachine.IsNull()) return;

            if (_buttonType == ButtonType.PlayPause)
                _button.onClick.AddListener(_applicationStateMachine.TogglePaused);

            else if (_buttonType == ButtonType.QuitGame)
                _button.onClick.AddListener(_applicationStateMachine.QuitGame);
        }

        private void RemoveAppListeners()
        {
            if ((_routeType != RouteType.Application) || _applicationStateMachine.IsNull()) return;

            if (_buttonType == ButtonType.PlayPause)
                _button.onClick.RemoveListener(_applicationStateMachine.TogglePaused);

            else if (_buttonType == ButtonType.QuitGame)
                _button.onClick.RemoveListener(_applicationStateMachine.QuitGame);
        }

        #endregion

        #region Menu Routing

        [SerializeField, ShowIf(nameof(_routeType), RouteType.MenuState)]
        [Tooltip("The state machine that actions are bound to.")]
        private MenuStateMachine _menuStateMachine;
        
        [SerializeField, ShowIf(nameof(_routeType), RouteType.MenuState)] 
        [Tooltip("The menu state that will be entered when this button is clicked.")]
        private MenuState _boundState;

        private void AssignMenuListeners()
        {
            if (_routeType != RouteType.MenuState) return;
            if (_menuStateMachine.IsNull() || _boundState.IsNull()) return;

            _button.onClick.AddListener(Transition);

            void Transition() => _menuStateMachine.TransitionTo(_boundState);
        }

        private void RemoveMenuListeners()
        {
            if (_routeType != RouteType.MenuState) return;
            if (_menuStateMachine.IsNull() || _boundState.IsNull()) return;

            _button.onClick.RemoveListener(Transition);

            void Transition() => _menuStateMachine.TransitionTo(_boundState);
        }

        #endregion

        #region Button Settings

        [Header("Debug")]
        [SerializeField, DisplayOnly] Button _button;

        #endregion

        #region Unity Messages

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_button.IsNull()) TryGetComponent(out _button);
        }
#endif
        private void Awake()
        {
            if (_button.IsNull()) TryGetComponent(out _button);
        }

        private void OnEnable()
        {
            if (_button.IsNull()) return;

            AssignAppListeners();
            AssignLevelListeners();
            AssignMenuListeners();
        }
        private void OnDisable()
        {
            if (_button.IsNull()) return;

            RemoveAppListeners();
            RemoveLevelListeners();
            RemoveMenuListeners();
        }

        #endregion
    }
}