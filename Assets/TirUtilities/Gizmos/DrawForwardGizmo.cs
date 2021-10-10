using UnityEngine;

namespace TirUtilities.CustomGizmos
{
    ///<!--
    /// DrawForwardGizmo.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  Jan. 05, 2021
    /// Updated:  May 01, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    [AddComponentMenu("TirUtilities/Gizmos/Draw Forward Gizmo")]
    [ExecuteInEditMode]
    public class DrawForwardGizmo : MonoBehaviour
    {
        private enum ShapeType
        {
            Sphere,
            WireSphere,
            Cube,
            WireCube,
        }

        [SerializeField] private bool _drawShape = true;
        [SerializeField] private Color _shapeColor = Color.green;
        [SerializeField] private ShapeType _shapeType = ShapeType.WireSphere;
        [Range(0.1f, 2.0f)]
        [SerializeField] private float _shapeSize = 1.0f;
        [Space]
        [SerializeField] private bool _drawLine = true;
        [SerializeField] private Color _lineColor = Color.red;
        [Range(1.0f, 10.0f)]
        [SerializeField] private float _lineLength = 2.0f;

        private void OnDrawGizmos()
        {
            Vector3 position = transform.position;
            Vector3 size = transform.localScale * _shapeSize;
            float radius = Mathf.Max(transform.localScale.x, transform.localScale.y, transform.localScale.z) * _shapeSize;

            //Gizmos.matrix = transform.localToWorldMatrix;

            Gizmos.color = _shapeColor;
            if (_drawShape)
            {
                if (_shapeType == ShapeType.WireSphere)
                    Gizmos.DrawWireSphere(position, radius);

                else if (_shapeType == ShapeType.Cube)
                    Gizmos.DrawCube(position, size);

                else if (_shapeType == ShapeType.Sphere)
                    Gizmos.DrawSphere(position, radius);

                else if (_shapeType == ShapeType.WireCube)
                    Gizmos.DrawWireCube(position, size);
            }

            if (_drawLine)
            {
                Gizmos.color = _lineColor;
                Gizmos.DrawLine(position, position + transform.forward * _lineLength);
            }
        }
    }
}