using UnityEngine;

namespace TirUtilities
{
    ///<!--
    /// Vector3Extensions.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  May 01, 2021
    /// Updated:  Oct 01, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public static class Vector3Extensions
    {
        public static bool IsZero(this Vector3 vector3) => vector3 == Vector3.zero;
        public static bool NotZero(this Vector3 vector3) => vector3 != Vector3.zero;
        public static bool Invariant(this Vector3 vector3) => 
            Mathf.Approximately(vector3.x, vector3.y) && Mathf.Approximately(vector3.y, vector3.z);
        public static Vector3 Abs(this Vector3 vec) => 
            new Vector3(Mathf.Abs(vec.x), Mathf.Abs(vec.y), Mathf.Abs(vec.z));

    }
}
