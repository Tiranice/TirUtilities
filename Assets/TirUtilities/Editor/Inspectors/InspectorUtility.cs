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
    ///<!--
    /// InspectorUtility.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Jun 19, 2021
    /// Updated:  Mar 26, 2025
    /// -->
    /// <summary>
    ///
    /// </summary>
    internal sealed class InspectorUtility
    {
        #region Properties

        internal static int LabelIndent => 20;
        internal static int FontSize => 12;

        #endregion

        #region Draw Methods

        internal static Vector2 DrawVector2Field(float labelWidth, string xLabel, string yLabel, Rect origin, Vector2 tempVec, float fieldWidth, bool disableX, bool disableY)
        {
            using (new EditorGUI.DisabledScope(disableX))
            {
                DrawXField(labelWidth, xLabel, ref origin, ref tempVec);
            }

            using (new EditorGUI.DisabledScope(disableY))
            {
                DrawYField(fieldWidth, yLabel, origin, ref tempVec);
            }

            return tempVec;
        }

        internal static void DrawXField(float fieldWidth, string label, ref Rect origin, ref Vector2 tempVec)
        {
            // X Label
            origin.x = fieldWidth + LabelIndent;
            GUI.Label(origin, label);
            // X Field
            origin.x = fieldWidth + (LabelIndent + FontSize);
            tempVec.x = EditorGUI.FloatField(origin, GUIContent.none, tempVec.x);
        }

        internal static void DrawYField(float fieldWidth, string label, Rect origin, ref Vector2 tempVec)
        {
            // Y Label
            origin.x += fieldWidth + FontSize / 3;
            GUI.Label(origin, label);
            // Y Field
            origin.x += FontSize;
            tempVec.y = EditorGUI.FloatField(origin, GUIContent.none, tempVec.y);
        }

        internal static void DrawScriptProperty(SerializedObject serializedObject)
        {
            using var iterator = serializedObject.GetIterator();
            iterator.NextVisible(true);
            using (new EditorGUI.DisabledScope("m_Script" == iterator.propertyPath))
            {
                EditorGUILayout.PropertyField(iterator, true);
            }
        }

        internal static void DrawScriptProperty(SerializedProperty iterator)
        {
            iterator.NextVisible(true);
            using (new EditorGUI.DisabledScope("m_Script" == iterator.propertyPath))
            {
                EditorGUILayout.PropertyField(iterator, true);
            }
        }

        #endregion
    }
}