using System.Linq;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace TirUtilities.Experimental
{
    ///<!--
    /// PlayingState.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  Jun 15, 2021
    /// Updated:  Oct 07, 2021
    /// -->
    /// <summary>
    /// Sets the time scale to <see cref="ApplicationState.PausedTimeScale"/>.
    /// </summary>
    public sealed class PlayingState : ApplicationState
    {
        public override void EnterState(ApplicationStateMachine stateMachine)
        {
            if (stateMachine.CurrentState is QuittingState) return;

            base.EnterState(stateMachine);

            UpdateInputSettings(stateMachine);
            
            stateMachine.CurrentState = this;
            Time.timeScale = PlayingTimeScale;
            AudioListener.pause = false;
        }

        private static void UpdateInputSettings(ApplicationStateMachine stateMachine)
        {
#if ENABLE_INPUT_SYSTEM
            if (stateMachine.EnterUIModeOnPause)
                PlayerInput.all
                    .ToList()
                    .ForEach(pi => pi.SwitchCurrentActionMap(stateMachine.PlayerActionMap));

            InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInFixedUpdate;
#endif
        }
    }
}