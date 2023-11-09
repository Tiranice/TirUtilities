using UnityEngine;

namespace TirUtilities.Experimental
{
    ///<!--
    /// MenuState.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  July 09, 2021
    /// Updated:  July 09, 2021
    /// -->
    /// <summary>
    /// State machine enters this state when in a menu.
    /// </summary>
    public sealed class MenuState : ApplicationState
    {
        public override void EnterState(ApplicationStateMachine stateMachine)
        {
            if (stateMachine.CurrentState is QuittingState) return;

            if (stateMachine.InGame)
                Time.timeScale = PausedTimeScale;

        }
    }
}