using System.Collections.Generic;

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
    /// ListExtensions.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  May 01, 2021
    /// Updated:  Mar 26, 2025
    /// -->
    /// <summary>
    /// A set of extensions to generic lists.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary> Shorthand for <code>list.Count == 0;</code> </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns>True if the list is empty.</returns>
        public static bool IsEmpty<T>(this List<T> list) => list.Count == 0;

        /// <summary> Shorthand for <code>list.Count > 0;</code> </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns>True if the list contains an number of items</returns>
        public static bool NotEmpty<T>(this List<T> list) => list.Count > 0;

        /// <summary> Shorthand for <code>list.Equals(null);</code>.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns>True if the list is null.</returns>
        public static bool IsNull<T>(this List<T> list) => list == null;

        /// <summary> Shorthand for <code>!list.Equals(null);</code> </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns>True if the list is not null.</returns>
        public static bool NotNull<T>(this List<T> list) => list != null;

        /// <summary> Shorthand for <code>list.IsNull() || list.IsEmpty();</code> </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns>True if the list contains no items or is null.</returns>
        public static bool IsNullOrEmpty<T>(this List<T> list) => list.IsNull() || list.IsEmpty();

        /// <summary> Shorthand for <code>list.NotNull() || list.NotEmpty();</code> </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns>True if the list contains no items or is null.</returns>
        public static bool NotNullOrEmpty<T>(this List<T> list) => list.NotNull() || list.NotEmpty();

        /// <summary> Test whether a given int index is in the range [0, list.Count). </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="i">The index to be tested.</param>
        /// <returns>True if index i is in the range [0, list.Count).</returns>
        public static bool IndexInRange<T>(this List<T> list, int i) => (i >= 0) && (i < list.Count);

        /// <summary> Returns an index shifted by the given amount. </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="current">Index to shift.</param>
        /// <param name="shift">Shift the index by this amount.</param>
        /// <returns>Value between [0, list.Count) - wraps to 0 on overflow</returns>
        public static int NextIndexInRange<T>(this List<T> list, int current, int shift) =>
            list.IndexInRange(current + shift) ? current + shift : 0;
    }
}
