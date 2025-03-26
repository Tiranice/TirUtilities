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

namespace TirUtilities.Editor
{
    ///<!--
    /// TagFieldDrawer.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Sep 22, 2021
    /// Updated:  Sep 22, 2021
    /// -->
    /// <summary> The decorated string into a tag selection dropdown. </summary>
    /// <remarks> 
    /// Based on [TagSelector] from 
    /// <see href="https://assetstore.unity.com/packages/tools/ai/sensor-toolkit-88036">Sensor Toolkit</see>.
    /// </remarks>
    [CustomPropertyDrawer(typeof(TagFieldAttribute))]
    public class TagFieldDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String) return;

            using (new EditorGUI.PropertyScope(position, label, property))
                property.stringValue = EditorGUI.TagField(position, label, property.stringValue);
        }
    }
}
