using System.Linq;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

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
    ///<!--
    /// PausedState.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
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