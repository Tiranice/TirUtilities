using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    using TirUtilities.Extensions;
    ///<!--
    /// Vector2IntSignal.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  BlackPhoenixSoftware
    /// Created:  Oct 10, 2021
    /// Updated:  Jul 03, 2022
    /// -->
    /// <summary>
    /// A <see cref="Signal"/> that emits a Vector2Int.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Vector2Int Signal", order = 40)]
    public class Vector2IntSignal : SignalBase<Vector2Int>
    {
        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit(Vector2Int)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public override void AddReceiver(UnityAction<Vector2Int> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public override void RemoveReceiver(UnityAction<Vector2Int> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction{Vector2Int})"/>.
        /// </summary>
        public override void Emit(Vector2Int value) => _OnEmit.SafeInvoke(value);
    }
}