#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
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
    /// Zone.cs
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

        public readonly float Radius => _radius;
        public readonly float Height => _height;
        public readonly float HalfHeight => _height * 0.5f;
        public readonly float Diameter => _radius * 2.0f;

        public readonly bool DrawGizmo => _drawGizmo;
        public readonly Mesh GizmoMesh => _gizmoMesh;

        public Zone(float radius, float height, Mesh gizmoMesh = default)
        {
            _radius = radius;
            _height = height;
            _gizmoMesh = gizmoMesh;
            _drawGizmo = true;
        }

        public static implicit operator Zone((float, float) tuple) =>
            new(tuple.Item1, tuple.Item2);
    }

    public enum ShapeType
    {
        Box,
        Sphere,
        Cylinder,
    }
}