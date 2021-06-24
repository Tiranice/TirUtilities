using TirUtilities.Extensions;
using UnityEngine;

namespace TirUtilities.CustomGizmos
{
    ///<!--
    /// DrawForwardGizmo.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  April 27, 2021
    /// Updated:  May 01, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    [AddComponentMenu("TirUtilities/Gizmos/Draw Camera Gizmo")]
    [ExecuteInEditMode]
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
            if (_camera.NotNull())
            {
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
                    Gizmos.DrawLine(Vector3.zero, forwardVector  * -_lineLength);
                }
            }
        }

        #endregion
    }
}