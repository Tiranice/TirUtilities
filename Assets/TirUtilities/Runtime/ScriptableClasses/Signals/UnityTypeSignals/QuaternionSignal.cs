using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    using TirUtilities.Extensions;
    ///<!--
    /// QuaternionSignal.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Oct 10, 2021
    /// Updated:  Jul 03, 2022
    /// -->
    /// <summary>
    /// A <see cref="Signal"/> that emits a Quaternion.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Quaternion Signal", order = 40)]
    public class QuaternionSignal : SignalBase<Quaternion>
    {
        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit(Quaternion)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public override void AddReceiver(UnityAction<Quaternion> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public override void RemoveReceiver(UnityAction<Quaternion> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction{Quaternion})"/>.
        /// </summary>
        public override void Emit(Quaternion target) => _OnEmit.SafeInvoke(target);
    }
}