using TirUtilities.Extensions;
using UnityEditor;
using UnityEngine;

namespace TirUtilities.Editor.PropertyDrawers
{
    ///<!--
    /// ScenePathDrawer.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
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