using TirUtilities.Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    ///<!--
    /// GameObjectSignal.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Created:  Mar. 27, 2021
    /// Updated:  June 15, 2021
    /// -->
    /// <summary>
    /// A <see cref="Signal"/> that emits a bool.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Bool Signal")]
    public class BoolSignal : SignalBase
    {
        #region Actions

        /// <summary>
        /// Invoked in <see cref="Emit">Emit</see>, calling receivers.
        /// </summary>
        [SerializeField]
        private UnityAction<bool> _OnEmit;

        #endregion

        #region Public Methods

        /// <summary>
        /// Register a callback function to be invoked when this signal is <see cref="Emit">Emitted</see>.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public virtual void AddReceiver(UnityAction<bool> receiver) =>_OnEmit += receiver;

        /// <summary>
        /// Register a callback function.
        /// </summary>
        /// <param name="receiver">The callback function.</param>
        public virtual void RemoveReceiver(UnityAction<bool> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling their 
        /// <see cref="AddReceiver(UnityAction{bool})">Registered Callbacks</see>.
        /// </summary>
        public virtual void Emit(bool value) => _OnEmit.SafeInvoke(value);

        #endregion
    }
}
