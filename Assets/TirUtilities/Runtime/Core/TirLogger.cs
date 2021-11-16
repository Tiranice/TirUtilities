using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

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
        [System.Obsolete("This has been replaced with a stack frame inspection." +
                         "Use TirLogger.LogCall() instead.")]
        public static void LogCall(string className, string methodName) =>
            Debug.Log($"Call to {className}.{methodName}");

#if !PLATFORM_WEBGL
        /// <summary> Logs the name of the class and the method to the console. </summary>
        public static void LogCall()
        {
            var frame = new StackFrame(1);

            var methodName = frame.GetMethod().Name;
            var className = frame.GetMethod().DeclaringType.Name;

            Debug.Log($"Call to {className}.{methodName}");
        }
#endif
    }
}