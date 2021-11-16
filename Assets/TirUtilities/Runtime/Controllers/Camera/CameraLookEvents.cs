using UnityEngine;

namespace TirUtilities.Controllers
{
    using TirUtilities.CustomEvents;
    using TirUtilities.Extensions;
    using TirUtilities.Signals;
    ///<!--
    /// CameraLookEvents.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  Mar. 31, 2021
    /// Updated:  May 01, 2021
    /// -->
    /// <summary>
    /// Used to inform event listeners and signal receivers what game object is in the center of 
    /// the camera's view.
    /// </summary>
    [AddComponentMenu("TirUtilities/Controllers/Camera Look Events")]
    [RequireComponent(typeof(Camera))]
    public class CameraLookEvents : MonoBehaviour
    {
        #region Inspector Fields

        [Header("Camera")]
        [SerializeField] private Camera _mainCamera;

        [Header("Raycast")]
        [Range(0.1f, 200.0f)]
        [SerializeField] private float _maxDistance = 50.0f;
        [SerializeField] private LayerMask _targetLayers;
        [SerializeField] private QueryTriggerInteraction _queryTriggerInteraction = QueryTriggerInteraction.UseGlobal;
        [SerializeField] private float _castRadius = 2.0f;


        [Header("Target")]
        [DisplayOnly]
        [SerializeField] private GameObject _lookTarget;

        #endregion

        #region Events & Signals

        [Header("Signals")]
        [SerializeField] private GameObjectSignal _cameraLookTargetSignal;

        [Header("Events")]
        public GameObjectEvent OnLookTargetChanged;

        #endregion

        #region Debug

        [Header("Debug")]
        [SerializeField] private bool _showDebugMessages = false;
        [Space]
        [SerializeField] private bool _drawCameraRay = true;
        [SerializeField] private Color _rayColor = Color.blue;

        #endregion

        #region Unity Messages

        private void Start() => Setup();

        private void FixedUpdate() => CastCameraRay();

        #endregion

        #region Setup & Teardown

        private void Setup()
        {
            if (_mainCamera.IsNull())
                _mainCamera = Camera.main;

            if (_showDebugMessages && _mainCamera.NotNull())
                Debug.Log($"{nameof(CameraLookEvents)}  |  {_mainCamera.name}");
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Casts a ray from the center of the camera to a point <see cref="_maxDistance">Max Distance</see>
        /// units away.  If an object on one of the <see cref="_targetLayers">Target Layers</see>
        /// is hit by the ray, then it will be assigned to <see cref="_lookTarget">Look Target</see>;
        /// otherwise, Look Target will be assigned null.  In either case, the
        /// <see cref="_cameraLookTargetSignal">Camera Look Target Signal</see> emits the Look Target,
        /// and <see cref="OnLookTargetChanged">On Look Target Changed</see> is invoked.
        /// </summary>
        private void CastCameraRay()
        {
            Ray cameraRay = _mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));

            #region Debug
            if (_drawCameraRay)
                Debug.DrawRay(cameraRay.origin, cameraRay.direction * _maxDistance, _rayColor);
            #endregion

            if (Physics.SphereCast(cameraRay, _castRadius, out RaycastHit hitInfo, _maxDistance, _targetLayers, _queryTriggerInteraction))
            {
                var hitObject = hitInfo.collider.gameObject;

                #region Debug
                if (_showDebugMessages)
                    Debug.Log($"{nameof(CameraLookEvents)} => {nameof(CastCameraRay)}  |  hit object {hitObject.name}");
                #endregion

                if (hitObject != _lookTarget)
                    UpdateLookTarget(hitObject);
            }
            else UpdateLookTarget(null);
        }

        /// <summary>
        /// Sets <see cref="_lookTarget">Look Target</see>, then the
        /// <see cref="_cameraLookTargetSignal">Camera Look Target Signal</see> emits the Look Target,
        /// and <see cref="OnLookTargetChanged">On Look Target Changed</see> is invoked.
        /// </summary>
        /// <param name="target">Value assigned to the look target.</param>
        private void UpdateLookTarget(GameObject target)
        {
            _lookTarget = target;
            OnLookTargetChanged.SafeInvoke(_lookTarget);
            if (_cameraLookTargetSignal.NotNull())
                _cameraLookTargetSignal.Emit(_lookTarget);
        }

        #endregion
    }
}