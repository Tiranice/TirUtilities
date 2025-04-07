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
    ///<!--
    /// DrawForwardGizmo.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Jan 05, 2021
    /// Updated:  Jan 03, 2022
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
        [Range(1.0f, 50.0f)]
        [SerializeField] private float _lineLength = 2.0f;

        private void OnDrawGizmos()
        {
            Vector3 position = transform.position;
            Vector3 size = transform.localScale * _shapeSize;
            float radius = Mathf.Max(transform.localScale.x, transform.localScale.y, transform.localScale.z) * _shapeSize;

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