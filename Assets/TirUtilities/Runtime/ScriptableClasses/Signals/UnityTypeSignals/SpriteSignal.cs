using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    using TirUtilities.Extensions;
    ///<!--
    /// SpriteSignal.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Oct 10, 2021
    /// Updated:  Jul 03, 2022
    /// -->
    /// <summary>
    /// A <see cref="Signal"/> that emits a Sprite.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Sprite Signal", order = 40)]
    public class SpriteSignal : SignalBase<Sprite>
    {
        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit(Sprite)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public override void AddReceiver(UnityAction<Sprite> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public override void RemoveReceiver(UnityAction<Sprite> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction{Sprite})"/>.
        /// </summary>
        public override void Emit(Sprite target) => _OnEmit.SafeInvoke(target);
    }
}