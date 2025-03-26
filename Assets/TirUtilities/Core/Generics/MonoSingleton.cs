using System.Linq;

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
///     You should have received a copy of the GNU Lesser General Public License
///     along with this program.  If not, see <https://www.gnu.org/licenses/>.
///-->

namespace TirUtilities.Generics
{
    using TirUtilities.Extensions;
    ///<!--
    /// MonoSingleton.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Jan 21, 2022
    /// Updated:  Feb 22, 2024
    /// -->
    /// <summary>
    /// Extend to create singletons from <c>MonoBehaviour</c>s that can be lazy loaded from 
    /// resources using <see cref="ResourceSingletonAttribute"/> or instantiated at runtime.
    /// Lazy loaded and runtime instantiated singletons will be moved to DontDestroyOnLoad.
    /// </summary>
    /// <example>
    ///     <code>
    ///     // Located at Resources/Singletons/Example Singleton.prefab
    ///     [ResourceSingleton("Singletons/Example Singleton")]
    ///     public class ExampleSingleton : MonoSingleton&lt;ExampleSingleton&gt;
    ///     {
    ///         public void DoStuff()
    ///         {
    ///             //  Does stuff
    ///         }
    ///     }
    ///     
    ///     public class StuffDoer : MonoBehaviour
    ///     {
    ///         private void Awake()
    ///         {
    ///             ExampleSingleton.Instance.DoStuff();
    ///         }
    ///     }
    ///     </code>
    /// </example>
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        #region Error Messages

        private const string _Singleton = "<color=green>[Singleton]</color>";
        private const string _TooManyInstances =
            _Singleton + " Something went really wrong  - there should never be more than one " +
            "singleton! Reopening the scene might fix it.";

        #endregion

        #region Static Fields

        private static T _instance;
        private static readonly object _lock = new();
        private static bool _isShuttingDown = false;

        #endregion

        public static T Instance
        {
            get
            {
                if (_isShuttingDown)
                {
                    Debug.LogWarning($"{_Singleton} Instance '{typeof(T)}' already destroyed" +
                                     $" on application quit. Won't create again - returning null.");
                    return default;
                }
                lock (_lock)
                {
                    return _instance.NotNull() ? _instance : FetchOrCreateInstance();
                }
            }
        }

        private static T FetchOrCreateInstance()
        {
            _instance = FindObjectOfType(typeof(T)) as T;

            if (FindObjectsOfType(typeof(T)).Length > 1)
            {
                Debug.LogError(_TooManyInstances);
                Debug.Break();
                return _instance;
            }

            if (_instance.NotNull())
            {
                Debug.Log($"{_Singleton} Using instance already created: {_instance.gameObject.name}");
                return _instance;
            }
            return LoadResourceSingleton();
        }

        private static T LoadResourceSingleton()
        {
            ResourceSingletonAttribute singletonAttribute = FindAttribute();
            if (singletonAttribute != null)
            {
                GameObject original = Resources.Load<GameObject>(singletonAttribute.resourceFilePath);
                if (original.IsNull())
                {
                    Debug.LogError($"The Resource Singleton {typeof(T)} was not found in any" +
                                   $" resources folder!");
                    Debug.Break();
                    return default;
                }
                CloneFromOriginal(original);
            }
            else
            {
                _instance = new GameObject($"(Global Singleton) {typeof(T)}").AddComponent<T>();
                DontDestroyOnLoad(_instance.gameObject);
                Debug.Log($"{_Singleton} An instance of {typeof(T)} is needed in the scene, " +
                          $"so '{_instance.gameObject}' was created with DontDestroyOnLoad.");
            }
            return _instance;
        }

        private static ResourceSingletonAttribute FindAttribute()
        {
            ResourceSingletonAttribute singletonAttribute = null;
            foreach (System.Attribute customAttribute in typeof(T).GetCustomAttributes(false).Cast<System.Attribute>())
            {
                if (customAttribute is ResourceSingletonAttribute attribute)
                {
                    singletonAttribute = attribute;
                    break;
                }
            }

            return singletonAttribute;
        }

        private static void CloneFromOriginal(GameObject original)
        {
            GameObject target = Instantiate(original);
            target.name = $"(Resource Global Singleton) {target.name}";
            _instance = target.GetComponent<T>();
            if (_instance.IsNull())
            {
                Debug.LogError("A prefab was loaded for the singleton, but the component was not on it!");
                Debug.Break();
            }
            else
            {
                DontDestroyOnLoad(target);
                Debug.Log($"{_Singleton} An instance of {typeof(T)} is needed in the scene, " +
                          $"so '{target}' was loaded as a prefab with DontDestroyOnLoad.");
            }
        }

        protected void OnApplicationQuit()
        {
            _isShuttingDown = true;
            Teardown();
        }

        protected virtual void Teardown() { }
    }
}