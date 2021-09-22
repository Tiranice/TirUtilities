using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    using TirUtilities.Extensions;
    ///<!--
    /// BoolSignal.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Company:  BlackPhoenixSoftware
    /// Created:  Mar 27, 2021
    /// Updated:  Sep 22, 2021
    /// -->
    /// <summary>
    /// A <see cref="Signal"/> that emits a bool.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Bool Signal")]
    public class BoolSignal : SignalBase, ISignal<bool>
    {
        #region Actions

        /// <summary> Invoked in <see cref="Emit(bool)"/>, calling receivers. </summary>
        [SerializeField] protected UnityAction<bool> _OnEmit;

        #endregion

        #region Public Methods

        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit(bool)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public virtual void AddReceiver(UnityAction<bool> receiver) =>_OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public virtual void RemoveReceiver(UnityAction<bool> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction{bool})"/>.
        /// </summary>
        public virtual void Emit(bool value) => _OnEmit.SafeInvoke(value);

        #endregion
    }
}
