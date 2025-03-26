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
///     You should have received a copy of the GNU General Public License
///     along with this program.  If not, see <https://www.gnu.org/licenses/>.
///-->

namespace TirUtilities.Editor.PropertyDrawers
{
    using TirUtilities.Extensions;
    ///<!--
    /// ScenePathDrawer.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  April 02, 2021
    /// Updated:  May 19, 2021
    /// -->
    /// <summary>
    /// Converts a string field to a UnityEditor.SceneAsset in the inspector.
    /// </summary>
    /// <remarks>
    /// Based on SceneDrawer.cs from Mirror.
    /// </remarks>
    [CustomPropertyDrawer(typeof(ScenePathAttribute))]
    public class ScenePathDrawer : PropertyDrawer
    {
        #region Unity Messages

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) =>
            DrawProperty(position, property, label);

        #endregion

        #region Drawer Methods

        private void DrawProperty(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.String)
            {
                string stringValue = property.stringValue;

                var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(stringValue);

                // Try to load it from the build settings for legacy compatibility.
                if (sceneAsset.IsNull() && !string.IsNullOrEmpty(stringValue))
                    sceneAsset = GetBuildSettingsSceneObject(stringValue);

                if (sceneAsset.IsNull() && !string.IsNullOrEmpty(stringValue))
                    Debug.LogError($"Could not find scene {stringValue} in {property.propertyPath}.");

                var scene = EditorGUI.ObjectField(position, label, sceneAsset, typeof(SceneAsset), true) as SceneAsset;

                property.stringValue = AssetDatabase.GetAssetPath(scene);
            }

            else
                EditorGUI.LabelField(position, label.text, "Use [ScenePath] with strings.");
        }

        private SceneAsset GetBuildSettingsSceneObject(string sceneName)
        {
            foreach (var buildScene in EditorBuildSettings.scenes)
            {
                var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(buildScene.path);

                if (sceneAsset.name.Equals(sceneName))
                    return sceneAsset;
            }
            return null;
        }

        #endregion
    }
}