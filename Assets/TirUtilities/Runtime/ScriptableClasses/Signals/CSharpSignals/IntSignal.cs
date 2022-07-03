using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    using TirUtilities.Extensions;
    ///<!--
    /// IntSignal.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Jun 15, 2021
    /// Updated:  Jul 03, 2022
    /// -->
    /// <summary>
    /// A <see cref="Signal"/> that emits an int.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Int Signal", order = 20)]
    public class IntSignal : SignalBase<int>
    {
        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit(int)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public override void AddReceiver(UnityAction<int> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public override void RemoveReceiver(UnityAction<int> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction{int})"/>.
        /// </summary>
        public override void Emit(int value) => _OnEmit.SafeInvoke(value);
    }
}
