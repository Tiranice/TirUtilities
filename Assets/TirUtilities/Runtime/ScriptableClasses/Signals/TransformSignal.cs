using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    using TirUtilities.Extensions;

    ///<!--
    /// TransformSignal.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  BlackPhoenixSoftware
    /// Created:  Sep 22, 2021
    /// Updated:  Sep 22, 2021
    /// -->
    /// <summary>
    /// A <see cref="Signal"/> that emits a transform.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Transform Signal", order = 12)]
    public class TransformSignal : SignalBase, ISignal<Transform>
    {
        #region Actions

        /// <summary> Invoked in <see cref="Emit(Transform)"/>, calling receivers. </summary>
        [SerializeField] protected UnityAction<Transform> _OnEmit;

        #endregion

        #region Public Methods

        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit(Transform)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public virtual void AddReceiver(UnityAction<Transform> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public virtual void RemoveReceiver(UnityAction<Transform> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction{Transform})"/>.
        /// </summary>
        public virtual void Emit(Transform target) => _OnEmit.SafeInvoke(target);

        #endregion
    }
}