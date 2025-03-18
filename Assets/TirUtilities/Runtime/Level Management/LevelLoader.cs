using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace TirUtilities.LevelManagement
{
    ///<!--
    /// LevelLoader.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  May 05, 2021
    /// Updated:  Oct 16, 2023
    /// -->
    /// <summary>
    /// Loads scenes asynchronously when passed <see cref="LevelData"/>.
    /// </summary>
    public static class LevelLoader
    {
        #region Static Fields

        /// <summary> Counts the number of additive loads that have completed. </summary>
        private static int _CompleteAsyncOperations = 0;

        /// <summary> Progress through the loading process. </summary>
        private static float _ProgressAsyncOperations = 0;

        #endregion

        #region Public Properties

        /// <summary> Progress through the loading process. </summary>
        public static float ProgressAsyncOperations => _ProgressAsyncOperations;

        #endregion

        #region Events & Signals

        /// <summary> Invoked once all load operations have completed. </summary>
        public static event System.Action OnLoadComplete;

        /// <summary> 
        /// Invoked whenever the progress of an async operation is completed while loading
        /// additive scenes.
        /// </summary>
        public static event System.Action OnProgressUpdated;

        #endregion

        #region Public Methods

        /// <summary> Loads the scene in the given level data. </summary>
        /// <param name="level">The data of the level being loaded.</param>
        /// <returns> AsyncOperation that loads the active scene. </returns>
        public static IEnumerator LoadLevelDataAsync(LevelData level)
        {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(level.ActiveScene);
            loadOperation.completed += operation => LevelLoader__completed(operation, level);

            while (!loadOperation.isDone)
            {
                yield return null;
            }
            yield return loadOperation;
        }

        #endregion

        #region Event Listeners

        /// <summary> 
        /// Load the additive scenes, then invokes <see cref="OnLoadComplete"/> after all loads
        /// have completed.
        /// </summary>
        /// <param name="operation"> Operation who's completion triggers this. </param>
        /// <param name="level"> Level data who's additive scenes should be loaded. </param>
        private static void LevelLoader__completed(AsyncOperation operation, LevelData level)
        {
            // Kept for future use.
            _ = operation;

            if (level.AdditiveScenes is null || (level.AdditiveScenes.Count == 0))
            {
                _ProgressAsyncOperations = 1;
                OnLoadComplete?.Invoke();
                return;
            }

            _CompleteAsyncOperations = 0;

            foreach (string scene in level.AdditiveScenes)
            {
                var op = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
                op.completed += AsyncOperation__completed;
            }

            void AsyncOperation__completed(AsyncOperation op)
            {
                _CompleteAsyncOperations++;

                _ProgressAsyncOperations = (_CompleteAsyncOperations + op.progress) / level.SceneCount;
                OnProgressUpdated?.Invoke();

                if (_CompleteAsyncOperations == level.AdditiveScenes.Count)
                    OnLoadComplete?.Invoke();
            }
        }
        #endregion
    }
}