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
    ///<!--
    /// ShowIfDrawer.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Nov 02, 2021
    /// Updated:  Nov 15, 2021
    /// -->
    /// <summary>
    /// Drawer for <see cref="ShowIfAttribute"/>.
    /// </summary>
    [CustomPropertyDrawer(typeof(ShowIfAttribute))]
    public class ShowIfDrawer : PropertyDrawer
    {
        private bool _show;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var showIf = attribute as ShowIfAttribute;

            var targetProperty = property.serializedObject.FindProperty(showIf.TargetName);

            if (targetProperty.propertyType == SerializedPropertyType.Enum)
                _show = targetProperty.enumValueIndex == (int)showIf.TargetValue;

            else if (targetProperty.propertyType == SerializedPropertyType.Boolean)
                _show = targetProperty.boolValue;

            if (_show) EditorGUI.PropertyField(position, property, label);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) =>
            _show ? base.GetPropertyHeight(property, label) : 0.0f;
    }
}