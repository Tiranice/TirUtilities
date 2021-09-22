using UnityEngine;

namespace TirUtilities.Signals
{
    ///<!--
    /// SignalBase.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Created:  June 15, 2021
    /// Updated:  June 15, 2021
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
    }
}