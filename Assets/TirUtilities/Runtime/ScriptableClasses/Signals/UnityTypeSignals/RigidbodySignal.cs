using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    using TirUtilities.Extensions;
    ///<!--
    /// RigidbodySignal.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Oct 10, 2021
    /// Updated:  Oct 10, 2021
    /// -->
    /// <summary>
    /// A <see cref="Signal"/> that emits a Rigidbody.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Rigidbody Signal", order = 40)]
    public class RigidbodySignal : SignalBase<Rigidbody>, ISignal<Rigidbody>
    {
        
        #region Public Methods

        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit(Rigidbody)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public virtual void AddReceiver(UnityAction<Rigidbody> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public virtual void RemoveReceiver(UnityAction<Rigidbody> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction{Rigidbody})"/>.
        /// </summary>
        public virtual void Emit(Rigidbody target) => _OnEmit.SafeInvoke(target);

        #endregion    
    }
}