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
    /// Created:  Mar. 27, 2021
    /// Updated:  May 19, 2021
    /// -->
    /// <summary>
    /// A <see cref="Signal"/> that emits a game object.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Game Object Signal")]
    public class GameObjectSignal : SignalBase
    {
        #region Actions

        /// <summary>
        /// Invoked in <see cref="Emit">Emit</see>, calling receivers.
        /// </summary>
        [SerializeField]
        private UnityAction<GameObject> _OnEmit;

        #endregion

        #region Public Methods

        /// <summary>
        /// Register a callback function to be invoked when this signal is <see cref="Emit">Emitted</see>.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public virtual void AddReceiver(UnityAction<GameObject> receiver) => _OnEmit += receiver;

        /// <summary>
        /// Register a callback function.
        /// </summary>
        /// <param name="receiver">The callback function.</param>
        public virtual void RemoveReceiver(UnityAction<GameObject> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling their 
        /// <see cref="AddReceiver(UnityAction{GameObject})">Registered Callbacks</see>.
        /// </summary>
        public virtual void Emit(GameObject target) => _OnEmit.SafeInvoke(target);

        #endregion
    }
}
