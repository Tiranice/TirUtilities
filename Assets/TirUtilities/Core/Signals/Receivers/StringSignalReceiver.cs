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
    using TirUtilities.CustomEvents;
    using TirUtilities.Extensions;

    ///<!--
    /// StringSignalReceiver.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Aug 01, 2022
    /// Updated:  Mar 26, 2025
    /// -->
    /// <summary>
    /// Invokes <c>OnSignalReceived</c> when the <see cref="StringSignal"/> is emitted.
    /// </summary>
    [AddComponentMenu("TirUtilities/Signal Receivers/String Signal Receiver")]
    public class StringSignalReceiver : SignalReceiverBase<StringSignal, string, StringEvent> { }
}