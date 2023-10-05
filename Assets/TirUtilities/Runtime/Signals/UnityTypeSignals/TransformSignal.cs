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
    /// Company:  Black Phoenix Software
    /// Created:  Sep 22, 2021
    /// Updated:  Jul 03, 2022
    /// -->
    /// <summary>
    /// A <see cref="Signal"/> that emits a transform.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Transform Signal", order = 40)]
    public class TransformSignal : SignalBase<Transform>
    {
        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit(Transform)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public override void AddReceiver(UnityAction<Transform> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public override void RemoveReceiver(UnityAction<Transform> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction{Transform})"/>.
        /// </summary>
        public override void Emit(Transform target) => _OnEmit.SafeInvoke(target);
    }
}