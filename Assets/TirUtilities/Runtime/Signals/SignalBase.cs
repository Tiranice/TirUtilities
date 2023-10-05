using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Signals
{
    ///<!--
    /// SignalBase.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Jun 15, 2021
    /// Updated:  Jul 03, 2022
    /// -->
    /// <summary>
    /// Base type for all signals.
    /// </summary>
    public abstract class SignalBase : ScriptableObject, ISignal
    {
        #region Inspector Fields

        /// <summary>
        /// The description of what this signal is intended to be used for.
        /// </summary>
        [Tooltip("The description of what this signal is intended to be used for.")]
        [TextArea, SerializeField] protected string _description = string.Empty;

        /// <summary>
        /// The description of what this signal is intended to be used for.
        /// </summary>
        public string Description => _description;

        #endregion

        #region Emission

        /// <summary> Invoked in <c>Emit</c>, calling receivers. </summary>
        [SerializeField] protected UnityAction _OnEmit;

        public abstract void AddReceiver(UnityAction receiver);
        public abstract void RemoveReceiver(UnityAction receiver);
        public abstract void Emit();

        #endregion
    }

    /// <summary>
    /// Base type for all signals.
    /// </summary>
    public abstract class SignalBase<T0> : ScriptableObject, ISignal<T0>
    {
        #region Inspector Fields

        /// <summary>
        /// The description of what this signal is intended to be used for.
        /// </summary>
        [Tooltip("The description of what this signal is intended to be used for.")]
        [TextArea, SerializeField] protected string _description = string.Empty;

        /// <summary>
        /// The description of what this signal is intended to be used for.
        /// </summary>
        public string Description => _description;

        #endregion

        #region Emission

        /// <summary> Invoked in <c>Emit(T0)</c>, calling receivers. </summary>
        [SerializeField] protected UnityAction<T0> _OnEmit;

        public abstract void AddReceiver(UnityAction<T0> receiver);
        public abstract void RemoveReceiver(UnityAction<T0> receiver);
        public abstract void Emit(T0 target0);

        #endregion
    }

    /// <summary>
    /// Base type for all signals.
    /// </summary>
    public abstract class SignalBase<T0, T1> : ScriptableObject, ISignal<T0, T1>
    {
        #region Inspector Fields

        /// <summary>
        /// The description of what this signal is intended to be used for.
        /// </summary>
        [Tooltip("The description of what this signal is intended to be used for.")]
        [TextArea, SerializeField] protected string _description = string.Empty;

        /// <summary>
        /// The description of what this signal is intended to be used for.
        /// </summary>
        public string Description => _description;

        #endregion

        #region Emission

        /// <summary> Invoked in <c>Emit(T0, T1)</c>, calling receivers. </summary>
        [SerializeField] protected UnityAction<T0, T1> _OnEmit;

        public abstract void AddReceiver(UnityAction<T0, T1> receiver);
        public abstract void RemoveReceiver(UnityAction<T0, T1> receiver);
        public abstract void Emit(T0 target0, T1 target1);

        #endregion
    }

    /// <summary>
    /// Base type for all signals.
    /// </summary>
    public abstract class SignalBase<T0, T1, T2> : ScriptableObject, ISignal<T0, T1, T2>
    {
        #region Inspector Fields

        /// <summary>
        /// The description of what this signal is intended to be used for.
        /// </summary>
        [Tooltip("The description of what this signal is intended to be used for.")]
        [TextArea, SerializeField] protected string _description = string.Empty;

        /// <summary>
        /// The description of what this signal is intended to be used for.
        /// </summary>
        public string Description => _description;

        #endregion

        #region Emission

        /// <summary> Invoked in <c>Emit(T0, T1, T2)</c>, calling receivers. </summary>
        [SerializeField] protected UnityAction<T0, T1, T2> _OnEmit;

        public abstract void AddReceiver(UnityAction<T0, T1, T2> receiver);
        public abstract void RemoveReceiver(UnityAction<T0, T1, T2> receiver);
        public abstract void Emit(T0 target0, T1 target1, T2 target2);

        #endregion
    }
}