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
    /// SignalReceiver.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  May 02, 2021
    /// Updated:  Mar 26, 2025
    /// -->
    /// <summary>
    /// Invokes <see cref="_OnSignalReceived">On Signal Received</see> when the 
    /// <see cref="_signal">Signal</see> is <see cref="Signal.Emit()">Emitted</see>.
    /// </summary>
    [AddComponentMenu("TirUtilities/Receivers/Signal Receiver")]
    public class SignalReceiver : SignalReceiverBase<Signal> { }
}