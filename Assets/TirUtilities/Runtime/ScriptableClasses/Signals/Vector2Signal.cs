using TirUtilities.Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    ///<!--
    /// Vector2Signal.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  BlackPhoenixSoftware
    /// Created:  Oct 01, 2021
    /// Updated:  Oct 01, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Vector2 Signal", order = 12)]
    public class Vector2Signal : SignalBase, ISignal<Vector2>
    {
        #region Actions

        /// <summary> Invoked in <see cref="Emit(Vector2)"/>, calling receivers. </summary>
        [SerializeField] protected UnityAction<Vector2> _OnEmit;

        #endregion

        #region Public Methods

        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit(Vector2)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public virtual void AddReceiver(UnityAction<Vector2> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public virtual void RemoveReceiver(UnityAction<Vector2> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction{Vector2})"/>.
        /// </summary>
        public virtual void Emit(Vector2 value) => _OnEmit.SafeInvoke(value);

        #endregion
    }
}