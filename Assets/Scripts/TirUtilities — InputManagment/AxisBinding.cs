#if ENABLE_LEGACY_INPUT_MANAGER
using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.InputManagment
{
    [System.Serializable]
    public class AxisEvent : UnityEvent<float> { }

    ///<!--
    /// AxisBinding.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Jan 15, 2020
    /// Updated:  Oct 21, 2021
    /// -->
    /// <summary>
    /// Creates a binding for the given axis in the legacy input manager.
    /// </summary>
    /// <remarks>
    /// Intended to be set in the inspector, but can be set with the constructor if you like typing
    /// out strings over and over.
    /// </remarks>
    [System.Serializable]
    public class AxisBinding
    {
        [SerializeField, AxisSelector] private string _axis;

        public AxisEvent OnAxis;
        public AxisEvent OnAxisRaw;

        public AxisBinding(string axis) =>
            _axis = axis ?? throw new System.ArgumentNullException(nameof(axis));

        public float RawValue => Input.GetAxisRaw(_axis);
        public float Value => Input.GetAxis(_axis);
        public string Axis => _axis;
    }
} 
#endif