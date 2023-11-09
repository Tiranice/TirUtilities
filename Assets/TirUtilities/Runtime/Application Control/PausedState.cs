using System.Linq;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace TirUtilities.Experimental
{
    ///<!--
    /// PausedState.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  Jun 15, 2021
    /// Updated:  Oct 07, 2021
    /// -->
    /// <summary>
    /// Sets the time scale to <see cref="ApplicationState.PausedTimeScale"/> when entered.
    /// </summary>
    public sealed class PausedState : ApplicationState
    {
        public override void EnterState(ApplicationStateMachine stateMachine)
        {
            if (stateMachine.BlockPauseState) return;
            if (stateMachine.CurrentState is QuittingState) return;
            
            base.EnterState(stateMachine);

            stateMachine.CurrentState = this;

            UpdateInputSettings(stateMachine);

            Time.timeScale = PausedTimeScale;
            AudioListener.pause = true;
        }

        /// <summary>
        /// Switches all PlayerInput to the UI ActionMap and sets input mode to dynamic so that
        /// input events are still processed.
        /// </summary>
        /// <param name="stateMachine"></param>
        private void UpdateInputSettings(ApplicationStateMachine stateMachine)
        {
#if ENABLE_INPUT_SYSTEM
            if (stateMachine.EnterUIModeOnPause)
                PlayerInput.all
                    .ToList()
                    .ForEach(pi => pi.SwitchCurrentActionMap(stateMachine.UIActionMap));

            InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInDynamicUpdate;
#endif
            Cursor.lockState = CursorLockMode.None;
        }
    }
}