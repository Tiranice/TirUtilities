using UnityEngine.Events;

namespace TirUtilities.Signals
{
    ///<!--
    /// ISignal.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  BlackPhoenixSoftware
    /// Created:  Sep 22, 2021
    /// Updated:  Sep 22, 2021
    /// -->
    /// <summary> Public interface common to all signals. </summary>
    public interface ISignal
    {
        abstract void AddReceiver(UnityAction receiver);
        abstract void RemoveReceiver(UnityAction receiver);
        abstract void Emit();
    }

    /// <summary> Public interface common to all signals. </summary>
    /// <typeparam name="T0">Type emitted from action.</typeparam>
    public interface ISignal<T0>
    {
        abstract void AddReceiver(UnityAction<T0> receiver);
        abstract void RemoveReceiver(UnityAction<T0> receiver);
        abstract void Emit(T0 target);
    }

    /// <summary> Public interface common to all signals. </summary>
    /// <typeparam name="T0">Type emitted from action.</typeparam>
    /// <typeparam name="T1">Type emitted from action.</typeparam>
    public interface ISignal<T0, T1>
    {
        abstract void AddReceiver(UnityAction<T0, T1> receiver);
        abstract void RemoveReceiver(UnityAction<T0, T1> receiver);
        abstract void Emit(T0 target0, T1 target1);
    }
}