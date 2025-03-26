#if ENABLE_LEGACY_INPUT_MANAGER
using System.Collections.Generic;
using System.Linq;

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
    using TirUtilities.InputManagement;
    ///<!--
    /// AxisSelectorPropertyDrawer.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Jan 15, 2020
    /// Updated:  Oct 21, 2021
    /// -->
    /// <summary>
    /// Drawer for the AxisSelector
    /// </summary>
    [CustomPropertyDrawer(typeof(AxisSelectorAttribute))]
    public class AxisSelectorPropertyDrawer : PropertyDrawer
    {
        private int _index = 0;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            { base.OnGUI(position, property, label); return; }

            var inputManager = new SerializedObject(
            AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset").First()
            );

            var axes = inputManager.FindProperty("m_Axes");

            var gUIContents = new List<string>();

            for (int i = 0; i < axes.arraySize; i++)
            {
                gUIContents.Add(axes.GetArrayElementAtIndex(i)
                                    .FindPropertyRelative("m_Name").stringValue);
            }

            var selectedIndex = property.stringValue == string.Empty ? 0 : gUIContents.IndexOf(property.stringValue);

            _index = EditorGUI.Popup(position: position,
                                     label: label.text,
                                     selectedIndex: selectedIndex,
                                     displayedOptions: gUIContents.ToArray());

            property.stringValue = gUIContents[_index];

            property.serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif