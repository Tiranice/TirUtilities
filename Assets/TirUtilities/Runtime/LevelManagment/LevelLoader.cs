using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TirUtilities.LevelManagment
{
    ///<!--
    /// LevelLoader.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  May 05, 2021
    /// Updated:  July 01, 2021
    /// -->
    /// <summary>
    /// Loads scenes asynchronously when passed <see cref="LevelData"/>.
    /// </summary>
    // TODO:  Add a way to report loading progress to anyone who cares to have it.  Action maybe?
    public static class LevelLoader
    {
        #region Events & Signals

        public static event System.Action OnLoadComplete;

        #endregion

        #region Public Methods

        /// <summary>
        /// Loads the scene in the given level data.
        /// </summary>
        /// <param name="level">The data of the level being loaded.</param>
        /// <returns></returns>
        public static IEnumerator LoadLevelDataAsync(LevelData level)
        {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(level.ActiveScene);
            loadOperation.completed += operation => LevelLoader__completed(operation, level);

            yield return loadOperation;

            OnLoadComplete?.Invoke();
        }

        /// <summary> Load the additive scenes
        /// <param name="operation"></param>
        /// <param name="level"></param>
        private static void LevelLoader__completed(AsyncOperation operation, LevelData level)
        {
            // Kept for future use.
            _ = operation;

            foreach (string scene in level.AdditiveScenes)
                SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        }

        #endregion
    }
}