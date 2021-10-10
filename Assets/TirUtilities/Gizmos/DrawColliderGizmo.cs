using UnityEngine;

namespace TirUtilities.CustomGizmos
{
    using TirUtilities.Extensions;
    ///<!--
    /// DrawColliderGizmo.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  May 29, 2021
    /// Updated:  May 29, 2021
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
    ///     <item> CapsuleCollider — <description> Only wire gizmo. </description> </item>
    /// </list>
    /// </remarks>
    // TODO:  Add line gizmos for the vector3 directions.
    // TODO:  Add line gizmos for the axes in local and world.
    // TODO:  Add gizmo that marks the pivot and center of the object.  Should be a separate comp.
    // TODO:  Investigate Cinemachine-like local component system.  I.E. TirGizmo that has comps. 
    //        specific to it that can only be added in the inceptor for TirGizmo.
    [RequireComponent(typeof(Collider))]
    public class DrawColliderGizmo : MonoBehaviour
    {
        #region Inspector Fields

        [Header("Collider")]
        [SerializeField] private Collider _collider;

        [Header("Gizmo Settings")]
        [SerializeField] private bool _drawWhenNotSelected = true;
        [SerializeField] private bool _drawSoldShap = true;
        [Space]
        [SerializeField] private Color _gizmoColor = new Color(1, 0, 1, 0.5f);
        [SerializeField] private float _sizeScaler = 1.0f;
        [Space]
        [SerializeField] private float _lineThickness = 2.0f;

        #endregion

        #region Unity Messages

        private void OnValidate()
        {
            if (_collider.IsNull()) TryGetComponent(out _collider);
        }


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
            Gizmos.color = _gizmoColor;
            Gizmos.matrix = transform.localToWorldMatrix;
            if (_collider is BoxCollider)
            {
                if (_drawSoldShap)
                    Gizmos.DrawCube(Vector3.zero, Vector3.one * _sizeScaler);
                else
                    Gizmos.DrawWireCube(Vector3.zero, Vector3.one * _sizeScaler);
            }
            else if (_collider is SphereCollider)
            {
                if (_drawSoldShap)
                    Gizmos.DrawSphere(Vector3.zero, 0.5f * _sizeScaler);
                else
                    Gizmos.DrawWireSphere(Vector3.zero, 0.5f * _sizeScaler);
            }
            else if (_collider is MeshCollider meshCollider)
            {
                if (_drawSoldShap)
                    Gizmos.DrawMesh(meshCollider.sharedMesh, Vector3.zero, Quaternion.identity, Vector3.one * _sizeScaler);
                else
                    Gizmos.DrawWireMesh(meshCollider.sharedMesh, Vector3.zero, Quaternion.identity, Vector3.one * _sizeScaler);
            }
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

        #endregion
    }
}