using System.Collections;
using System.Collections.Generic;
using TirUtilities.Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    ///<!--
    /// SignalReceiver.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  May 02, 2021
    /// Updated:  May 02, 2021
    /// -->
    /// <summary>
    /// Invokes <see cref="_OnSignalReceived">On Signal Received</see> when the <see cref="_signal">Signal</see>
    /// is <see cref="Signal.Emit()">Emitted</see>.
    /// </summary>
    [AddComponentMenu("TirUtilities/Receivers/Signal Receiver")]
    public class SignalReceiver : MonoBehaviour
    {
        #region Events & Signals

        [Header("Signals")]
        [SerializeField] private Signal _signal;

        [Header("Events")]
        [SerializeField] private UnityEvent _OnSignalReceived;

        #endregion

        #region Unity Messages

        private void OnEnable() => _signal.AddReceiver(() => _OnSignalReceived.SafeInvoke());
        private void OnDisable() => _signal.RemoveReceiver(() => _OnSignalReceived.SafeInvoke());

        #endregion
    }
}