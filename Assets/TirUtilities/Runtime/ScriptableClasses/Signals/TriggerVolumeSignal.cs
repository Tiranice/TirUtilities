using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    using TirUtilities.Extensions;
    ///<!--
    /// TriggerVolumeSignal.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Oct 10, 2021
    /// Updated:  Oct 10, 2021
    /// -->
    /// <summary>
    /// Signal that emits the entered state and target game object sent from a 
    /// <see cref="Detection.TriggerVolume"/>.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Trigger Volume Signal", order = 60)]
    public class TriggerVolumeSignal : SignalBase<bool, GameObject>, ISignal<bool, GameObject>
    {
        /// <summary>
        /// Register a callback to be invoked when <see cref="Emit(bool, GameObject)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public void AddReceiver(UnityAction<bool, GameObject> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public void RemoveReceiver(UnityAction<bool, GameObject> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with
        /// <see cref="AddReceiver(UnityAction{bool, GameObject})"/>.
        /// </summary>
        /// <param name="entered"></param>
        /// <param name="target"></param>
        public void Emit(bool entered, GameObject target) => _OnEmit.SafeInvoke(entered, target);
    }
}