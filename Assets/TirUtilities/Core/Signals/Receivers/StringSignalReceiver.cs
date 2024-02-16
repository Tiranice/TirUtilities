using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    using TirUtilities.CustomEvents;
    using TirUtilities.Extensions;

    ///<!--
    /// StringSignalReceiver.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Aug 01, 2022
    /// Updated:  Feb 16, 2024
    /// -->
    /// <summary>
    /// Invokes <c>OnSignalReceived</c> when the <see cref="StringSignal"/> is emitted.
    /// </summary>
    [AddComponentMenu("TirUtilities/Signal Receivers/String Signal Receiver")]
    public class StringSignalReceiver : MonoBehaviour
    {
        [SerializeField] private StringSignal _signal;

        [SerializeField] private UnityEvent _OnSignalReceived = new UnityEvent();
        [SerializeField] private StringEvent _OnStringReceived = new StringEvent();

        public event System.Action OnSignalReceived;
        public event System.Action<string> OnStringReceived;

        private void OnEnable() => _signal.AddReceiver(Receiver);

        private void OnDisable() => _signal.RemoveReceiver(Receiver);

        private void Receiver(string value)
        {
            _OnSignalReceived.SafeInvoke();
            _OnStringReceived.SafeInvoke(value);
            OnSignalReceived?.Invoke();
            OnStringReceived?.Invoke(value);
        }
    }
}