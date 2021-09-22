using UnityEngine;

namespace TirUtilities.Automation
{
    using TirUtilities.Extensions;
    ///<!--
    /// AutoRotate.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  Apr 27, 2021
    /// Updated:  Sep 22, 2021
    /// -->
    /// <summary>
    /// Rotates a transform about the given axis over time on fixed update.
    /// </summary>
    public class AutoRotate : MonoBehaviour
    {
        #region Data Structures

        [System.Serializable]
        public enum Axis { X, Y, Z }

        #endregion

        #region Inspector Fields

        [Header("References")]
        [Tooltip("Set to the attached transform if left null.")]
        [SerializeField] private Transform _transform;

        [Header("Settings")]
        [Tooltip("Rotation is about this axis.")]
        [SerializeField] private Axis _axis = Axis.Y;
        [Tooltip("Rotation rate in degrees per second."), Range(-180.0f, 180.0f)]
        [SerializeField] private float _degreesPerSec = 30.0f;

        private bool _shouldRotate = true;

        #endregion

        #region Unity Messages

        private void Start() => FetchTransform();

        private void FixedUpdate() => RotateTransform();

        #endregion

        #region Setup & Teardown

        private void FetchTransform()
        {
            if (_transform.IsNull())
                _transform = transform;
        }

        #endregion

        #region Private Methods

        private void RotateTransform()
        {
            if (!_shouldRotate) return;

#if UNITY_2020_2_OR_NEWER
            var axis = _axis switch
            {
                Axis.X => Vector3.right,
                Axis.Z => Vector3.forward,
                _ => Vector3.up,
            };
#else
            Vector3 axis = Vector3.zero;
            switch (_axis)
            {
                case Axis.X:
                    axis = Vector3.right;
                    break;
                case Axis.Z:
                    axis = Vector3.forward;
                    break;
                default:
                    axis = Vector3.up;
                    break;
            }
#endif
            _transform.Rotate(axis, _degreesPerSec * Time.deltaTime);
        }

        #endregion

        #region Public Methods

        /// <summary> Toggle rotation on/off. </summary>
        public void ToggleRotation() => _shouldRotate = !_shouldRotate;

        /// <summary> Set rotation state manually. </summary>
        /// <param name="value"></param>
        public void SetIsRotating(bool value) => _shouldRotate = value;

        #endregion

        #region Public Properties

        /// <summary> Get/Set the axis that the transform rotates about. </summary>
        public Axis RotationAxis { get => _axis; set => _axis = value; }

        /// <summary> True when transform should be rotating. </summary>
        public bool IsRotating => _shouldRotate;

        #endregion
    }
}