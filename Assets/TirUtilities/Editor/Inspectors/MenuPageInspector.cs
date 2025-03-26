using System.Collections.Generic;
using System.IO;

using UnityEditor;

using UnityEngine;

///<!--
///     Copyright (C) 2025  Devon Wilson
///
///     This program is free software: you can redistribute it and/or modify
///     it under the terms of the GNU Lesser General Public License as published
///     by the Free Software Foundation, either version 3 of the License, or
///     (at your option) any later version.
///
///     This program is distributed in the hope that it will be useful,
///     but WITHOUT ANY WARRANTY; without even the implied warranty of
///     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
///     GNU Lesser General Public License for more details.
///
///     You should have received a copy of the GNU Lesser General Public License
///     along with this program.  If not, see <https://www.gnu.org/licenses/>.
///-->

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
    /// Company:  Black Phoenix Creative
    /// Created:  Sep 09, 2021
    /// Updated:  Mar 26, 2025
    /// -->
    /// <summary>
    ///
    /// </summary>
    [CustomEditor(typeof(MenuPage), true)]
    public class MenuPageInspector : UnityEditor.Editor
    {
        #region String Constants

        private const string _ParentFolderPath = "Assets/Resources";
        private const string _FolderName = "MenuStates";

        #endregion

        private readonly List<SerializedProperty> _drawnProperites = new();

        private SerializedProperty _menuState;

        private string _newStateName = string.Empty;

        public override void OnInspectorGUI() => DrawInspector();

        private bool DrawInspector()
        {
            using var checkScope = new EditorGUI.ChangeCheckScope();

            serializedObject.UpdateIfRequiredOrScript();

            var propertyIterator = serializedObject.GetIterator();

            DrawScriptProperty(propertyIterator);

            MenuStateProperty();

            DrawRest(propertyIterator);

            return checkScope.changed;
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

            string folderPath = Path.Combine(_ParentFolderPath, _FolderName);

            if (!AssetDatabase.IsValidFolder($"{folderPath}"))
                AssetDatabase.CreateFolder(_ParentFolderPath, "MenuStates");

            AssetDatabase.CreateAsset(menuState, Path.Combine(folderPath, $"{_newStateName}.asset"));
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
