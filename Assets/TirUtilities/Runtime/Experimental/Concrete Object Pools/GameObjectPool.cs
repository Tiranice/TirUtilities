using System.Collections.Generic;

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

namespace TirUtilities.Core.Experimental
{
    ///<!--
    /// GameObjectPool.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Sep 28, 2021
    /// Updated:  Oct 01, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    [System.Serializable]
    public class GameObjectPool
    {
        private const string _GeneratorFailed = "Attempt to spawn prefab from  GameObject pool " +
                                                "failed because none of the prefab's components " +
                                                "implement IPoolable.";

        #region Data Structures

        [Header("Object Pool Settings")]
        [SerializeField] private List<GameObject> _poolPrefabs;
        public List<GameObject> PoolPrefabs => _poolPrefabs;

        [SerializeField] private List<GameObject> _prepooledObjects = new();
        public IReadOnlyList<GameObject> PrepooledObjects => _prepooledObjects;

        public ObjectPool<GameObject> Pool { get; set; }

        #endregion

        #region Inspector Fields

        [SerializeField, Range(0, 100)] private int _prepoolAmount = 25;
        [SerializeField, Range(0, 100)] private int _maxPoolSize = 50;
        [SerializeField] private Transform _spawnPoint;

        #endregion

        #region Private Methods

        private GameObject Generator()
        {
            var instance = Object.Instantiate(_poolPrefabs[Random.Range(0, _poolPrefabs.Count)]);

            TryAssignReturnAction(instance);

            instance.transform.position = _spawnPoint.position;
            instance.transform.SetParent(_spawnPoint);
            instance.SetActive(false);
            return instance;
        }

        private void TryAssignReturnAction(GameObject instance)
        {
            try
            {
                if (!instance.TryGetComponent<IPoolable>(out var poolable))
                {
                    Object.Destroy(instance);
                    throw new MissingComponentException($"{_GeneratorFailed} | prefab => {instance.name}");
                }

                poolable.ReturnAction += () => Return(instance);
            }
            catch (MissingComponentException e)
            {
                Debug.LogException(e);
                throw;
            }
        }

        private void Return(GameObject item)
        {
            item.SetActive(false);
            item.transform.position = _spawnPoint.position;
            Pool.Return(item);
        }

        private void Disposer(GameObject item) => Object.Destroy(item);

        #endregion

        #region Public Methods

        public void FillPool()
        {
            foreach (var obj in _prepooledObjects)
                TryAssignReturnAction(obj);

            for (int i = _prepooledObjects.Count; i < _prepoolAmount; i++)
            {
                _prepooledObjects.Add(Generator());
                _prepooledObjects[i].name = $"{_prepooledObjects[i].name} ({i})";
            }

            Pool = new ObjectPool<GameObject>(_prepooledObjects, Generator, Disposer, _maxPoolSize);
        }

        public void Dispose() => Pool.Dispose();

        #endregion
    }
}