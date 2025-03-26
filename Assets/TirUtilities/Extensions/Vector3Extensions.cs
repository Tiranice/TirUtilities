using UnityEngine;

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
    /// Vector3Extensions.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  May 01, 2021
    /// Updated:  Oct 01, 2021
    /// -->
    /// <summary>
    /// Extension methods for <see cref="Vector3"/>.
    /// </summary>
    public static class Vector3Extensions
    {
        public static bool IsZero(this Vector3 self) => self == Vector3.zero;
        public static bool NotZero(this Vector3 self) => self != Vector3.zero;
        public static bool Invariant(this Vector3 self) =>
            Mathf.Approximately(self.x, self.y) && Mathf.Approximately(self.y, self.z);
        public static Vector3 Abs(this Vector3 self) =>
            new (Mathf.Abs(self.x), Mathf.Abs(self.y), Mathf.Abs(self.z));
    }
}
