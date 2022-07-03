using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    using TirUtilities.Extensions;
    ///<!--
    /// Vector4Signal.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  BlackPhoenixSoftware
    /// Created:  Oct 10, 2021
    /// Updated:  Jul 03, 2022
    /// -->
    /// <summary>
    /// A <see cref="Signal"/> that emits a Vector4.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Vector4 Signal", order = 40)]
    public class Vector4Signal : SignalBase<Vector4>
    {
        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit(Vector4)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public override void AddReceiver(UnityAction<Vector4> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public override void RemoveReceiver(UnityAction<Vector4> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction{Vector4})"/>.
        /// </summary>
        public override void Emit(Vector4 value) => _OnEmit.SafeInvoke(value);
    }
}