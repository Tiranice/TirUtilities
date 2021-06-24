using UnityEngine;

namespace TirUtilities.UI
{
    using TirUtilities.Extensions;
    //using TirUtilities.Signals;
    ///<!--
    /// MenuState.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Created:  June 03, 2021
    /// Updated:  June 03, 2021
    /// -->
    /// <summary>
    /// Used by the <see cref="MenuStateMachine"/> to control which menu is shown.
    /// </summary>
    /// <remarks>
    /// Each <see cref="MenuPage"/> needs a menu state.  This is done to avoid having to add 
    /// entries to an enum every time a new page is created.
    /// </remarks>
    // TODO:  Create interface and figure out what exit and update state should do.
    [CreateAssetMenu(fileName = "NewMenuState", menuName = "Scriptable Objects/Menu State")]
    public class MenuState : ScriptableObject, IState<MenuStateMachine>
    {
        #region Inspector Fields

        [Header("Information")]
        [SerializeField][TextArea] private string _description;

        #endregion

        #region Events & Signals

        //[Header("Signals")]
        //[SerializeField] private Signal _enterStateSignal;
        //[SerializeField] private Signal _exitStateSignal;
        //[SerializeField] private Signal _updateStateSignal;

        #endregion

        #region State Methods
        /// <summary>
        /// Transition from <see cref="MenuStateMachine.PreviousPage"/> to <see cref="MenuStateMachine.ActivePage"/>.
        /// </summary>
        /// <param name="stateMachine">The state machine that requires the update.</param>
        public void EnterState(MenuStateMachine stateMachine)
        {
            if (stateMachine.PreviousPage.NotNull())
                stateMachine.PreviousPage.HidePanel();
            stateMachine.ActivePage.ShowPanel();

            //_enterStateSignal.Emit();
        }

        /// <summary>
        /// Calls HidePanel for the active state.
        /// </summary>
        /// <param name="stateMachine"></param>
        public void ExitState(MenuStateMachine stateMachine)
        {
            if (stateMachine.ActivePage.NotNull())
                stateMachine.ActivePage.HidePanel();
        }

        /// <summary>
        /// Calls show panel for the active state.
        /// </summary>
        /// <param name="stateMachine"></param>
        public void UpdateState(MenuStateMachine stateMachine) =>
            stateMachine.ActivePage.ShowPanel();

        #endregion
    }
}
