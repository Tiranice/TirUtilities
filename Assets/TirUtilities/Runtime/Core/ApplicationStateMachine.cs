using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TirUtilities.Experimental
{
    ///<!--
    /// ApplicationStateMachine.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  June 15, 2021
    /// Updated:  June 15, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public class ApplicationStateMachine : StateMachine
    {
        public ApplicationState CurrentState { get; set; }

        #region State Methods

        public static void TogglePaused()
        {
            
        }

        #endregion
    }

    public class ApplicationState : ScriptableObject, IState<ApplicationStateMachine>
    {
        #region Inspector Fields

        /// <summary>
        /// The description of what this state is intended to be used for.
        /// </summary>
        [Tooltip("The description of what this state is intended to be used for.")]
        [TextArea][SerializeField] protected string _description;

        /// <summary>
        /// The description of what this state is intended to be used for.
        /// </summary>
        public string Description { get => _description; }

        #endregion

        #region Static Properties

        protected static float PausedTimeScale => 1.0e-13f;
        protected static float PlayingTimeScale => 1.0f;

        #endregion

        #region State Methods

        public virtual void EnterState(ApplicationStateMachine stateMachine) { }
        public virtual void ExitState(ApplicationStateMachine stateMachine) { }
        public virtual void UpdateState(ApplicationStateMachine stateMachine) { }

        #endregion
    }

    public class PlayingState : ApplicationState
    {
    }

    public class PausedState : ApplicationState
    {
        public override void EnterState(ApplicationStateMachine stateMachine)
        {
            if (stateMachine.CurrentState is QuittingState) return;

            stateMachine.CurrentState = this;

            Time.timeScale = PausedTimeScale;
        }
    }

    public class QuittingState : ApplicationState
    {
    }
}