using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    using TirUtilities.Extensions;
    ///<!--
    /// Rigidbody2DSignal.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Oct 10, 2021
    /// Updated:  Oct 10, 2021
    /// -->
    /// <summary>
    /// A <see cref="Signal"/> that emits a Rigidbody2D.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Rigidbody2D Signal", order = 40)]
    public class Rigidbody2DSignal : SignalBase<Rigidbody2D>, ISignal<Rigidbody2D>
    {
        #region Public Methods

        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit(Rigidbody2D)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public virtual void AddReceiver(UnityAction<Rigidbody2D> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public virtual void RemoveReceiver(UnityAction<Rigidbody2D> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction{Rigidbody2D})"/>.
        /// </summary>
        public virtual void Emit(Rigidbody2D target) => _OnEmit.SafeInvoke(target);

        #endregion    
    }
}