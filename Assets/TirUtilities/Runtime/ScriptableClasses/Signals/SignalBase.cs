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
    /// Created:  June 15, 2021
    /// Updated:  Oct 10, 2021
    /// -->
    /// <summary>
    /// Base type for all signals.
    /// </summary>
    public abstract class SignalBase : ScriptableObject
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

        #region Actions

        /// <summary> Invoked in <see cref="Emit"/>, calling receivers. </summary>
        [SerializeField] protected UnityAction _OnEmit;

        #endregion
    }

    /// <summary>
    /// Base type for all signals.
    /// </summary>
    public abstract class SignalBase<T0> : ScriptableObject
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

        #region Actions

        /// <summary> Invoked in <see cref="Emit"/>, calling receivers. </summary>
        [SerializeField] protected UnityAction<T0> _OnEmit;

        #endregion
    }

    /// <summary>
    /// Base type for all signals.
    /// </summary>
    public abstract class SignalBase<T0, T1> : ScriptableObject
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

        #region Actions

        /// <summary> Invoked in <see cref="Emit"/>, calling receivers. </summary>
        [SerializeField] protected UnityAction<T0, T1> _OnEmit;

        #endregion
    }

    /// <summary>
    /// Base type for all signals.
    /// </summary>
    public abstract class SignalBase<T0, T1, T2> : ScriptableObject
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

        #region Actions

        /// <summary> Invoked in <see cref="Emit"/>, calling receivers. </summary>
        [SerializeField] protected UnityAction<T0, T1, T2> _OnEmit;

        #endregion
    }
}