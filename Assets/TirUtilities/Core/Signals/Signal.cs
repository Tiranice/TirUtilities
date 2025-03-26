using UnityEngine;
using UnityEngine.Events;

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
    using TirUtilities.Extensions;
    ///<!--
    /// Signal.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Mar 27, 2021
    /// Updated:  Jul 03, 2022
    /// -->
    /// <summary>
    /// Holds a UnityAction so that it can be referenced across scenes and assigned in the inspector.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Signal", order = 0)]
    public class Signal : SignalBase
    {
        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public override void AddReceiver(UnityAction receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public override void RemoveReceiver(UnityAction receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction)"/>.
        /// </summary>
        public override void Emit() => _OnEmit.SafeInvoke();
    }

    /// <summary>
    /// I don't know if this works, but I'mma find out!
    /// </summary>
    public static class SignalExtensions
    {
        //TODO:  See if these work.
        public static bool TryAddReceiver(this Signal self, UnityAction receiver)
        {
            if (self == null) return false;
            self.AddReceiver(receiver);
            return true;
        }

        public static bool TryRemoveReceiver(this Signal self, UnityAction receiver)
        {
            if (self == null) return false;
            self.RemoveReceiver(receiver);
            return true;
        }
    }
}
