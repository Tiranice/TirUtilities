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

namespace TirUtilities.CustomGizmos
{
    using TirUtilities.Extensions;
    ///<!--
    /// DrawCameraGizmo.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Apr 27, 2021
    /// Updated:  Apr 03, 2025
    /// -->
    /// <summary>
    /// Draws the camera's frustum and forward.
    /// </summary>
    [AddComponentMenu("TirUtilities/Gizmos/Draw Camera Gizmo"), ExecuteInEditMode]
    public class DrawCameraGizmo : MonoBehaviour
    {
        #region Inspector Fields

        [Header("Camera")]
        [SerializeField] private Camera _camera;

        [Header("Settings")]
        [SerializeField] private bool _drawFrustum = true;
        [Space]
        [SerializeField] private Color _frustumColor = Color.white;
        [Space]
        [SerializeField] private bool _drawForwardLine = true;
        [Space]
        [SerializeField] private Color _lineColor = Color.red;
        [Min(0.0f)]
        [SerializeField] private float _lineLength = 1.0f;

        #endregion

        #region Gizmo

        private void OnDrawGizmos()
        {
            if (_camera.IsNull()) return;

            Gizmos.matrix = _camera.transform.localToWorldMatrix;

            if (_drawFrustum)
            {
                Gizmos.color = _frustumColor;
                Gizmos.DrawFrustum(Vector3.zero, _camera.fieldOfView, _camera.farClipPlane, _camera.nearClipPlane, _camera.aspect);
            }

            if (_drawForwardLine)
            {
                Gizmos.color = _lineColor;
                var forwardVector = new Vector3(0.0f, 0.0f, _camera.transform.position.z).normalized;
                Gizmos.DrawLine(Vector3.zero, forwardVector * -_lineLength);
            }
        }

        #endregion
    }
}