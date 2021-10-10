using UnityEngine;

namespace TirUtilities.Detection.Experimental
{

    ///<!--
    /// SpawnZone.cs
    /// 
    /// Project:  Prototype 4
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
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
            public float Radius => _radius;
            public float Height => _height;
            public float HalfHeight => _height * 0.5f;
            public float Diameter => _radius * 2.0f;

            public ZoneDimensions(float radius, float height)
            {
                _radius = radius;
                _height = height;
            }

            public static implicit operator ZoneDimensions((float, float) tuple) =>
                new ZoneDimensions(tuple.Item1, tuple.Item2);
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