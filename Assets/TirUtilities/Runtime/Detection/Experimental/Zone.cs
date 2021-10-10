#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;

namespace TirUtilities.Detection.Experimental
{

    ///<!--
    /// Zone.cs
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
    [System.Serializable]
    public struct Zone
    {
#if ODIN_INSPECTOR
        [Title("Dimensions")]
#else
        [Header("Dimensions")]
#endif
        [SerializeField] private float _radius;
        [SerializeField] private float _height;
#if ODIN_INSPECTOR
        [Title("Gizmo")]
#else
        [Header("Gizmo")]
#endif
        [SerializeField] private bool _drawGizmo;
        [SerializeField] private Mesh _gizmoMesh;

        public float Radius => _radius;
        public float Height => _height;
        public float HalfHeight => _height * 0.5f;
        public float Diameter => _radius * 2.0f;

        public bool DrawGizmo => _drawGizmo;
        public Mesh GizmoMesh => _gizmoMesh;

        public Zone(float radius, float height, Mesh gizmoMesh = default)
        {
            _radius = radius;
            _height = height;
            _gizmoMesh = gizmoMesh;
            _drawGizmo = true;
        }

        public static implicit operator Zone((float, float) tuple) =>
            new Zone(tuple.Item1, tuple.Item2);
    }

    public enum ShapeType
    {
        Box,
        Sphere,
        Cylinder,
    }
}