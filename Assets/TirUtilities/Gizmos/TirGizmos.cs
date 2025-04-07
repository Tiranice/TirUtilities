using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

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
    using TirUtilities.Extensions;
    ///<!--
    /// TirGizmos.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  May 28, 2021
    /// Updated:  Apr 06, 2025
    /// -->
    /// <summary>
    /// A collection of gizmos that function like those from UnityEngine.Gizmos.
    /// </summary>
    public static class TirGizmos
    {
        #region Wire Capsule

        /// <summary>
        /// Draws a wire gizmo in the shape of the provided capsule collider.
        /// </summary>
        /// <remarks>
        /// <see href="https://www.wolframalpha.com/input/?i=capsule+Semialgebraic+description">Semi-algebraic Description</see>
        /// </remarks>
        /// <param name="capsuleCollider"></param>
        /// <param name="sizeScaler"></param>
        public static void DrawWireCapsule(CapsuleCollider capsuleCollider, float sizeScaler = 1.0f, float lineThickness = 2.0f)
        {
            #region Cache Capsule Values

            float radius = capsuleCollider.radius;
            float height = capsuleCollider.height;
            float halfHeight = height / 2.0f;
            Vector3 extents = capsuleCollider.bounds.extents;

            #endregion

            var (one, two) = CalculateCapsuleShape(radius, height, extents, capsuleCollider.direction);
            radius *= sizeScaler;

#if UNITY_EDITOR
            if (radius >= halfHeight)
                Gizmos.DrawWireSphere(capsuleCollider.center, radius);
            else
                DrawWireCapsuleInternal(one, two, radius, lineThickness);
#endif
        }

        /// <summary>
        /// Draws a wire gizmo in the shape of the provided character controller.
        /// </summary>
        /// <remarks>
        /// <see href="https://www.wolframalpha.com/input/?i=capsule+Semialgebraic+description">Semi-algebraic Description</see>
        /// </remarks>
        /// <param name="characterController"></param>
        /// <param name="sizeScaler"></param>
        /// <param name="lineThickness"></param>
        public static void DrawWireCapsule(CharacterController characterController, float sizeScaler = 1.0f, float lineThickness = 2.0f)
        {
            #region Cache Capsule Values

            float radius = characterController.radius;
            float height = characterController.height;
            float halfHeight = height / 2.0f;
            Vector3 extents = characterController.bounds.extents;

            #endregion

            var (one, two) = CalculateCapsuleShape(radius, height, extents, 1);
            radius *= sizeScaler;

#if UNITY_EDITOR
            if (radius >= halfHeight)
                Gizmos.DrawWireSphere(characterController.center, radius);
            else
                DrawWireCapsuleInternal(one, two, radius, lineThickness);
#endif
        }

        #endregion

        #region Calculate Wire Capsule

        private static (Vector3, Vector3) CalculateCapsuleShape(float radius, float height, Vector3 extents, int direction)
        {
            #region Calculate Capsule Shape

            float halfHeight = height * 0.5f;

            float x_comp = radius + halfHeight - extents.y - extents.z;
            float y_comp = radius - extents.x + halfHeight - extents.z;
            float z_comp = radius - extents.x - extents.y + halfHeight;

            var up = new Vector3(0, y_comp, 0);
            var down = -up;

            var right = new Vector3(x_comp, 0, 0);
            var left = -right;

            var forward = new Vector3(0, 0, z_comp);
            var back = -forward;

            #endregion

            #region Set Points

            Vector3 p1 = Vector3.zero, p2 = Vector3.zero;
            if (!extents.Invariant())
            {
                switch (direction)
                {
                    default:
                    case 0:
                        p1 = left;
                        p2 = right;
                        break;
                    case 1:
                        p1 = up;
                        p2 = down;
                        break;
                    case 2:
                        p1 = forward;
                        p2 = back;
                        break;
                }
            }

            #endregion

            return (p1, p2);
        }

        private static void DrawWireCapsuleInternal(Vector3 p1, Vector3 p2, float radius, float lineThickness = 0)
        {
            #region Special case when both points are in the same position

            if (p1 == p2)
            {
                Gizmos.DrawWireSphere(p1, radius);
                return;
            }

            #endregion

#if UNITY_EDITOR
            using (new Handles.DrawingScope(Gizmos.color, Gizmos.matrix))
            {
                var p1Rotation = Quaternion.LookRotation(p1 - p2);
                var p2Rotation = Quaternion.LookRotation(p2 - p1);
                // Check if capsule direction is collinear to Vector.up
                float c = Vector3.Dot((p1 - p2).normalized, Vector3.up);
                if (c == 1f || c == -1f)
                {
                    // Fix rotation
                    p2Rotation = Quaternion.Euler(p2Rotation.eulerAngles.x, p2Rotation.eulerAngles.y + 180f, p2Rotation.eulerAngles.z);
                }

                var p1ArcLeftNormal = p1Rotation * Vector3.left;
                var p1LeftFrom = p1Rotation * Vector3.down;
                var p1ArcUpNormal = p1Rotation * Vector3.up;

                var p2LeftRotation = p2Rotation * Vector3.left;
                var p2LeftFrom = p2Rotation * Vector3.down;
                var p2UpRotation = p2Rotation * Vector3.up;

                // First side
                Handles.DrawWireArc(p1, p1ArcLeftNormal, p1LeftFrom, 180f, radius, lineThickness);
                Handles.DrawWireArc(p1, p1ArcUpNormal, p1ArcLeftNormal, 180f, radius, lineThickness);
                Handles.DrawWireDisc(p1, (p2 - p1).normalized, radius, lineThickness);
                // Second side
                Handles.DrawWireArc(p2, p2LeftRotation, p2LeftFrom, 180f, radius, lineThickness);
                Handles.DrawWireArc(p2, p2UpRotation, p2LeftRotation, 180f, radius, lineThickness);
                Handles.DrawWireDisc(p2, (p1 - p2).normalized, radius, lineThickness);
                // Lines
                Handles.DrawLine(p1 + p1Rotation * Vector3.down * radius, p2 + p2Rotation * Vector3.down * radius, lineThickness);
                Handles.DrawLine(p1 + p1Rotation * Vector3.left * radius, p2 + p2Rotation * Vector3.right * radius, lineThickness);
                Handles.DrawLine(p1 + p1Rotation * Vector3.up * radius, p2 + p2Rotation * Vector3.up * radius, lineThickness);
                Handles.DrawLine(p1 + p1Rotation * Vector3.right * radius, p2 + p2Rotation * Vector3.left * radius, lineThickness);
            }
#endif
        }

        #endregion
    }
}