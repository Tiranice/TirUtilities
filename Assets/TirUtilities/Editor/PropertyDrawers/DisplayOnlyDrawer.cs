using UnityEditor;
using UnityEngine;

namespace TirUtilities.Editor.PropertyDrawers
{
    ///<!--
    /// DisplayOnlyDrawer.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  Mar. 31, 2021
    /// Updated:  Mar. 31, 2021
    /// -->
    /// <summary>
    /// Draws the <see cref="DisplayOnlyAttribute"/>.
    /// </summary>
    [CustomPropertyDrawer(typeof(DisplayOnlyAttribute))]
    public class DisplayOnlyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = false;
            EditorGUI.PropertyField(position: position,
                                    property: property,
                                    label: label,
                                    includeChildren: true);
            GUI.enabled = true;
        }
    }

}