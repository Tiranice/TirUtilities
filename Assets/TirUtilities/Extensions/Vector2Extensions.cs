using UnityEngine;

namespace TirUtilities
{
    ///<!--
    /// Vector2Extensions.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  BlackPhoenixSoftware
    /// Created:  Oct 01, 2021
    /// Updated:  Oct 01, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public static class Vector2Extensions
    {
        /// <summary> Gets the absolute value of this vector2. </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        public static Vector2 Abs(this Vector2 vec) =>
            new Vector2(Mathf.Abs(vec.x), Mathf.Abs(vec.y));

    }
}
