using UnityEditor;
using UnityEngine;

namespace TirUtilities.Editor.Experimental
{
    using TirUtilities.UI;
    ///<!--
    /// MenuStateMachineInspector.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  July 05, 2021
    /// Updated:  Sep. 09, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    [CustomEditor(typeof(MenuStateMachine))]
    public class MenuStateMachineInspector : UnityEditor.Editor
    {
        #region Fields

        private MenuStateMachine _menuStateMachine;

        #endregion

        #region Unity Messages

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            FetchSceneMenuPages();
        }

        #endregion

        #region Private Methods

        private void FetchSceneMenuPages()
        {
            if (_menuStateMachine == null)
                _menuStateMachine = serializedObject.targetObject as MenuStateMachine;

            _menuStateMachine.MenuPages.Clear();
            _menuStateMachine.MenuPages.AddRange(FindObjectsOfType<MenuPage>());
            _menuStateMachine.MenuPages.Sort((i, j) => i.transform.GetSiblingIndex().CompareTo(j.transform.GetSiblingIndex()));
        }

        #endregion
    }
}
