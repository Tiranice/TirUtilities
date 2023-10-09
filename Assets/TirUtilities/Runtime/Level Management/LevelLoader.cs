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
    /// Updated:  Aug. 22, 2021
    /// -->
    /// <summary>
    /// Loads scenes asynchronously when passed <see cref="LevelData"/>.
    /// </summary>
    // TODO:  Add a way to report loading progress to anyone who cares to have it.  Action maybe?
    public static class LevelLoader
    {
        #region Private Fields

        /// <summary> Counts the number of additive loads that have completed. </summary>
        private static int _CompleteAsyncOperations = 0;

        #endregion

        #region Events & Signals

        /// <summary> Invoked once all load operations have completed. </summary>
        public static event System.Action OnLoadComplete;

        #endregion

        #region Public Methods

        /// <summary> Loads the scene in the given level data. </summary>
        /// <param name="level">The data of the level being loaded.</param>
        /// <returns> AsyncOperation that loads the active scene. </returns>
        public static IEnumerator LoadLevelDataAsync(LevelData level)
        {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(level.ActiveScene);
            loadOperation.completed += operation => LevelLoader__completed(operation, level);

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

            if (level.AdditiveScenes.Count == 0)
            {
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
                _ = op;

                _CompleteAsyncOperations++;
                if (_CompleteAsyncOperations == level.AdditiveScenes.Count)
                    OnLoadComplete?.Invoke();
            }
        }
        #endregion
    }
}