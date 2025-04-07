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
    /// DrawBoxGizmo.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Jan 22, 2021
    /// Updated:  Apr 03, 2025
    /// -->
    /// <summary>
    /// Draws a box around a box collider.
    /// </summary>
    [AddComponentMenu("TirUtilities/Gizmos/Draw Box Gizmo")]
    [RequireComponent(typeof(BoxCollider))]
    public class DrawBoxGizmo : MonoBehaviour
    {
        [SerializeField] private BoxCollider _colliderToBox;
        [SerializeField] private Color _gizmoColor = new(1, 0, 1, 0.5f);
        [Range(0.1f, 2.0f)]
        [SerializeField] private float _sizeScaler = 1.0f;

        private void OnValidate()
        {
            if (_colliderToBox.IsNull())
                TryGetComponent(out _colliderToBox);
        }

        private void OnDrawGizmos()
        {
            if (_colliderToBox == null) return;

            Gizmos.color = _gizmoColor;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawCube(_colliderToBox.center, _colliderToBox.size * _sizeScaler);
            Gizmos.matrix = Matrix4x4.identity;
        }
    }
}