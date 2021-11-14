using UnityEditor;
using UnityEngine;

namespace TirUtilities.Editor
{
    ///<!--
    /// EnumButtonsDrawer.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Nov 02, 2021
    /// Updated:  Nov 02, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    [CustomPropertyDrawer(typeof(EnumButtonsAttribute))]
    public class EnumButtonsDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.Enum)
                base.OnGUI(position, property, label);

            using (new EditorGUI.ChangeCheckScope())
            {
                var buttonPos = position;
                var width = EditorGUIUtility.currentViewWidth / Mathf.Min(property.enumDisplayNames.Length, 3);
                var height = (position.height / Mathf.Min(property.enumDisplayNames.Length, 3)) - EditorGUIUtility.singleLineHeight * 0.5f;

                buttonPos.width = width;
                buttonPos.height = property.enumNames.Length <= 3 ? position.height : height;

                var originalBackgroundColor = GUI.backgroundColor;

                for (int i = 0; i < property.enumDisplayNames.Length; i++)
                {

                    GUI.backgroundColor = i == property.enumValueIndex ? Color.green : originalBackgroundColor;

                    if (GUI.Button(buttonPos, property.enumDisplayNames[i]))
                        property.enumValueIndex = i;
                    
                    GUI.backgroundColor = originalBackgroundColor;

                    buttonPos.x += width;

                    if (((i + 1) % 3) == 0)
                    { 
                        buttonPos.y += position.y;
                        buttonPos.x = position.x;
                    }
                }
                property.serializedObject.ApplyModifiedProperties();
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (property.enumNames.Length <= 3)
                return base.GetPropertyHeight(property, label);

            Debug.Log(property.displayName);
            float totalHeight = EditorGUI.GetPropertyHeight(property, label, true) + EditorGUIUtility.standardVerticalSpacing;

            return totalHeight * ((property.enumNames.Length / 3) + 1);
        }

    }
}
