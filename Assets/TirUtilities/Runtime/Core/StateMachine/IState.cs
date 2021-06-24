namespace TirUtilities
{
    ///<!--
    /// IState.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  June 6, 2021
    /// Updated:  June 6, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public interface IState<T> where T : StateMachine
    {
        public void EnterState(T stateMachine);
        public void ExitState(T stateMachine);
        public void UpdateState(T stateMachine);
    }
}