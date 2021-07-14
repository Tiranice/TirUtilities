using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TirUtilities.Controllers
{
    ///<!--
    /// MouseUtility.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  April 24, 2021
    /// Updated:  July 13, 2021
    /// -->
    /// <summary>
    /// Contains utility functions that make working with the mouse easier. 
    /// </summary>
    public sealed class MouseUtility
    {
        #region Mouse Button Properties

        /// <summary> Short hand for Input.GetMouseButtonDown(0) </summary>
        public static bool LeftMouseButtonDown => Input.GetMouseButtonDown(0);

        /// <summary> Short hand for Input.GetMouseButtonDown(1) </summary>
        public static bool RightMouseButtonDown => Input.GetMouseButtonDown(1);
        
        /// <summary> Short hand for Input.GetMouseButtonDown(2) </summary>
        public static bool MiddleMouseButtonDown => Input.GetMouseButtonDown(2);

        #endregion

        #region Mouse Raycast Methods 2D
        
        /// <summary>
        /// Casts a ray from the camera returning true if it hits anything.
        /// </summary>
        /// <returns> True if the ray hits a Collider2D. </returns>
        public static bool MouseRaycast2D()
        {
            var cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            return Physics2D.Raycast(cameraRay.origin, cameraRay.direction);
        }

        /// <summary>
        /// Casts a ray from the camera returning true if it hits anything and assigns that hit to
        /// the out parameter.
        /// </summary>
        /// <param name="raycastHit2D"></param>
        /// <returns> True if the ray hits a Collider2D. </returns>
        public static bool MouseRaycast2D(out RaycastHit2D raycastHit2D, LayerMask targetLayers, float distance = Mathf.Infinity)
        {
            var cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            raycastHit2D = Physics2D.Raycast(cameraRay.origin, cameraRay.direction, distance, targetLayers);
            return raycastHit2D;
        }

        #endregion

        #region Mouse Position Methods 2D

        /// <summary>
        /// Gets the position of a 2D ray-cast hit.
        /// </summary>
        /// <param name="point"></param>
        /// <returns> True if something was hit, otherwise false. </returns>
        public static bool TryGetWorldSpaceMousePosition2D(out Vector3 point)
        {
            LayerMask everything = ~0;
            if (MouseRaycast2D(out RaycastHit2D raycastHit, everything))
            {
                point = raycastHit.point;
                return true;
            }

            point = Vector3.positiveInfinity;
            return false;
        }

        #endregion

        #region Mouse Raycast Methods 3D

        /// <summary>
        /// Casts a ray from the camera returning true if it hits anything.
        /// </summary>
        /// <returns> True if the ray hits a Collider. </returns>
        public static bool MouseRaycast()
        {
            var cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(cameraRay);
        }

        /// <summary>
        /// Casts a ray from the camera returning true if it hits anything and assigns that hit to
        /// the out parameter.
        /// </summary>
        /// <param name="raycastHit"></param>
        /// <returns> True if the ray hits a Collider. </returns>
        public static bool MouseRaycast(out RaycastHit raycastHit, float maxDistance = Mathf.Infinity)
        {
            var cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            return Physics.Raycast(cameraRay, out raycastHit, maxDistance);
        }

        /// <summary>
        /// Casts a ray from the camera returning true if it hits anything.
        /// </summary>
        /// <param name="raycastHit"></param>
        /// <param name="targetLayers"></param>
        /// <param name="maxDistance"></param>
        /// <param name="queryTriggerInteraction"></param>
        /// <returns> True if the ray hits a Collider. </returns>
        public static bool MouseRaycast(out RaycastHit raycastHit, LayerMask targetLayers, float maxDistance = Mathf.Infinity, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
        {
            var cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            return Physics.Raycast(cameraRay, out raycastHit, maxDistance, targetLayers, queryTriggerInteraction);
        }

        #endregion

        #region Mouse Position Methods 3D

        /// <summary>
        /// Attempts to get the world space position of the mouse cursor by casting a ray through
        /// the mouse's screen point.
        /// </summary>
        /// <param name="point">The point the mouse is hovering over.</param>
        /// <returns>True if there are any colliders under the mouse.</returns>
        public static bool TryGetWorldSpaceMousePosition(out Vector3 point)
        {
            if (MouseRaycast(out RaycastHit raycastHit))
            {
                point = raycastHit.point;
                return true;
            }

            point = Vector3.positiveInfinity;
            return false;
        }

        /// <summary>
        /// Attempts to get the world space position of the mouse cursor by casting a ray through
        /// the mouse's screen point, and into the target layers.
        /// </summary>
        /// <param name="point">The point the mouse is hovering over.</param>
        /// <param name="targetLayers">The layers that the ray can hit.</param>
        /// <returns>True if any of the colliders under the mouse are on the target layers.</returns>
        public static bool TryGetWorldSpaceMousePosition(out Vector3 point, LayerMask targetLayers)
        {
            if (MouseRaycast(out RaycastHit raycastHit, targetLayers))
            {
                point = raycastHit.point;
                return true;
            }

            point = Vector3.positiveInfinity;
            return false;
        }

        #endregion

        #region Scene View Mouse Position 3D

#if UNITY_EDITOR
        /// <summary>
        /// Get the location of the mouse in the scene view.
        /// </summary>
        /// <param name="point">The point in the scene.</param>
        /// <returns>True if something was hit by the raycast, otherwise false.</returns>
        public static bool TryGetSceneVieweMousePosition(out Vector3 point)
        {
            Vector3 mousePosition = Event.current.mousePosition;
            Camera sceneCamera = SceneView.currentDrawingSceneView.camera;

            mousePosition.y = sceneCamera.pixelHeight - mousePosition.y;
            mousePosition = sceneCamera.ScreenToWorldPoint(mousePosition);
            mousePosition.y = -mousePosition.y;

            var mouseRay = HandleUtility.GUIPointToWorldRay(mousePosition);
            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo))
            {
                point = hitInfo.point;
                return true;
            }

            point = Vector3.positiveInfinity;
            return false;
        }

        /// <summary>
        /// Get the location of the mouse in the scene view.
        /// </summary>
        /// <param name="point">The point in the scene.</param>
        /// <param name="targetLayers">The layers that the raycast can hit.</param>
        /// <returns>True if something was hit by the raycast, otherwise false.</returns>
        public static bool TryGetSceneVieweMousePosition(out Vector3 point, LayerMask targetLayers)
        {
            Vector3 mousePosition = Event.current.mousePosition;
            Camera sceneCamera = SceneView.currentDrawingSceneView.camera;

            mousePosition.y = sceneCamera.pixelHeight - mousePosition.y;
            mousePosition = sceneCamera.ScreenToWorldPoint(mousePosition);
            mousePosition.y = -mousePosition.y;

            var mouseRay = HandleUtility.GUIPointToWorldRay(mousePosition);
            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, targetLayers))
            {
                point = hitInfo.point;
                return true;
            }

            point = Vector3.positiveInfinity;
            return false;
        }
#endif

        #endregion

        #region Game Object Methods 2D

        public static bool TryGetHoveredCollider2D(out Collider2D collider, LayerMask targetLayers)
        {
            if (MouseRaycast2D(out RaycastHit2D raycastHit, targetLayers))
            {
                collider = raycastHit.collider;
                return true;
            }
            collider = null;
            return false;
        }

        public static bool TryGetHoveredGameObject2D(out GameObject gameObject, LayerMask targetLayers)
        {
            if (MouseRaycast2D(out RaycastHit2D raycastHit, targetLayers))
            {
                gameObject = raycastHit.collider.gameObject;
                return true;
            }
            gameObject = null;
            return false;
        }

        public static bool TryGetGameObjectOnClick2D(out GameObject gameObject, LayerMask targetLayers)
        {
            if (LeftMouseButtonDown && MouseRaycast2D(out RaycastHit2D raycastHit, targetLayers))
            {
                gameObject = raycastHit.collider.gameObject;
                return true;
            }
            gameObject = null;
            return false;
        }

        #endregion

        #region Game Object Methods 3D

        /// <summary>
        /// Finds the first game object under the mouse that has an attached collider.
        /// </summary>
        /// <returns>The game object found or null.</returns>
        public static GameObject GetGameObjectAtMousePosition() => 
            MouseRaycast(out RaycastHit raycastHit) ? raycastHit.collider.gameObject : null;

        /// <summary>
        /// Finds the first game object with an attached collider on the target layers.
        /// </summary>
        /// <returns>The game object found or null.</returns>
        public static GameObject GetGameObjectAtMousePosition(LayerMask targetLayers) =>
            MouseRaycast(out RaycastHit raycastHit, targetLayers) ? raycastHit.collider.gameObject 
                                                                  : null;

        /// <summary>
        /// Assigns to selection the first game object with an attached collider that is on any of
        /// the target layers and under the mouse pointer.  Assigns null to selection if no object
        /// was found.
        /// </summary>
        /// <param name="selection">The selected object is assigned to this.</param>
        /// <param name="targetLayers">The layers that the raycast can hit.</param>
        /// <returns>True if an object was found, otherwise false.</returns>
        public static bool TryGetObjectAtMousePosition(out GameObject selection, LayerMask targetLayers)
        {
            var hit = MouseRaycast(out RaycastHit raycastHit, targetLayers);
            selection = hit ? raycastHit.collider.gameObject : null;
            return hit;
        }

        #endregion
    }
}