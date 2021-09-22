using System;
using UnityEngine;

namespace TirUtilities
{
    ///<!--
    /// TagFieldAttribute.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  BlackPhoenixSoftware
    /// Created:  Sep 22, 2021
    /// Updated:  Sep 22, 2021
    /// -->
    /// <summary> The decorated string into a tag selection dropdown. </summary>
    /// <remarks> Defined by:  TagFieldDrawer </remarks>
    [AttributeUsage(validOn: AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class TagFieldAttribute : PropertyAttribute { }
}