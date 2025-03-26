using Object = UnityEngine.Object;
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
///     You should have received a copy of the GNU General Public License
///     along with this program.  If not, see <https://www.gnu.org/licenses/>.
///-->

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
    /// Updated:  Mar 26, 2025
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
            if (self == null) Debug.Log($"<color=orange>Null in {debugContext}</color>", debugContext);
            return self == null;
        }
        public static bool IsNull(this Object self, Object debugContext, string remarks)
        {
            if (self == null) Debug.Log($"<color=orange>Null in {debugContext}:</color>  {remarks}", debugContext);
            return self == null;
        }

        public static bool NotNull(this Object self, Object debugContext)
        {
            if (self != null) Debug.Log($"<color=green>{self.name}</color> not null in <color=lime>{debugContext}</color>", debugContext);
            return self != null;
        }
        public static bool NotNull(this Object self, Object debugContext, string remarks)
        {
            if (self != null) Debug.Log($"<color=green>{self.name}</color> not null in <color=lime>{debugContext}</color>:  {remarks}", debugContext);
            return self != null;
        }
    }
}
