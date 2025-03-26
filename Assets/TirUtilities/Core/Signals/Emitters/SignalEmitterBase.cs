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

        protected virtual void EmitSignal() => _signal.Emit();

        protected virtual void Awake() { if (_emitOnMessage == UnityMessage.Awake) EmitSignal(); }

        protected virtual void Start() { if (_emitOnMessage == UnityMessage.Start) EmitSignal(); }

        protected virtual void OnEnable() { if (_emitOnMessage == UnityMessage.OnEnable) EmitSignal(); }

        protected virtual void Update() { if (_emitOnMessage == UnityMessage.Update) EmitSignal(); }

        protected virtual void FixedUpdate() { if (_emitOnMessage == UnityMessage.FixedUpdate) EmitSignal(); }

        protected virtual void LateUpdate() { if (_emitOnMessage == UnityMessage.LateUpdate) EmitSignal (); }

        protected virtual void OnDisable() { if (_emitOnMessage == UnityMessage.OnDisable) EmitSignal(); }

        protected virtual void OnDestroy() { if (_emitOnMessage == UnityMessage.OnDestroy) EmitSignal(); }

    }

    public abstract class SignalEmitterBase<TSignal, TData> : MonoBehaviour where TSignal : ISignal<TData>
    {
        [SerializeField] protected UnityMessage _emitOnMessage = UnityMessage.None;
        [SerializeField] protected TSignal _signal;

        [SerializeField] protected virtual TData Data { get; set; }

        protected virtual void EmitSignal() => _signal.Emit(Data);

        protected virtual void Awake() { if (_emitOnMessage == UnityMessage.Awake) EmitSignal(); }

        protected virtual void Start() { if (_emitOnMessage == UnityMessage.Start) EmitSignal(); }

        protected virtual void OnEnable() { if (_emitOnMessage == UnityMessage.OnEnable) EmitSignal(); }

        protected virtual void Update() { if (_emitOnMessage == UnityMessage.Update) EmitSignal(); }

        protected virtual void FixedUpdate() { if (_emitOnMessage == UnityMessage.FixedUpdate) EmitSignal(); }

        protected virtual void LateUpdate() { if (_emitOnMessage == UnityMessage.LateUpdate) EmitSignal(); }

        protected virtual void OnDisable() { if (_emitOnMessage == UnityMessage.OnDisable) EmitSignal(); }

        protected virtual void OnDestroy() { if (_emitOnMessage == UnityMessage.OnDestroy) EmitSignal(); }
    }
}