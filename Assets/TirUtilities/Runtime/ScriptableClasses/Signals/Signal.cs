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
    /// Created:  Mar 27, 2021
    /// Updated:  Sep 22, 2021
    /// -->
    /// <summary>
    /// Holds a UnityAction so that it can be referenced across scenes and assigned in the inspector.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Signal")]
    public class Signal : SignalBase, ISignal
    {
        #region Actions

        /// <summary> Invoked in <see cref="Emit"/>, calling receivers. </summary>
        [SerializeField] protected UnityAction _OnEmit;

        #endregion

        #region Public Methods

        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public virtual void AddReceiver(UnityAction receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public virtual void RemoveReceiver(UnityAction receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction)"/>.
        /// </summary>
        public virtual void Emit() => _OnEmit.SafeInvoke();

        #endregion
    }
}
