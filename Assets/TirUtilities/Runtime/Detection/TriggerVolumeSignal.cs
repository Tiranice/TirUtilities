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
    /// TriggerVolumeSignal.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Oct 10, 2021
    /// Updated:  Jul 03, 2022
    /// -->
    /// <summary>
    /// Signal that emits the entered state and target game object sent from a 
    /// <see cref="Detection.TriggerVolume"/>.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Trigger Volume Signal", order = 60)]
    public class TriggerVolumeSignal : SignalBase<bool, GameObject>
    {
        /// <summary>
        /// Register a callback to be invoked when <see cref="Emit(bool, GameObject)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public override void AddReceiver(UnityAction<bool, GameObject> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public override void RemoveReceiver(UnityAction<bool, GameObject> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with
        /// <see cref="AddReceiver(UnityAction{bool, GameObject})"/>.
        /// </summary>
        /// <param name="entered"></param>
        /// <param name="target"></param>
        public override void Emit(bool entered, GameObject target) => _OnEmit.SafeInvoke(entered, target);
    }
}