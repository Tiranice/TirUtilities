using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TirUtilities.Editor
{
    ///<!--
    /// ShowIfDrawer.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
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