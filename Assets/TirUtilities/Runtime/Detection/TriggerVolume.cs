using TirUtilities.CustomEvents;
using UnityEngine;

namespace TirUtilities.Detection
{
    ///<!--
    /// TriggerVolume.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Created:  Jan. 20, 2021
    /// Updated:  May 05, 2021
    /// -->
    /// <summary>
    /// Checks if the object that enter's its collider is on a layer in the layer mask.  If it was,
    /// <see cref="OnEnterVolume">On Enter Volume</see> is invoked.
    /// </summary>
    [AddComponentMenu("TirUtilities/Detection/Trigger Volume")]
    [RequireComponent(typeof(Collider))]
    public class TriggerVolume : MonoBehaviour
    {
        #region Inspector Fields

        [Tooltip("Objects on these layers will trigger OnEnterVolume")]
        [SerializeField] private LayerMask _targetLayers;
        [Space]

        #endregion

        #region Events

        /// <summary>
        /// Subscribed methods will be passed a true and the game object that entered the volume.
        /// </summary>
        [SerializeField] private BoolEvent OnEnterVolume;

        #endregion

        #region Unity Messages

        private void Awake() => ColliderSetup();

        private void OnTriggerEnter(Collider other) => CheckGameObjectLayers(other, true);

        private void OnTriggerExit(Collider other) => CheckGameObjectLayers(other, false);

        #endregion

        #region Private Methods

        /// <summary>
        /// Sets mesh colliders to convex & all colliders isTrigger to true.
        /// </summary>
        private void ColliderSetup()
        {
#if UNITY_2019_2_OR_NEWER
            if (TryGetComponent(out Collider collider))
            {
                if (collider is MeshCollider meshCollider)
                    meshCollider.convex = true;

                collider.isTrigger = true;
            }
#else
            if (GetComponent<Collider>() is Collider collider)
            {
                if (collider is MeshCollider meshCollider)
                    meshCollider.convex = true;

                collider.isTrigger = true;
            }
#endif
        }

        /// <summary>
        /// Checks if the layer of the colliding game object is covered by the layer mask.
        /// </summary>
        /// <remarks>
        /// If it is, then <see cref="OnEnterVolume"/> is invoked passing the other collider
        /// and true if the object is entering or false if the object is exiting.
        /// </remarks>
        /// <param name="other">The collider of the other game object</param>
        /// <param name="entered">Whether or not the collider is entering or exiting the volume.</param>
        private void CheckGameObjectLayers(Collider other, bool entered)
        {
            if (LayerInMask(other.gameObject.layer))
                OnEnterVolume.Invoke(entered, other.gameObject);
        }

#endregion

#region Bit Magic Properties

        /// <summary>
        /// Do some fuckin' bit MAGIC!!!
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        private bool LayerInMask(int layer) => (1 << layer & _targetLayers) != 0;

#endregion
    }
}