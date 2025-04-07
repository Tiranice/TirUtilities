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

namespace TirUtilities.Core.Experimental
{
    using TirUtilities.Detection.Experimental;
    using TirUtilities.Extensions;
    ///<!--
    /// SpawningPool.cs
    ///
    /// Project:  Prototype 4
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Sep 28, 2021
    /// Updated:  Sep 28, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public class SpawningPool : MonoBehaviour
    {
        #region Inspector Fields

        [SerializeField] private GameObjectPool _objectPool;

        [Header("Spawn Settings")]
        [Tooltip("The number of seconds until the spawner starts.")]
        [SerializeField, Range(1.0f, 5.0f)] private float _startDelay = 3.0f;
        [Tooltip("The number of seconds between spawns.")]
        [SerializeField, Range(0.0f, 600.0f)] private float _spawnRate = 1.0f;
        [Space]
        [SerializeField] private bool _startOnEnable = true;
        [SerializeField] private bool _isSpawning = true;
        [SerializeField] private SpawnZone _spawnZone;

        [Header("Spawned Object Settings")]
        [SerializeField] private bool _freezeRigidbody = false;

        #endregion

        #region Events & Signals

        [Header("Unity Events")]
        public UnityEvent OnSpawningStarted;
        public UnityEvent OnSpawningStopped;

        #endregion

        #region Unity Messages

        private void Start() => _objectPool.FillPool();
        private void OnEnable()
        {
            _isSpawning = _startOnEnable;
            if (!_startOnEnable) return;

            StartSpawing();
        }

        private void OnDisable() => StopSpawning();
        private void OnDestroy() => _objectPool.Dispose();

        #endregion

        #region Private Methods

        private void Spawn()
        {
            if (!_isSpawning) return;

            if (_objectPool.Pool.TryRequest(out var item))
            {
                if (_spawnZone.NotNull())
                {
                    var pos = _spawnZone.GetRandomPosition();
                    //Debug.Log(pos);
                    item.transform.localPosition = pos;
                }
                if (item.TryGetComponent(out Rigidbody rigidbody))
                    rigidbody.constraints = _freezeRigidbody ? RigidbodyConstraints.FreezeAll : rigidbody.constraints;

                item.SetActive(true);
            }
        }

        #endregion

        #region Public Methods

        public void SpawnOneShot()
        {
            _isSpawning = true;
            OnSpawningStarted.SafeInvoke();

            Spawn();

            _isSpawning = false;
            OnSpawningStopped.SafeInvoke();
        }

        public void StartSpawing()
        {
            if ((_spawnRate == 0) || _isSpawning) return;

            _isSpawning = true;
            OnSpawningStarted.SafeInvoke();
            InvokeRepeating(nameof(Spawn), _startDelay, _spawnRate);
        }

        public void StopSpawning()
        {
            if (!_isSpawning) return;

            _isSpawning = false;
            OnSpawningStopped.SafeInvoke();
            CancelInvoke(nameof(Spawn));
        }

        #endregion
    }
}