using Object = UnityEngine.Object;

namespace TirUtilities.Extensions
{
    ///<!--
    /// ObjectExtensions.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  May 01, 2021
    /// Updated:  Jul 15, 2024
    /// -->
    /// <summary>
    /// A set of extensions to UnityEngine.Object.
    /// </summary>
    public static class ObjectExtensions
    {
        public static bool IsNull(this Object self) => self == null;
        public static bool NotNull(this Object self) => self != null;

        public static bool IsNull(this Object self, Object debugContext)
        {
            if (self == null) UnityEngine.Debug.Log($"{self.name} was null in {debugContext}", debugContext);
            return self == null;
        }
        public static bool IsNull(this Object self, Object debugContext, string remarks)
        {
            if (self == null) UnityEngine.Debug.Log($"{self.name} was null in {debugContext}:  {remarks}", debugContext);
            return self == null;
        }

        public static bool NotNull(this Object self, Object debugContext)
        {
            if (self != null) UnityEngine.Debug.Log($"{self.name} not null in {debugContext}", debugContext);
            return self != null;
        }
        public static bool NotNull(this Object self, Object debugContext, string remarks)
        {
            if (self != null) UnityEngine.Debug.Log($"{self.name} not null in {debugContext}:  {remarks}", debugContext);
            return self != null;
        }
    }
}
