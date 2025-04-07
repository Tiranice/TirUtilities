using UnityEngine;
using UnityEngine.Events;

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

namespace TirUtilities.Detection
{
    using TirUtilities.CustomEvents;
    using TirUtilities.Extensions;

    ///<!--
    /// TriggerVolume.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Jan 20, 2021
    /// Updated:  May 04, 2022
    /// -->
    /// <summary>
    /// Checks if the object that enter's its collider is on a layer in the layer mask.  If it was,
    /// <see cref="OnEnterVolume"/> is invoked.
    /// </summary>
    [AddComponentMenu("TirUtilities/Detection/Trigger Volume")]
    [RequireComponent(typeof(Collider)), SelectionBase]
    public class TriggerVolume : MonoBehaviour
    {
        #region Inspector Fields

        [Tooltip("Objects on these layers will trigger OnEnterVolume")]
        [SerializeField] private LayerMask _targetLayers;
        [Space]

        #endregion

        #region Events

        [Header("Trigger Volume Event")]
        /// <summary>
        /// Subscribed methods will be passed a true and the game object that entered the volume.
        /// </summary>
        [SerializeField] private TriggerVolumeEvent OnEnterVolume;
        [Space(20)]
        [Header("Unity Events")]
        [SerializeField] private UnityEvent OnTriggerEntered;
        [SerializeField] private UnityEvent OnTriggerExited;

        public System.Action<bool, GameObject> OnVolumeTriggered;

        #endregion

        #region Unity Messages

        private void Awake() => ColliderSetup();

        private void OnTriggerEnter(Collider other) => CheckGameObjectLayers(other, true);

        private void OnTriggerExit(Collider other) => CheckGameObjectLayers(other, false);

        #endregion

        #region Private Methods

        /// <summary>
        /// Sets mesh colliders to convex and all colliders isTrigger to true.
        /// </summary>
        private void ColliderSetup()
        {
            if (TryGetComponent(out Collider collider))
            {
                if (collider is MeshCollider meshCollider)
                    meshCollider.convex = true;

                collider.isTrigger = true;
            }
        }

        /// <summary>
        /// Checks if the layer of the colliding game object is covered by the layer mask.
        /// </summary>
        /// <remarks>
        /// If it is, then <see cref="OnEnterVolume"/> is invoked passing the other collider
        /// and true if the object is entering or false if the object is exiting.
        /// </remarks>
        /// <param name="other">The collider of the other game object.</param>
        /// <param name="entered">Whether or not the collider is entering or exiting the volume.</param>
        private void CheckGameObjectLayers(Collider other, bool entered)
        {
            if (!_targetLayers.LayerInMask(other.gameObject.layer)) return;

            OnEnterVolume.SafeInvoke(entered, other.gameObject);
            OnVolumeTriggered?.Invoke(entered, other.gameObject);

            if (entered) OnTriggerEntered.SafeInvoke();
            else OnTriggerExited.SafeInvoke();
        }

        #endregion

        public LayerMask TargetLayers { get => _targetLayers; set => _targetLayers = value; }
    }
}