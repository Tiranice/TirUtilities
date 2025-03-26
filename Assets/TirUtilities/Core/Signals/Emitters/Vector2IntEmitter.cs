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
///     You should have received a copy of the GNU Lesser General Public License
///     along with this program.  If not, see <https://www.gnu.org/licenses/>.
///-->

namespace TirUtilities.Signals
{
    ///<!--
    /// Vector2IntEmitter.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Mar 26, 2025
    /// Updated:  Mar 26, 2025
    /// -->
    /// <summary>
    /// Emits the given <c>Vector2Int</c> value in the given <see cref="UnityMessage"/>.
    /// </summary>
    public class Vector2IntEmitter : SignalEmitterBase<Vector2IntSignal, Vector2Int>
    {
        [SerializeField] private Vector2Int _value;

        protected override Vector2Int Data => _value;
    }
}