using UnityEngine;

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
    /// ApplicationState.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Jun 15, 2021
    /// Updated:  Oct 05, 2021
    /// -->
    /// <summary>
    /// Base class for states that belong to the <see cref="ApplicationStateMachine"/>.
    /// </summary>
    public class ApplicationState : IState<ApplicationStateMachine>
    {
        #region Inspector Fields

        /// <summary>
        /// The description of what this state is intended to be used for.
        /// </summary>
        [Tooltip("The description of what this state is intended to be used for.")]
        [TextArea, SerializeField] protected string _description;

        /// <summary>
        /// The description of what this state is intended to be used for.
        /// </summary>
        public string Description { get => _description; }

        #endregion

        #region Static Properties

        /// <summary> Small number 1.0e-13f. </summary>
        protected static float PausedTimeScale => 1.0e-13f;

        /// <summary> One 1.0f </summary>
        protected static float PlayingTimeScale => 1.0f;

        #endregion

        #region Events & Signals

        public event System.Action OnEnterState;
        public event System.Action OnExitState;

        #endregion

        #region State Methods

        /// <summary>
        /// Logic that should run when the state is entered.
        /// </summary>
        /// <param name="stateMachine"></param>
        public virtual void EnterState(ApplicationStateMachine stateMachine) { OnEnterState?.Invoke(); }

        /// <summary>
        /// Logic that should run when the state is exited.
        /// </summary>
        /// <param name="stateMachine"></param>
        public virtual void ExitState(ApplicationStateMachine stateMachine) { OnExitState?.Invoke(); }

        /// <summary>
        /// Logic that should run when the state machine needs to update data maintained by the
        /// current state.
        /// </summary>
        /// <param name="stateMachine"></param>
        public virtual void UpdateState(ApplicationStateMachine stateMachine) { }

        #endregion
    }
}