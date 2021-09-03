using TirUtilities.Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
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
    /// Holds a UnityAction so that it can be referenced across scenes and assigned in the inspector.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Byte Signal")]
    public class ByteSignal : SignalBase
    {
        #region Actions

        /// <summary>
        /// Invoked in <see cref="Emit">Emit</see>, calling receivers.
        /// </summary>
        [SerializeField]
        protected UnityAction<byte> _OnEmit;

        #endregion

        #region Public Methods

        /// <summary>
        /// Register a callback function to be invoked when this signal is <see cref="Emit">Emitted</see>.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public virtual void AddReceiver(UnityAction<byte> receiver) => _OnEmit += receiver;

        /// <summary>
        /// Unregister a callback function.
        /// </summary>
        /// <param name="receiver">The callback function.</param>
        public virtual void RemoveReceiver(UnityAction<byte> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers registered with 
        /// <see cref="AddReceiver(UnityAction{byte})">Add Receiver</see>.
        /// </summary>
        public virtual void Emit(byte value) => _OnEmit.SafeInvoke(value);

        #endregion
    }
}
