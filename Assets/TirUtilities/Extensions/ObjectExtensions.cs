using Object = UnityEngine.Object;

namespace TirUtilities.Extensions
{
    ///<!--
    /// ObjectExtensions.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  May 01, 2021
    /// Updated:  May 28, 2021
    /// -->
    /// <summary>
    /// A set of extensions to UnityEngine.Object.
    /// </summary>
    public static class ObjectExtensions
    {
        public static bool IsNull(this Object self) => self == null;
        public static bool NotNull(this Object self) => self != null;
    }
}
