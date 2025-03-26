using UnityEngine;

///<!--
///     Copyright (C) 2025  Devon Wilson
///
///     This program is free software: you can redistribute it and/or modify
///     it under the terms of the GNU Lesser General Public License as published
///     by the Free Software Foundation, either version 3 of the License, or
///     (at your option) any later version.
///
///     This program is distributed in the hope that it will be useful,
///     but WITHOUT ANY WARRANTY; without even the implied warranty of
///     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
///     GNU Lesser General Public License for more details.
///
///     You should have received a copy of the GNU Lesser General Public License
///     along with this program.  If not, see <https://www.gnu.org/licenses/>.
///-->

namespace TirUtilities.Signals
{
    ///<!--
    /// SignalEmitterBase.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Aug 01, 2022
    /// Updated:  Mar 26, 2025
    /// -->
    /// <summary>
    /// Base class for signal emitters.  These emit the given signal when the given <see cref="UnityMessage"/>
    /// is called.
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