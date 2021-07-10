using UnityEngine;

namespace TirUtilities.Experimental
{
    ///<!--
    /// ApplicationState.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  June 15, 2021
    /// Updated:  July 09, 2021
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

        #region State Methods

        /// <summary>
        /// Logic that should run when the state is entered.
        /// </summary>
        /// <param name="stateMachine"></param>
        public virtual void EnterState(ApplicationStateMachine stateMachine) { }

        /// <summary>
        /// Logic that should run when the state is exited.
        /// </summary>
        /// <param name="stateMachine"></param>
        public virtual void ExitState(ApplicationStateMachine stateMachine) { }

        /// <summary>
        /// Logic that should run when the state machine needs to update data maintained by the
        /// current state.
        /// </summary>
        /// <param name="stateMachine"></param>
        public virtual void UpdateState(ApplicationStateMachine stateMachine) { }

        #endregion
    }
}