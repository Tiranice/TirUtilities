using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    using TirUtilities.Extensions;
    ///<!--
    /// Vector2Signal.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  BlackPhoenixSoftware
    /// Created:  Oct 01, 2021
    /// Updated:  Jul 03, 2022
    /// -->
    /// <summary>
    /// A <see cref="Signal"/> that emits a Vector2.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Vector2 Signal", order = 40)]
    public class Vector2Signal : SignalBase<Vector2>
    {
        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit(Vector2)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public override void AddReceiver(UnityAction<Vector2> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public override void RemoveReceiver(UnityAction<Vector2> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction{Vector2})"/>.
        /// </summary>
        public override void Emit(Vector2 value) => _OnEmit.SafeInvoke(value);
    }
}