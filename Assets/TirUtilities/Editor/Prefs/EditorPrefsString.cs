using UnityEditor;
using UnityEngine;

namespace TirUtilities.Editor.Prefs
{
    ///<!--
    /// EditorPrefsString.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon
    /// Company:  Black Phoenix Creative
    /// Created:  Sep 03, 2021
    /// Updated:  Jul 15, 2024
    /// -->
    /// <summary>
    /// Creates a <c>TextField</c>.
    /// </summary>
    /// <remarks>
    /// Based on the EditorPrefString class in the source of RainbowFolders.
    /// </remarks>
    public class EditorPrefsString : EditorPrefsItem<string>
    {
        public EditorPrefsString(string key, GUIContent label, string defaultValue)
            : base(key, label, defaultValue) { }

        public override string Value
        {
            get => EditorPrefs.GetString(Key, DefaultValue);
            set => EditorPrefs.SetString(Key, value);
        }

        public override void Draw()
        {
            EditorGUIUtility.labelWidth = 100.0f;
            Value = EditorGUILayout.TextField(Label, Value);
        }

        public override void Draw(float labelWidth)
        {
            EditorGUIUtility.labelWidth = labelWidth;
            Value = EditorGUILayout.TextField(Label, Value);
        }
    }
}