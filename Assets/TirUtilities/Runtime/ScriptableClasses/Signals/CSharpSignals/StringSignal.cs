using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    using TirUtilities.Extensions;
    ///<!--
    /// StringSignal.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Created:  June 15, 2021
    /// Updated:  Sep 22, 2021
    /// -->
    /// <summary>
    /// A <see cref="Signal"/> that emits a string.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/String Signal", order = 20)]
    public class StringSignal : SignalBase<string>, ISignal<string>
    {
        #region Public Methods

        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit(string)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public virtual void AddReceiver(UnityAction<string> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public virtual void RemoveReceiver(UnityAction<string> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction{string})"/>.
        /// </summary>
        public virtual void Emit(string value) => _OnEmit.SafeInvoke(value);

        #endregion
    }
}
