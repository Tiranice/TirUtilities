using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    using TirUtilities.Extensions;
    ///<!--
    /// Vector3Signal.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  BlackPhoenixSoftware
    /// Created:  Oct 10, 2021
    /// Updated:  Oct 10, 2021
    /// -->
    /// <summary>
    /// A <see cref="Signal"/> that emits a Vector3.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Vector3 Signal", order = 40)]
    public class Vector3Signal : SignalBase<Vector3>, ISignal<Vector3>
    {
        #region Public Methods

        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit(Vector3)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public virtual void AddReceiver(UnityAction<Vector3> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public virtual void RemoveReceiver(UnityAction<Vector3> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction{Vector3})"/>.
        /// </summary>
        public virtual void Emit(Vector3 value) => _OnEmit.SafeInvoke(value);

        #endregion
    }
}