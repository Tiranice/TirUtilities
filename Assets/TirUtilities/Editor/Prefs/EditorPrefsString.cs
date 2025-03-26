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