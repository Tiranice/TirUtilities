using TirUtilities.Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    ///<!--
    /// FloatSignal.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Created:  June 15, 2021
    /// Updated:  June 15, 2021
    /// -->
    /// <summary>
    /// A <see cref="Signal"/> that emits a float.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Float Signal")]
    public class FloatSignal : SignalBase
    {
        #region Actions

        /// <summary>
        /// Invoked in <see cref="Emit">Emit</see>, calling receivers.
        /// </summary>
        [SerializeField]
        private UnityAction<float> _OnEmit;

        #endregion

        #region Public Methods

        /// <summary>
        /// Register a callback function to be invoked when this signal is <see cref="Emit">Emitted</see>.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public virtual void AddReceiver(UnityAction<float> receiver) => _OnEmit += receiver;

        /// <summary>
        /// Unregister a callback function.
        /// </summary>
        /// <param name="receiver">The callback function.</param>
        public virtual void RemoveReceiver(UnityAction<float> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers registered with 
        /// <see cref="AddReceiver(UnityAction{float})">Add Receiver</see>.
        /// </summary>
        public virtual void Emit(float value) => _OnEmit.SafeInvoke(value);

        #endregion
    }
}