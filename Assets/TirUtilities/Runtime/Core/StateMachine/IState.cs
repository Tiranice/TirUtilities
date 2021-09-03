namespace TirUtilities
{
    ///<!--
    /// IState.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  June 06, 2021
    /// Updated:  Aug. 22, 2021
    /// -->
    /// <summary>
    /// Implement this interface on object that should be states in a <see cref="StateMachine"/>.
    /// </summary>
    public interface IState<T> where T : StateMachine
    {
#if UNITY_2020_2_OR_NEWER        
        public void EnterState(T stateMachine);
        public void ExitState(T stateMachine);
        public void UpdateState(T stateMachine);
#else
        void EnterState(T stateMachine);
        void ExitState(T stateMachine);
        void UpdateState(T stateMachine);
#endif
    }
}