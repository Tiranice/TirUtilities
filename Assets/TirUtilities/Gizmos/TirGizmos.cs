using UnityEngine;

namespace TirUtilities.CustomGizmos
{
    ///<!--
    /// TirGizmos.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  May 28, 2021
    /// Updated:  May 28, 2021
    /// -->
    /// <summary>
    /// A collection of gizmos that function like those from UnityEngine.Gizmos.
    /// </summary>
    public static class TirGizmos
    {
        /// <summary>
        /// Draws a wire gizmo in the shape of the provided capsule collider.
        /// </summary>
        /// <remarks>
        /// <see href="https://www.wolframalpha.com/input/?i=capsule+Semialgebraic+description">Semialgebraic Description</see>
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

            #region Calculate Capsule Shape

            float x_comp = radius - extents.z + halfHeight - extents.y;
            float y_comp = radius - extents.z + halfHeight - extents.x;
            float z_comp = radius + halfHeight - extents.x - extents.y;

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
                switch (capsuleCollider.direction)
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
            radius *= sizeScaler;

            #endregion

#if UNITY_EDITOR
            #region Special case when both points are in the same position
            
            if (p1 == p2)
            {
                Gizmos.DrawWireSphere(p1, radius);
                return;
            }

            #endregion

            #region Draw Capsule

            using (new UnityEditor.Handles.DrawingScope(Gizmos.color, Gizmos.matrix))
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
                // First side
                //UnityEditor.Handles.DrawSolidArc(p1, p1Rotation * Vector3.left, p1Rotation * Vector3.down, 180f, radius);
                UnityEditor.Handles.DrawWireArc(p1, p1Rotation * Vector3.left, p1Rotation * Vector3.down, 180f, radius);
                UnityEditor.Handles.DrawWireArc(p1, p1Rotation * Vector3.up, p1Rotation * Vector3.left, 180f, radius);
                UnityEditor.Handles.DrawWireDisc(p1, (p2 - p1).normalized, radius);
                // Second side
                UnityEditor.Handles.DrawWireArc(p2, p2Rotation * Vector3.left, p2Rotation * Vector3.down, 180f, radius);
                UnityEditor.Handles.DrawWireArc(p2, p2Rotation * Vector3.up, p2Rotation * Vector3.left, 180f, radius);
                UnityEditor.Handles.DrawWireDisc(p2, (p1 - p2).normalized, radius);
                // Lines
                UnityEditor.Handles.DrawLine(p1 + p1Rotation * Vector3.down * radius, p2 + p2Rotation * Vector3.down * radius);
                UnityEditor.Handles.DrawLine(p1 + p1Rotation * Vector3.left * radius, p2 + p2Rotation * Vector3.right * radius);
                UnityEditor.Handles.DrawLine(p1 + p1Rotation * Vector3.up * radius, p2 + p2Rotation * Vector3.up * radius);
                UnityEditor.Handles.DrawLine(p1 + p1Rotation * Vector3.right * radius, p2 + p2Rotation * Vector3.left * radius);
            }

            #endregion
#endif
        }

        /// <summary>
        /// Draws a wire gizmo in the shape of the provided capsule collider.
        /// </summary>
        /// <remarks>
        /// <see href="https://www.wolframalpha.com/input/?i=capsule+Semialgebraic+description">Semialgebraic Description</see>
        /// </remarks>
        /// <param name="capsuleCollider"></param>
        /// <param name="sizeScaler"></param>
        public static void DrawWireCapsule(CharacterController capsuleCollider, float sizeScaler = 1.0f, float lineThickness = 2.0f)
        {
            #region Cache Capsule Values

            float radius = capsuleCollider.radius;
            float height = capsuleCollider.height;
            float halfHeight = height / 2.0f;
            Vector3 extents = capsuleCollider.bounds.extents;

            #endregion

            #region Calculate Capsule Shape

            float x_comp = radius - extents.z + halfHeight - extents.y;
            float y_comp = radius - extents.z + halfHeight - extents.x;
            float z_comp = radius + halfHeight - extents.x - extents.y;

            var up = new Vector3(0, y_comp, 0);
            var down = -up;

            var right = new Vector3(x_comp, 0, 0);
            var left = -right;

            var forward = new Vector3(0, 0, z_comp);
            var back = -forward;

            #endregion

            #region Set Points

            Vector3 p1 = up, p2 = down;
            radius *= sizeScaler;

            #endregion

#if UNITY_EDITOR
            #region Special case when both points are in the same position

            if (p1 == p2)
            {
                Gizmos.DrawWireSphere(p1, radius);
                return;
            }

            #endregion

            #region Draw Capsule

            using (new UnityEditor.Handles.DrawingScope(Gizmos.color, Gizmos.matrix))
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
                // First side
                //UnityEditor.Handles.DrawSolidArc(p1, p1Rotation * Vector3.left, p1Rotation * Vector3.down, 180f, radius);
                UnityEditor.Handles.DrawWireArc(p1, p1Rotation * Vector3.left, p1Rotation * Vector3.down, 180f, radius, lineThickness);
                UnityEditor.Handles.DrawWireArc(p1, p1Rotation * Vector3.up, p1Rotation * Vector3.left, 180f, radius, lineThickness);
                UnityEditor.Handles.DrawWireDisc(p1, (p2 - p1).normalized, radius, lineThickness);
                // Second side
                UnityEditor.Handles.DrawWireArc(p2, p2Rotation * Vector3.left, p2Rotation * Vector3.down, 180f, radius, lineThickness);
                UnityEditor.Handles.DrawWireArc(p2, p2Rotation * Vector3.up, p2Rotation * Vector3.left, 180f, radius, lineThickness);
                UnityEditor.Handles.DrawWireDisc(p2, (p1 - p2).normalized, radius, lineThickness);
                // Lines
                UnityEditor.Handles.DrawLine(p1 + p1Rotation * Vector3.down * radius, p2 + p2Rotation * Vector3.down * radius, lineThickness);
                UnityEditor.Handles.DrawLine(p1 + p1Rotation * Vector3.left * radius, p2 + p2Rotation * Vector3.right * radius, lineThickness);
                UnityEditor.Handles.DrawLine(p1 + p1Rotation * Vector3.up * radius, p2 + p2Rotation * Vector3.up * radius, lineThickness);
                UnityEditor.Handles.DrawLine(p1 + p1Rotation * Vector3.right * radius, p2 + p2Rotation * Vector3.left * radius, lineThickness);
            }

            #endregion
#endif
        }
    }
}