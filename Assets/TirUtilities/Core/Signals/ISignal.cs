using UnityEngine.Events;

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
    /// ISignal.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Sep 22, 2021
    /// Updated:  Jul 03, 2022
    /// -->
    /// <summary> Public interface common to all signals. </summary>
    public interface ISignal
    {
#if UNITY_2020_2_OR_NEWER
        abstract void AddReceiver(UnityAction receiver);
        abstract void RemoveReceiver(UnityAction receiver);
        abstract void Emit(); 
#else
        void AddReceiver(UnityAction receiver);
        void RemoveReceiver(UnityAction receiver);
        void Emit();
#endif
    }

    /// <summary> Public interface common to all signals. </summary>
    /// <typeparam name="T0">Type emitted from action.</typeparam>
    public interface ISignal<T0>
    {
#if UNITY_2020_2_OR_NEWER
        abstract void AddReceiver(UnityAction<T0> receiver);
        abstract void RemoveReceiver(UnityAction<T0> receiver);
        abstract void Emit(T0 target0); 
#else
        void AddReceiver(UnityAction<T0> receiver);
        void RemoveReceiver(UnityAction<T0> receiver);
        void Emit(T0 target0);
#endif
    }

    /// <summary> Public interface common to all signals. </summary>
    /// <typeparam name="T0">Type emitted from action.</typeparam>
    /// <typeparam name="T1">Type emitted from action.</typeparam>
    public interface ISignal<T0, T1>
    {
#if UNITY_2020_2_OR_NEWER

        abstract void AddReceiver(UnityAction<T0, T1> receiver);
        abstract void RemoveReceiver(UnityAction<T0, T1> receiver);
        abstract void Emit(T0 target0, T1 target1);
#else
        void AddReceiver(UnityAction<T0, T1> receiver);
        void RemoveReceiver(UnityAction<T0, T1> receiver);
        void Emit(T0 target0, T1 target1);
#endif
    }

    /// <summary> Public interface common to all signals. </summary>
    /// <typeparam name="T0">Type emitted from action.</typeparam>
    /// <typeparam name="T1">Type emitted from action.</typeparam>
    /// <typeparam name="T2">Type emitted from action.</typeparam>
    public interface ISignal<T0, T1, T2>
    {
#if UNITY_2020_2_OR_NEWER

        abstract void AddReceiver(UnityAction<T0, T1, T2> receiver);
        abstract void RemoveReceiver(UnityAction<T0, T1, T2> receiver);
        abstract void Emit(T0 target0, T1 target1, T2 target2);
#else
        void AddReceiver(UnityAction<T0, T1, T2> receiver);
        void RemoveReceiver(UnityAction<T0, T1, T2> receiver);
        void Emit(T0 target0, T1 target1, T2 target2);
#endif
    }
}