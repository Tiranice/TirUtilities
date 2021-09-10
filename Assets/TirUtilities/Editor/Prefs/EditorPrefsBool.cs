using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TirUtilities.Editor.Prefs
{
    ///<!--
    /// EditorPrefsBool.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  Sep. 06, 2021
    /// Updated:  Sep. 06, 2021
    /// -->
    /// <summary>
    /// </summary>
    /// <remarks>
    /// Based on the EditorPrefString class in the source of RainbowFolders.
    /// </remarks>
    public class EditorPrefsBool : EditorPrefsItem<bool>
    {
        public EditorPrefsBool(string key, GUIContent label, bool defaultValue) 
            : base(key, label, defaultValue) { }

        public override bool Value 
        { 
            get => EditorPrefs.GetBool(Key, DefaultValue);
            set => EditorPrefs.SetBool(Key, value);
        }

        public override void Draw()
        {
            EditorGUIUtility.labelWidth = 100.0f;
            Value = EditorGUILayout.Toggle(Label, Value);
        }
    }
}