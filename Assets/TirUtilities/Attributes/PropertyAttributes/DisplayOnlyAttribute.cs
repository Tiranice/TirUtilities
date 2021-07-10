using UnityEngine;

namespace TirUtilities
{
    ///<!--
    /// DisplayOnlyAttribute.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  Mar. 31, 2021
    /// Updated:  Mar. 31, 2021
    /// -->
    /// <summary>
    /// The decorated field is be displayed in the inspector, but cannot be edited.
    /// </summary>
    /// <remarks>
    /// Property drawer:  TirUtilities/Editor/PropertyDrawers/DisplayOnlyDrawer.cs
    /// </remarks>
    public class DisplayOnlyAttribute : PropertyAttribute { }

}