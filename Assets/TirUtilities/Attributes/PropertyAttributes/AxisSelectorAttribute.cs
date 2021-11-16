#if ENABLE_LEGACY_INPUT_MANAGER
using UnityEngine;

namespace TirUtilities.InputManagment
{
    ///<!--
    /// AxisSelectorAttribute.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Jan 15, 2020
    /// Updated:  Oct 21, 2021
    /// -->
    /// <summary>
    /// Use get the names of each axis in the legacy input manager.
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public sealed class AxisSelectorAttribute : PropertyAttribute { }
} 
#endif