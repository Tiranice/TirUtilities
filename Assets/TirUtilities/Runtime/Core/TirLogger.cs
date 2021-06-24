using UnityEngine;

namespace TirUtilities
{
    ///<!--
    /// TirLogger.cs
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
    public static class TirLogger
    {
        public static void LogCall(string className, string methodName) =>
            Debug.Log($"Call to {className}.{methodName}");
    }
}