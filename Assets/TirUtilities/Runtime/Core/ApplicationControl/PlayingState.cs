using UnityEngine;

namespace TirUtilities.Experimental
{
    ///<!--
    /// PlayingState.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  June 15, 2021
    /// Updated:  July 09, 2021
    /// -->
    /// <summary>
    /// Sets the time scale to <see cref="ApplicationState.PausedTimeScale"/>.
    /// </summary>
    public sealed class PlayingState : ApplicationState
    {
        public override void EnterState(ApplicationStateMachine stateMachine)
        {
            if (stateMachine.CurrentState is QuittingState) return;

            stateMachine.CurrentState = this;
            Time.timeScale = PlayingTimeScale;
        }
    }
}