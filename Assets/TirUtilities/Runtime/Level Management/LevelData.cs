using System.Collections.Generic;
using UnityEngine;

namespace TirUtilities.LevelManagement
{
    ///<!--
    /// LevelData.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  May 05, 2021
    /// Updated:  Oct 09, 2023
    /// -->
    /// <summary>
    ///
    /// </summary>
    [System.Serializable]
    public struct LevelData
    {
        #region Fields

        [ScenePath][SerializeField] private string _activeScene;
        [ScenePath][SerializeField] private List<string> _additiveScenes;

        #endregion

        #region Constructor

        public LevelData(string activeScene, List<string> additiveScenes = null)
        {
            _activeScene = activeScene;
            _additiveScenes = additiveScenes;
        }

        #endregion

        #region Public Propitiates

        public readonly string ActiveScene => _activeScene;
        public readonly IReadOnlyList<string> AdditiveScenes => _additiveScenes;

        #endregion
    }
}