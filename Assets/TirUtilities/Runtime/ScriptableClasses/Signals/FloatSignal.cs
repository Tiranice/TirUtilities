using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    using TirUtilities.Extensions;
    ///<!--
    /// FloatSignal.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Created:  Jun 15, 2021
    /// Updated:  Sep 22, 2021
    /// -->
    /// <summary>
    /// A <see cref="Signal"/> that emits a float.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Float Signal")]
    public class FloatSignal : SignalBase, ISignal<float>
    {
        #region Actions

        /// <summary>
        /// Invoked in <see cref="Emit(float)"/>, calling receivers.
        /// </summary>
        [SerializeField]
        protected UnityAction<float> _OnEmit;

        #endregion

        #region Public Methods

        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit(float)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public virtual void AddReceiver(UnityAction<float> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public virtual void RemoveReceiver(UnityAction<float> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction{float})"/>.
        /// </summary>
        public virtual void Emit(float value) => _OnEmit.SafeInvoke(value);

        #endregion
    }
}
