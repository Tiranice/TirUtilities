using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    using TirUtilities.Extensions;
    ///<!--
    /// GameObjectSignal.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Mar 27, 2021
    /// Updated:  Jul 03, 2022
    /// -->
    /// <summary>
    /// A <see cref="Signal"/> that emits a game object.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Game Object Signal", order = 40)]
    public class GameObjectSignal : SignalBase<GameObject>
    {
        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit(GameObject)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public override void AddReceiver(UnityAction<GameObject> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public override void RemoveReceiver(UnityAction<GameObject> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction{GameObject})"/>.
        /// </summary>
        public override void Emit(GameObject target) => _OnEmit.SafeInvoke(target);
    }
}
