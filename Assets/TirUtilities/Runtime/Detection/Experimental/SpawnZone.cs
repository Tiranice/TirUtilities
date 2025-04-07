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

namespace TirUtilities.Detection.Experimental
{
    ///<!--
    /// SpawnZone.cs
    ///
    /// Project:  Prototype 4
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Sep 29, 2021
    /// Updated:  Sep 29, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public class SpawnZone : MonoBehaviour
    {
        #region Data Structures

        [System.Serializable]
        private struct ZoneDimensions
        {
            [SerializeField] private float _radius;
            [SerializeField] private float _height;
            public readonly float Radius => _radius;
            public readonly float Height => _height;
            public readonly float HalfHeight => _height * 0.5f;
            public readonly float Diameter => _radius * 2.0f;

            public ZoneDimensions(float radius, float height)
            {
                _radius = radius;
                _height = height;
            }

            public static implicit operator ZoneDimensions((float, float) tuple) =>
                new(tuple.Item1, tuple.Item2);
        }

        #endregion

        #region Inspector Fields

        [SerializeField] private LayerMask _targetLayer;
        [SerializeField] private Mesh _gizmoMesh;

        [Header("Zone Settings")]
        [SerializeField] private ZoneDimensions _dimensions = (10.0f, 20.0f);
        [SerializeField] private bool _spawnAtSelf = false;
        [Space]
        [SerializeField] private Color _gizmoColor = Color.green;

        #endregion

        #region Public Methods

        public Vector3 GetRandomPosition()
        {
            if (_spawnAtSelf) return transform.position;

            var worldPosition = transform.position;

            var areaY = worldPosition.y + _dimensions.HalfHeight;

            var angle = Mathf.PI * _dimensions.Radius * Random.value;

            var spawnPosition =
            new Vector3(Mathf.Cos(angle) * Random.Range(0.0f, _dimensions.Radius),
                        areaY,
                        Mathf.Sin(angle) * Random.Range(0.0f, _dimensions.Radius));

            var ray = new Ray(spawnPosition, -transform.up);
            spawnPosition = Physics.Raycast(ray, out var hitInfo, _dimensions.Height, _targetLayer)
                ? hitInfo.point
                : worldPosition;

            return spawnPosition;
        }

        #endregion

        private void OnDrawGizmos()
        {
            Gizmos.color = _gizmoColor;
            Gizmos.DrawMesh(mesh: _gizmoMesh,
                            position: transform.position,
                            rotation: Quaternion.identity,
                            scale: new Vector3(_dimensions.Diameter,
                                               _dimensions.HalfHeight,
                                               _dimensions.Diameter)
                            );
        }
    }
}