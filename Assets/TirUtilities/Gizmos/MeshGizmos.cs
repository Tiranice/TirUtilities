using System.Collections.Generic;

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

namespace TirUtilities.CustomGizmos.Experimental
{
    ///<!--
    /// MeshGizmo.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Oct 01, 2021
    /// Updated:  Oct 01, 2021
    /// -->
    /// <summary>
    /// Draws gizmos for all assigned mesh colliders.
    /// </summary>
    public class MeshGizmos : MonoBehaviour
    {
        #region Inspector Fields

        [Header("Collider")]
        [SerializeField] private List<MeshCollider> _colliders;

        [Header("Gizmo Settings")]
        [SerializeField] private bool _drawWhenNotSelected = true;
        [SerializeField] private bool _drawSolidShape = true;
        [Space]
        [SerializeField] private Color _gizmoColor = new Color(1, 0, 1, 0.5f);
        [SerializeField] private float _sizeScaler = 1.0f;

        #endregion

        #region Unity Messages

        private void OnDrawGizmosSelected()
        {
            if (!_drawWhenNotSelected) DrawGizmo();
        }

        private void OnDrawGizmos()
        {
            if (_drawWhenNotSelected) DrawGizmo();
        }

        #endregion

        #region Gizmo

        private void DrawGizmo()
        {
            foreach (var meshCollider in _colliders)
            {
                Gizmos.color = _gizmoColor;
                Gizmos.matrix = meshCollider.transform.localToWorldMatrix;
                if (_drawSolidShape)
                    Gizmos.DrawMesh(meshCollider.sharedMesh,
                                    Vector3.zero,
                                    Quaternion.identity,
                                    Vector3.one * _sizeScaler);
                else
                    Gizmos.DrawWireMesh(meshCollider.sharedMesh,
                                        Vector3.zero,
                                        Quaternion.identity,
                                        Vector3.one * _sizeScaler);
            }
        }

        #endregion
    }
}