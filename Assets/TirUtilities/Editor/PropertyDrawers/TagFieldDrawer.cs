using UnityEditor;
using UnityEngine;

namespace TirUtilities.Editor
{
    ///<!--
    /// TagFieldDrawer.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  BlackPhoenixSoftware
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
            if (property.propertyType != SerializedPropertyType.String)
            {
                base.OnGUI(position, property, label);
                return;
            }

            using (new EditorGUI.PropertyScope(position, label, property))
            {
                property.stringValue = EditorGUI.TagField(position, label, property.stringValue);
            }
        }
    }
}
