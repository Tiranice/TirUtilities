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
///     You should have received a copy of the GNU General Public License
///     along with this program.  If not, see <https://www.gnu.org/licenses/>.
///-->

namespace TirUtilities.Signals
{
    using TirUtilities.CustomEvents;
    using TirUtilities.Extensions;
    ///<!--
    /// TransformSignalReceiver.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Mar 20, 2025
    /// Updated:  Mar 20, 2025
    /// -->
    /// <summary>
    /// Invokes events upon receiving the <see cref="TransformSignal"/>.
    /// </summary>
    public class TransformSignalReceiver : MonoBehaviour
    {
        [SerializeField] private TransformSignal _signal;
        [Space(20)]
        [SerializeField] private UnityEvent _OnSignalReceived = new();
        [SerializeField] private TransformEvent _OnTransformReceived = new();

        public event System.Action OnSignalReceived;
        public event System.Action<Transform> OnTransformReceived;

        private void OnEnable() => _signal.AddReceiver(Receiver);

        private void OnDisable() => _signal.RemoveReceiver(Receiver);

        private void Receiver(Transform value)
        {
            _OnSignalReceived.SafeInvoke();
            _OnTransformReceived.SafeInvoke(value);
            OnSignalReceived?.Invoke();
            OnTransformReceived?.Invoke(value);
        }
    }
}