﻿using UnityEngine;

namespace TirUtilities.CustomGizmos
{
    ///<!--
    /// DrawBoxGizmo.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson  
    /// Created:  Jan 22, 2021
    /// Updated:  Jan 03, 2022
    /// -->
    /// <summary>
    /// Draws a box around a box collider.
    /// </summary>
    [AddComponentMenu("TirUtilities/Gizmos/Draw Box Gizmo")]
    [RequireComponent(typeof(BoxCollider))]
    public class DrawBoxGizmo : MonoBehaviour
    {
        #region Inspector Fields

        [SerializeField] private BoxCollider _colliderToBox;
        [SerializeField] private Color _gizmoColor = new Color(1, 0, 1, 0.5f);
        [Range(0.1f, 2.0f)]
        [SerializeField] private float _sizeScaler = 1.0f;

        #endregion

        #region Gizmo

        // Draws a box inside the collider.
        private void OnDrawGizmos()
        {
            if (_colliderToBox == null) return;

            Gizmos.color = _gizmoColor;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawCube(_colliderToBox.center, _colliderToBox.size * _sizeScaler);
        }

        #endregion
    }
}