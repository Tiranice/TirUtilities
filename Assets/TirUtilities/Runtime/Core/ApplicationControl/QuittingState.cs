using UnityEngine;

namespace TirUtilities.Experimental
{
    ///<!--
    /// QuittingState.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  June 15, 2021
    /// Updated:  July 09, 2021
    /// -->
    /// <summary>
    /// Quits the game or exits play mode in the editor.
    /// </summary>
    public sealed class QuittingState : ApplicationState
    {
        public override void EnterState(ApplicationStateMachine stateMachine)
        {
            stateMachine.CurrentState = this;

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}