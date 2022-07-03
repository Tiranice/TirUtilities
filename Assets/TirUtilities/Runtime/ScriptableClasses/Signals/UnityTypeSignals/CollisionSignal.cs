using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    using TirUtilities.Extensions;
    ///<!--
    /// CollisionSignal.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Oct 10, 2021
    /// Updated:  Jul 03, 2022
    /// -->
    /// <summary>
    /// A <see cref="Signal"/> that emits a Collision.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Collision Signal", order = 40)]
    public class CollisionSignal : SignalBase<Collision>
    {
        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit(Collision)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public override void AddReceiver(UnityAction<Collision> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public override void RemoveReceiver(UnityAction<Collision> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction{Collision})"/>.
        /// </summary>
        public override void Emit(Collision target) => _OnEmit.SafeInvoke(target);
    }
}