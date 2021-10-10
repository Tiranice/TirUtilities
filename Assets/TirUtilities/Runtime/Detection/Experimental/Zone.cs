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
        [SerializeField] private float _radius;
        [SerializeField] private float _height;

        public float Radius => _radius;
        public float Height => _height;
        public float HalfHeight => _height * 0.5f;
        public float Diameter => _radius * 2.0f;

        public Zone(float radius, float height)
        {
            _radius = radius;
            _height = height;
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