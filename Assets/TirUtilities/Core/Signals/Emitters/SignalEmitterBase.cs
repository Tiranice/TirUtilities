using UnityEngine;

namespace TirUtilities.Signals
{
    ///<!--
    /// SignalEmitterBase.cs
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
    public abstract class SignalEmitterBase<TSignal> : MonoBehaviour where TSignal : ISignal
    {
        [SerializeField] protected UnityMessage _emitOnMessage = UnityMessage.None;
        [SerializeField] protected TSignal _signal;

        protected virtual void Awake() { if (_emitOnMessage == UnityMessage.Awake) _signal.Emit(); }

        protected virtual void Start() { if (_emitOnMessage == UnityMessage.Start) _signal.Emit(); }

        protected virtual void OnEnable() { if (_emitOnMessage == UnityMessage.OnEnable) _signal.Emit(); }

        protected virtual void Update() { if (_emitOnMessage == UnityMessage.Update) _signal.Emit(); }

        protected virtual void FixedUpdate() { if (_emitOnMessage == UnityMessage.FixedUpdate) _signal.Emit(); }

        protected virtual void LateUpdate() { if (_emitOnMessage == UnityMessage.LateUpdate) _signal.Emit(); }

        protected virtual void OnDisable() { if (_emitOnMessage == UnityMessage.OnDisable) _signal.Emit(); }

        protected virtual void OnDestroy() { if (_emitOnMessage == UnityMessage.OnDestroy) _signal.Emit(); }

    }

    public abstract class SignalEmitterBase<TSignal, TData> : MonoBehaviour where TSignal : ISignal<TData>
    {
        [SerializeField] protected UnityMessage _emitOnMessage = UnityMessage.None;
        [SerializeField] protected TSignal _signal;

        [SerializeField] protected virtual TData Data { get; set; }

        protected virtual void Awake() { if (_emitOnMessage == UnityMessage.Awake) _signal.Emit(Data); }

        protected virtual void Start() { if (_emitOnMessage == UnityMessage.Start) _signal.Emit(Data); }

        protected virtual void OnEnable() { if (_emitOnMessage == UnityMessage.OnEnable) _signal.Emit(Data); }

        protected virtual void Update() { if (_emitOnMessage == UnityMessage.Update) _signal.Emit(Data); }

        protected virtual void FixedUpdate() { if (_emitOnMessage == UnityMessage.FixedUpdate) _signal.Emit(Data); }

        protected virtual void LateUpdate() { if (_emitOnMessage == UnityMessage.LateUpdate) _signal.Emit(Data); }

        protected virtual void OnDisable() { if (_emitOnMessage == UnityMessage.OnDisable) _signal.Emit(Data); }

        protected virtual void OnDestroy() { if (_emitOnMessage == UnityMessage.OnDestroy) _signal.Emit(Data); }
    }
}