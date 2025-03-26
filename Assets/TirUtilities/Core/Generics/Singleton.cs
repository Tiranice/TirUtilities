using System;

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

namespace TirUtilities.Experimental
{
    ///<!--
    /// Singleton.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  May 15, 2021
    /// Updated:  May 15, 2021
    /// -->
    /// <summary>
    /// This is intended only as an example. DO NOT USE!!!
    /// </summary>
    public sealed class Singleton
    {
        #region Singleton Instance

        private static readonly Lazy<Singleton> _Lazy = new(() => new Singleton());

        public static Singleton Instance { get => _Lazy.Value; }

        public static bool Exists { get => _Lazy.IsValueCreated; }

        #endregion

        #region Constructor

        private Singleton() { }

        #endregion
    }
}