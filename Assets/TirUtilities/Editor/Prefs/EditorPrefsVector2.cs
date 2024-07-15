using UnityEditor;
using UnityEngine;

namespace TirUtilities.Editor.Prefs
{
    ///<!--
    /// EditorPrefsVector2.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Sep 06, 2021
    /// Updated:  Jul 15, 2024
    /// -->
    /// <summary>
    /// Creates a <c>Vector2Field</c>.
    /// </summary>
    /// <remarks>
    /// Based on the EditorPrefString class in the source of RainbowFolders.
    /// </remarks>
    public class EditorPrefsVector2 : EditorPrefsItem<Vector2>
    {
        public EditorPrefsVector2(string key, GUIContent label, Vector2 defaultValue)
            : base(key, label, defaultValue) { }

        public override Vector2 Value 
        { 
            get => 
                new Vector2()
                {
                    x = EditorPrefs.GetFloat($"{Key}.x", DefaultValue.x),
                    y = EditorPrefs.GetFloat($"{Key}.y", DefaultValue.y)
                };
            set
            {
                EditorPrefs.SetFloat($"{Key}.x", value.x);
                EditorPrefs.SetFloat($"{Key}.y", value.y);
            }
        }

        public override void Draw()
        {
            EditorGUIUtility.labelWidth = 100.0f;
            Value = EditorGUILayout.Vector2Field(Label, Value);
        }
        public override void Draw(float labelWidth)
        {
            EditorGUIUtility.labelWidth = labelWidth;
            Value = EditorGUILayout.Vector2Field(Label, Value);
        }
    }
}