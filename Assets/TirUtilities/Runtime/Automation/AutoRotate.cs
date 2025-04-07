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
///     You should have received a copy of the GNU General Public License
///     along with this program.  If not, see <https://www.gnu.org/licenses/>.
///-->

namespace TirUtilities.Automation
{
    using TirUtilities.Extensions;
    ///<!--
    /// AutoRotate.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
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

            var axis = _axis switch
            {
                Axis.X => Vector3.right,
                Axis.Z => Vector3.forward,
                _ => Vector3.up,
            };
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