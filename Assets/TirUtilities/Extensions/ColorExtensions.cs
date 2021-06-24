using UnityEngine;
using Random = UnityEngine.Random;

namespace TirUtilities.Extensions
{
    ///<!--
    /// ColorExtensions.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  May 15, 2021
    /// Updated:  May 15, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public static class ColorExtensions
    {
        public static void SetRandColor(this Color color, float alpha = 1.0f)
        {
            color.r = Random.Range(0.0f, 1.0f);
            color.g = Random.Range(0.0f, 1.0f);
            color.b = Random.Range(0.0f, 1.0f);
            color.a = alpha == -1 ? Random.Range(0.0f, 1.0f) : alpha;
        }
    }
}
