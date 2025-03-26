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
    /// SignalReceiverBase.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Mar 26, 2025
    /// Updated:  Mar 26, 2025
    /// -->
    /// <summary>
    /// Base class for all signal receiver <c>MonoBehaviours</c>.
    /// <para>
    /// See <seealso cref="StringSignalReceiver"/> for an example implementation.
    /// </para>
    /// </summary>
    public abstract class SignalReceiverBase<TSignal> : MonoBehaviour where TSignal : ISignal
    {
        [SerializeField] protected TSignal _signal;
        [Space(20)]
        [SerializeField] protected UnityEvent _OnSignalReceived = new();

        public event System.Action OnSignalReceived;

        protected virtual void OnEnable() => _signal.AddReceiver(Receiver);
        protected virtual void OnDisable() => _signal.RemoveReceiver(Receiver);

        /// <summary>
        /// You must call <c>base.Receiver(value)</c> from override method.
        /// </summary>
        /// <param name="data"></param>
        protected virtual void Receiver()
        {
            _OnSignalReceived.SafeInvoke();
            OnSignalReceived?.Invoke();
        }
    }

    public abstract class SignalReceiverBase<TSignal, TData, TEvent> : MonoBehaviour 
        where TSignal : ISignal<TData> where TEvent : UnityEvent<TData>
    {
        [SerializeField] protected TSignal _signal;
        [Space(20)]
        [SerializeField] protected UnityEvent _OnSignalReceived = new();
        [SerializeField] protected TEvent _OnDataReceived;

        public event System.Action OnSignalReceived;
        public event System.Action<TData> OnDataReceived;

        protected virtual void OnEnable() => _signal.AddReceiver(Receiver);

        protected virtual void OnDisable() => _signal.RemoveReceiver(Receiver);

        /// <summary>
        /// You must call <c>base.Receiver(value)</c> from override method.
        /// </summary>
        /// <param name="data"></param>
        protected virtual void Receiver(TData data = default)
        {
            _OnSignalReceived.SafeInvoke();
            _OnDataReceived.SafeInvoke(data);
            OnSignalReceived?.Invoke();
            OnDataReceived?.Invoke(data);
        }
    }
}