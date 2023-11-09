using UnityEngine;

namespace TirUtilities.Experimental
{
    ///<!--
    /// State.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  May 15, 2021
    /// Updated:  May 15, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public abstract class State : ScriptableObject
    {
        public abstract void EnterState(StateMachine stateMachine);

        public abstract void UpdateState(StateMachine stateMachine);

        public abstract void ExitState(StateMachine stateMachine);

        public abstract void ExitState(StateMachine stateMachine, out State nextState);
    }
}