using UnityEngine;

namespace TirUtilities
{
    ///<!--
    /// ScenePathAttribute.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  April 02, 2021
    /// Updated:  April 02, 2021
    /// -->
    /// <summary>
    /// Converts a string field to a UnityEditor.SceneAsset in the inspector.
    /// </summary>
    /// <remarks>
    /// Based on [Scene] from Mirror.
    /// Property drawer:  TirUtilities/Editor/PropertyDrawers/ScenePathDrawer.cs
    /// </remarks>
    public class ScenePathAttribute : PropertyAttribute { }
}