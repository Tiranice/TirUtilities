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
    /// Created:  April 27, 2021
    /// Updated:  June 19, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public class AutoRotate : MonoBehaviour
    {
        #region Data Structures

        [System.Serializable]
        private enum Axis { X, Y, Z }

        #endregion

        #region Inspector Fields

        [Header("References")]
        [SerializeField] private Transform _transform;

        [Header("Settings")]
        [SerializeField] private Axis _axis = Axis.Y;
        [Range(-180.0f, 180.0f)]
        [SerializeField] private float _angle = 30.0f;

        private bool _shouldRotate = true;

        #endregion

        #region Unity Messages

        private void Start()
        {
            if (_transform.IsNull())
                _transform = transform;
        }

        private void FixedUpdate()
        {
            if (_shouldRotate)
                RotateTransform();
        }

        #endregion

        #region Private Methods

        private void RotateTransform()
        {
            var axis = _axis switch
            {
                Axis.X => Vector3.right,
                Axis.Z => Vector3.forward,
                _ => Vector3.up,
            };

            _transform.Rotate(axis, _angle * Time.deltaTime);
        }

        #endregion

        #region Public Methods

        public void ToggleRotation() => _shouldRotate = !_shouldRotate;

        #endregion
    }
}