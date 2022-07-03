using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    using TirUtilities.Extensions;
    ///<!--
    /// FloatSignal.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Jun 15, 2021
    /// Updated:  Jul 03, 2022
    /// -->
    /// <summary>
    /// A <see cref="Signal"/> that emits a float.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Float Signal", order = 20)]
    public class FloatSignal : SignalBase<float>
    {
        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit(float)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public override void AddReceiver(UnityAction<float> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public override void RemoveReceiver(UnityAction<float> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction{float})"/>.
        /// </summary>
        public override void Emit(float value) => _OnEmit.SafeInvoke(value);
    }
}
