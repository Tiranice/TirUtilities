using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    using TirUtilities.Extensions;
    ///<!--
    /// Collider2DSignal.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Oct 10, 2021
    /// Updated:  Jul 03, 2022
    /// -->
    /// <summary>
    /// A <see cref="Signal"/> that emits a Collider 2D.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Collider 2D Signal", order = 40)]
    public class Collider2DSignal : SignalBase<Collider2D>
    {
        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit(Collider2D)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public override void AddReceiver(UnityAction<Collider2D> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public override void RemoveReceiver(UnityAction<Collider2D> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction{Collider2D})"/>.
        /// </summary>
        public override void Emit(Collider2D target) => _OnEmit.SafeInvoke(target);
    }
}