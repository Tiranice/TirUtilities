using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TirUtilities.Editor.Experimental
{
    using TirUtilities.UI;
    ///<!--
    /// MenuStateMachineInspector.cs
    /// 
    /// Project:  Project
    ///        
    /// Author :  Author
    /// Created:  Jan. 01, 2021
    /// Updated:  Jan. 01, 2021
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
        }

        #endregion
    }
}
