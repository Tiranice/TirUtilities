using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    using TirUtilities.Extensions;
    ///<!--
    /// Collision2DSignal.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Oct 10, 2021
    /// Updated:  Oct 10, 2021
    /// -->
    /// <summary>
    /// A <see cref="Signal"/> that emits a Collision 2D.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Collision 2D Signal", order = 40)]
    public class Collision2DSignal : SignalBase<Collision2D>, ISignal<Collision2D>
    {
        #region Public Methods

        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit(Collision2D)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public virtual void AddReceiver(UnityAction<Collision2D> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public virtual void RemoveReceiver(UnityAction<Collision2D> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction{Collision2D})"/>.
        /// </summary>
        public virtual void Emit(Collision2D target) => _OnEmit.SafeInvoke(target);

        #endregion
    }
}