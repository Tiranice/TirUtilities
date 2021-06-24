using UnityEngine;


namespace TirUtilities.Signals
{
    ///<!--
    /// IntSignal.cs
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
    public class SignalBase : ScriptableObject
    {
        #region Inspector Fields

        /// <summary>
        /// The description of what this signal is intended to be used for.
        /// </summary>
        [Tooltip("The description of what this signal is intended to be used for.")]
        [TextArea][SerializeField] protected string _description;

        /// <summary>
        /// The description of what this signal is intended to be used for.
        /// </summary>
        public string Description { get => _description; }

        #endregion
    }
}