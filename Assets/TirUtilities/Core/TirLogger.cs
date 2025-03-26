using System.Diagnostics;

using Debug = UnityEngine.Debug;

///<!--
///     Copyright (C) 2025  Devon Wilson
///
///     This program is free software: you can redistribute it and/or modify
///     it under the terms of the GNU Lesser General Public License as published
///     by the Free Software Foundation, either version 3 of the License, or
///     (at your option) any later version.
///
///     This program is distributed in the hope that it will be useful,
///     but WITHOUT ANY WARRANTY; without even the implied warranty of
///     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
///     GNU Lesser General Public License for more details.
///
///     You should have received a copy of the GNU Lesser General Public License
///     along with this program.  If not, see <https://www.gnu.org/licenses/>.
///-->

namespace TirUtilities
{
    using static UnityRichTextColors;
    ///<!--
    /// TirLogger.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  May 15, 2021
    /// Updated:  Feb 22, 2024
    /// -->
    /// <summary>
    /// Contains a handful of specialized logging methods.
    /// </summary>
    public static class TirLogger
    {
        #region Color Properties

        /// <summary> Defaults to <see cref="Blue"/> </summary>
        public static RichTextColor ClassColor { get; set; } = Blue;

        /// <summary> Defaults to <see cref="LightBlue"/> </summary>
        public static RichTextColor MethodColor { get; set; } = LightBlue;

        /// <summary> Defaults to <see cref="Green"/> </summary>
        public static RichTextColor ContextColor { get; set; } = Green;

        public static void ResetColors()
        {
            ClassColor = Blue;
            MethodColor = LightBlue;
            ContextColor = Green;
        }

        #endregion

        #region Log Call

        [System.Obsolete("This has been replaced with a stack frame inspection." +
                 "Use TirLogger.LogCall() instead.")]
        public static void LogCall(string className, string methodName) =>
            Debug.Log($"Call to {className}.{methodName}");

#if !PLATFORM_WEBGL
        /// <summary>
        /// Logs the name of the calling method and its class to the console.
        /// </summary>
        /// <remarks>
        /// Not available in WebGL due to the inability to read stack fames.
        /// </remarks>
        public static void LogCall()
        {
            var frame = new StackFrame(1);

            var classText = $"<color={ClassColor}>{frame.GetMethod().DeclaringType.Name}</color>";
            var methodText = $"<color={MethodColor}>{frame.GetMethod().Name}</color>";

            Debug.Log($"Call to {classText}.{methodText}");
        }

        /// <summary>
        /// Logs the name of the calling method, its class, and the supplied context object to the 
        /// console.
        /// </summary>
        /// <remarks>
        /// Not available in WebGL due to the inability to read stack fames.
        /// </remarks>
        /// <param name="context">Supplied to <c>Debug.Log(sting, Object)</c></param>
        public static void LogCall(UnityEngine.Object context)
        {
            if (context is null)
            {
                throw new System.ArgumentNullException(nameof(context));
            }

            var frame = new StackFrame(1);

            var classText = $"<color={ClassColor}>{frame.GetMethod().DeclaringType.Name}</color>";
            var methodText = $"<color={MethodColor}>{frame.GetMethod().Name}</color>";
            var contextName = $"from <color={ContextColor}>context: {context.name}</color>";

            Debug.Log($"Call to {classText}.{methodText} {contextName}", context);
        }

        /// <summary>
        /// Logs the name of the calling method, its class, and the supplied context object to the 
        /// console.
        /// </summary>
        /// <remarks>
        /// Not available in WebGL due to the inability to read stack fames.
        /// </remarks>
        /// <param name="remarks">String appended to the end of the log</param>
        /// <param name="context">Supplied to <c>Debug.Log(sting, Object)</c></param>
        public static void LogCall(string remarks, UnityEngine.Object context)
        {
            if (context == null)
            {
                throw new System.ArgumentNullException(nameof(context));
            }

            var frame = new StackFrame(1);

            var classText = $"<color={ClassColor}>{frame.GetMethod().DeclaringType.Name}</color>";
            var methodText = $"<color={MethodColor}>{frame.GetMethod().Name}</color>";
            var contextName = $"from <color={ContextColor}>context: {context.name}</color>";

            Debug.Log($"Call to {classText}.{methodText} {contextName}:  {remarks}", context);
        }
#endif 

        #endregion
    }
}