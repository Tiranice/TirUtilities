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
    /// DrawColliderGizmo.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  May 29, 2021
    /// Updated:  Apr 06, 2025
    /// -->
    /// <summary>
    /// Draws a gizmo for the given collider.
    /// </summary>
    /// <remarks>
    /// Supported colliders:
    /// <list type="bullet">
    ///     <item> BoxCollider </item>
    ///     <item> SphereCollider </item>
    ///     <item> MeshCollider </item>
    ///     <item> CapsuleCollider - <description> Only wire gizmo. </description> </item>
    /// </list>
    /// </remarks>
    // TODO:  Add line gizmos for the vector3 directions.
    // TODO:  Add line gizmos for the axes in local and world.
    // TODO:  Add gizmo that marks the pivot and center of the object.  Should be a separate comp.
    // TODO:  Investigate Cinemachine-like local component system.  I.E. TirGizmo that has comps. 
    //        specific to it that can only be added in the inceptor for TirGizmo.
    [AddComponentMenu("TirUtilities/Gizmos/Draw Collider Gizmo"), RequireComponent(typeof(Collider))]
    public class DrawColliderGizmo : MonoBehaviour
    {
        [System.Flags]
        private enum Vector3Direction
        {
            Nothing = 0,
            Forward, Backward,
            Up, Down,
            Left, Right,
        }

        #region Inspector Fields

        [Header("Collider")]
        [SerializeField] private Collider _collider;
        private Transform _transform;

        [Header("Gizmo Settings")]
        [SerializeField] private bool _drawWhenNotSelected = true;
        [SerializeField] private bool _drawSolidShape = true;
        [Space]
        [SerializeField] private Vector3Direction _drawDirections = Vector3Direction.Nothing;
        [Space]
        [SerializeField] private Color _gizmoColor = new(1, 0, 1, 0.5f);
        [SerializeField] private float _sizeScaler = 1.0f;
        [Space]
        [SerializeField] private float _lineThickness = 2.0f;

        #endregion

        #region Unity Messages

        private void OnValidate()
        {
            if (_collider.IsNull()) TryGetComponent(out _collider);
            _transform = _collider.transform;
        }

        private void OnDrawGizmosSelected() { if (!_drawWhenNotSelected) DrawGizmo(); }

        private void OnDrawGizmos() { if (_drawWhenNotSelected) DrawGizmo(); }

        #endregion

        #region Gizmo

        private void DrawGizmo()
        {
            if (_collider.IsNull()) return;

            Gizmos.matrix = _collider.transform.localToWorldMatrix;

            if (_drawDirections.HasFlag(Vector3Direction.Left))     DrawLine(-_transform.right,   Color.magenta);
            if (_drawDirections.HasFlag(Vector3Direction.Right))    DrawLine( _transform.right,   Color.red);
            if (_drawDirections.HasFlag(Vector3Direction.Up))       DrawLine( _transform.up,      Color.green);
            if (_drawDirections.HasFlag(Vector3Direction.Down))     DrawLine(-_transform.up,      Color.yellow);
            if (_drawDirections.HasFlag(Vector3Direction.Forward))  DrawLine( _transform.forward, Color.blue);
            if (_drawDirections.HasFlag(Vector3Direction.Backward)) DrawLine(-_transform.forward, Color.cyan);

            Gizmos.color = _gizmoColor;

            if      (_collider is BoxCollider)               DrawBoxGizmo();
            else if (_collider is SphereCollider)            DrawSphereGizmo();
            else if (_collider is MeshCollider meshCollider) DrawMeshGizmo(meshCollider);
            else if (_collider is CapsuleCollider capsuleCollider)
            {
                // TODO:  Implement a way to draw a solid gizmo.
                TirGizmos.DrawWireCapsule(capsuleCollider, _sizeScaler, _lineThickness);
            }
            else if (_collider is CharacterController characterController)
            {
                // TODO:  Implement a way to draw a solid gizmo.
                TirGizmos.DrawWireCapsule(characterController, _sizeScaler, _lineThickness); 
            }
        }

        private void DrawLine(Vector3 direction, Color color)
        {
            Gizmos.color = color;
            Gizmos.DrawRay(_collider.transform.position, direction);
        }

        private void DrawMeshGizmo(MeshCollider meshCollider)
        {
            if (_drawSolidShape)
                Gizmos.DrawMesh(meshCollider.sharedMesh, Vector3.zero, Quaternion.identity, Vector3.one * _sizeScaler);
            else
                Gizmos.DrawWireMesh(meshCollider.sharedMesh, Vector3.zero, Quaternion.identity, Vector3.one * _sizeScaler);
        }

        private void DrawSphereGizmo()
        {
            if (_drawSolidShape)
                Gizmos.DrawSphere(Vector3.zero, 0.5f * _sizeScaler);
            else
                Gizmos.DrawWireSphere(Vector3.zero, 0.5f * _sizeScaler);
        }

        private void DrawBoxGizmo()
        {
            if (_drawSolidShape)
                Gizmos.DrawCube(Vector3.zero, Vector3.one * _sizeScaler);
            else
                Gizmos.DrawWireCube(Vector3.zero, Vector3.one * _sizeScaler);
        }

        #endregion
    }
}