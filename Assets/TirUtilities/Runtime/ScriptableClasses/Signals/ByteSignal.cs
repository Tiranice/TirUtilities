using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    using TirUtilities.Extensions;
    ///<!--
    /// Signal.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Created:  June 15, 2021
    /// Updated:  June 15, 2021
    /// -->
    /// <summary>
    /// A <see cref="Signal"/> that emits a byte.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Byte Signal")]
    public class ByteSignal : SignalBase, ISignal<byte>
    {
        #region Actions

        /// <summary>
        /// Invoked in <see cref="Emit(byte)"/>, calling receivers.
        /// </summary>
        [SerializeField]
        protected UnityAction<byte> _OnEmit;

        #endregion

        #region Public Methods

        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit(byte)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public virtual void AddReceiver(UnityAction<byte> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public virtual void RemoveReceiver(UnityAction<byte> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction{byte})"/>.
        /// </summary>
        public virtual void Emit(byte value) => _OnEmit.SafeInvoke(value);

        #endregion
    }
}
