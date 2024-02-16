using System.Collections;
using System.Collections.Generic;

using TirUtilities.CustomEvents;
using TirUtilities.Extensions;

using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    ///<!--
    /// StringSignalReceiver.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Aug 01, 2022
    /// Updated:  Aug 01, 2022
    /// -->
    /// <summary>
    ///
    /// </summary>
    public class StringSignalReceiver : MonoBehaviour
    {
        [SerializeField] private StringSignal _signal;

        [SerializeField] private UnityEvent _OnSignalReceived;
        [SerializeField] private StringEvent _OnStringReceived;

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