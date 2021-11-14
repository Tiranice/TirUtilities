#if ENABLE_LEGACY_INPUT_MANAGER
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace TirUtilities.Editor.InputManagment
{
    using TirUtilities.InputManagment;
    ///<!--
    /// AxisSelectorPropertyDrawer.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
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

            var gUIContents = new List<GUIContent>();
            for (int i = 0; i < axes.arraySize; i++)
            {
                gUIContents.Add(new GUIContent(axes.GetArrayElementAtIndex(i)
                                                   .FindPropertyRelative("m_Name").stringValue));
            }

            _index = EditorGUI.Popup(position, label, _index, gUIContents.ToArray());

            property.stringValue = axes
                .GetArrayElementAtIndex(_index)
                .FindPropertyRelative("m_Name").stringValue;
        }
    }
} 
#endif