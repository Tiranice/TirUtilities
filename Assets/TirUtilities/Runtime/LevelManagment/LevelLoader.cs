using System.Collections;
using TirUtilities.Extensions;
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
    /// Updated:  May 15, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public static class LevelLoader
    {
        #region Events & Signals

        public static event System.Action OnLoadComplete;

        #endregion

        #region Public Methods

        public static IEnumerator LoadLevelDataAsync(LevelData level)
        {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(level.ActiveScene);
            yield return loadOperation;

            foreach (string scene in level.AddativeScenes)
            {
                AsyncOperation addativeOperation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
                yield return addativeOperation;
            }

            OnLoadComplete?.Invoke();
        }

        #endregion
    }
}