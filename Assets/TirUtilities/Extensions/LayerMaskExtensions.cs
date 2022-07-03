using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace TirUtilities.Extensions
{
    ///<!--
    /// LayerMaskExtensions.cs
    /// 
    /// Project:  Siad
    ///        
    /// Author :  Devon Wilson
    /// Company:  VU-RASL
    /// Created:  May 19, 2022
    /// Updated:  May 19, 2022
    /// -->
    /// <summary>
    /// A set of extension methods for the <see cref="LayerMask"/> struct.
    /// </summary>
    public static class LayerMaskExtensions
    {
        public static bool LayerInMask(this LayerMask self, int layer) => ((1 << layer) & self) != 0;
    }
}
