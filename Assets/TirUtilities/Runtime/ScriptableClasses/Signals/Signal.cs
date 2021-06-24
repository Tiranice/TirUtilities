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
    /// Created:  Mar. 27, 2021
    /// Updated:  June 15, 2021
    /// -->
    /// <summary>
    /// Holds a UnityAction so that it can be referenced across scenes and assigned in the inspector.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Signal")]
    public class Signal : SignalBase
    {
        #region Actions

        /// <summary>
        /// Invoked in <see cref="Emit">Emit</see>, calling receivers.
        /// </summary>
        [SerializeField]
        private UnityAction _OnEmit;

        #endregion

        #region Public Methods

        /// <summary>
        /// Register a callback function to be invoked when this signal is <see cref="Emit">Emitted</see>.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public virtual void AddReceiver(UnityAction receiver) => _OnEmit += receiver;

        /// <summary>
        /// Unregister a callback function.
        /// </summary>
        /// <param name="receiver">The callback function.</param>
        public virtual void RemoveReceiver(UnityAction receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling their 
        /// <see cref="AddReceiver(UnityAction)">Registered Callbacks</see>.
        /// </summary>
        public virtual void Emit() => _OnEmit.SafeInvoke();

        #endregion
    }
}
