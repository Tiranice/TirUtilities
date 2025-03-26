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

namespace TirUtilities.Editor.Prefs
{
    ///<!--
    /// EditorPrefsBool.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Sep 06, 2021
    /// Updated:  Jul 15, 2024
    /// -->
    /// <summary>
    /// Creates a <c>Toggle</c>.
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
        public override void Draw(float labelWidth)
        {
            EditorGUIUtility.labelWidth = labelWidth;
            Value = EditorGUILayout.Toggle(Label, Value);
        }
    }
}