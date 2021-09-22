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
    /// Updated:  Sep 22, 2021
    /// -->
    /// <summary>
    /// A <see cref="Signal"/> that emits a game object.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Game Object Signal", order = 11)]
    public class GameObjectSignal : SignalBase
    {
        #region Actions

        /// <summary>
        /// Invoked in <see cref="Emit(GameObject)"/>, calling receivers.
        /// </summary>
        [SerializeField]
        protected UnityAction<GameObject> _OnEmit;

        #endregion

        #region Public Methods

        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit(GameObject)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public virtual void AddReceiver(UnityAction<GameObject> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public virtual void RemoveReceiver(UnityAction<GameObject> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction{GameObject})"/>.
        /// </summary>
        public virtual void Emit(GameObject target) => _OnEmit.SafeInvoke(target);

        #endregion
    }
}
