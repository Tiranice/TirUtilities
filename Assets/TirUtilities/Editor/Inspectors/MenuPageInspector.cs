using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TirUtilities.Editor
{
    using TirUtilities.UI;

    using static InspectorUtility;
    //TODO :  Refactoring
    //TODO :  Write Summary
    ///<!--
    /// MenuPageInspector.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  Sep. 09, 2021
    /// Updated:  Sep. 09, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    [CustomEditor(typeof(MenuPage))]
    public class MenuPageInspector : UnityEditor.Editor
    {
        #region String Constants

        private const string _ParentFolderPath = "Assets/Resources/ScriptableObjects";
        private const string _FolderPath = "Assets/Resources/ScriptableObjects/MenuState";

        #endregion

        private readonly List<SerializedProperty> _drawnProperites = new List<SerializedProperty>();

        private SerializedProperty _menuState;

        private string _newStateName = string.Empty;

        public override void OnInspectorGUI() => DrawInspector();

        private bool DrawInspector()
        {
#if UNITY_2020_2_OR_NEWER
            using var checkScope = new EditorGUI.ChangeCheckScope();

            serializedObject.UpdateIfRequiredOrScript();

            var propertyIterator = serializedObject.GetIterator();

            DrawScriptProperty(propertyIterator);

            MenuStateProperty();

            DrawRest(propertyIterator);

            return checkScope.changed;
#else
            using (var checkScope = new EditorGUI.ChangeCheckScope())
            {
                serializedObject.UpdateIfRequiredOrScript();

                var propertyIterator = serializedObject.GetIterator();

                DrawScriptProperty(propertyIterator);

                MenuStateProperty();

                DrawRest(propertyIterator);

                return checkScope.changed;
            }
#endif
        }

        private void MenuStateProperty()
        {
            _menuState = serializedObject.FindProperty("_state");

            if (_menuState.objectReferenceValue == null)
                EditorGUILayout.HelpBox("Either create a new state or assign an existing one.",
                                        MessageType.Warning);

            EditorGUILayout.PropertyField(_menuState);

            if (_menuState.objectReferenceValue == null)
            {
                using (new EditorGUILayout.HorizontalScope())
                {
                    EditorGUILayout.LabelField("State Name", GUILayout.MaxWidth(80));
                    _newStateName = EditorGUILayout.TextField(_newStateName);
                    using (new EditorGUI.DisabledScope(_newStateName == string.Empty))
                    {
                        if (GUILayout.Button("Create New State"))
                            CreateMenuState();
                    }
                }
            }
            _drawnProperites.Add(_menuState);
        }

        private void CreateMenuState()
        {
            var menuState = ScriptableObject.CreateInstance<MenuState>();

            if (!AssetDatabase.IsValidFolder($"{_FolderPath}"))
                AssetDatabase.CreateFolder(_ParentFolderPath, "MenuStates");

            AssetDatabase.CreateAsset(menuState, $"{_FolderPath}/{_newStateName}.asset");
            AssetDatabase.SaveAssets();

            serializedObject.FindProperty("_state").objectReferenceValue = menuState;
        }

        private void DrawRest(SerializedProperty property)
        {
            while (property.NextVisible(false))
            {
                if (!_drawnProperites.Exists(i => i.propertyPath == property.propertyPath))
                    EditorGUILayout.PropertyField(property, true);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
