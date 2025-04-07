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
                new()
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