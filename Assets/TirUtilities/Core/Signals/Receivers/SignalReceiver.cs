using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    using TirUtilities.Extensions;
    ///<!--
    /// SignalReceiver.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  May 02, 2021
    /// Updated:  Feb 16, 2024
    /// -->
    /// <summary>
    /// Invokes <see cref="_OnSignalReceived">On Signal Received</see> when the 
    /// <see cref="_signal">Signal</see> is <see cref="Signal.Emit()">Emitted</see>.
    /// </summary>
    [AddComponentMenu("TirUtilities/Receivers/Signal Receiver")]
    public class SignalReceiver : MonoBehaviour
    {
        [Header("Signals")]
        [SerializeField] private Signal _signal;

        [Header("Events")]
        [SerializeField] private UnityEvent _OnSignalReceived;

        public event System.Action OnSignalReceived;

        private void OnEnable() => _signal.AddReceiver(Receiver);
        private void OnDisable() => _signal.RemoveReceiver(Receiver);

        private void Receiver()
        {
            _OnSignalReceived.SafeInvoke();
            OnSignalReceived?.Invoke();
        }
    }
}