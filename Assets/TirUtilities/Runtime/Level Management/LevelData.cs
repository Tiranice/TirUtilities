using System.Collections.Generic;
using UnityEngine;

namespace TirUtilities.LevelManagment
{
    ///<!--
    /// LevelData.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  May 05, 2021
    /// Updated:  May 05, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    [System.Serializable]
    public struct LevelData
    {
        #region Fields

        [ScenePath][SerializeField] private string _activeScene;
        [ScenePath][SerializeField] private List<string> _addativeScenes;

        #endregion

        #region Constructor

        public LevelData(string activeScene, List<string> addativeScenes = null)
        {
            _activeScene = activeScene;
            _addativeScenes = addativeScenes;
        }

        #endregion

        #region Public Propitiates

        public string ActiveScene { get => _activeScene; }
        public List<string> AdditiveScenes { get => _addativeScenes; }

        #endregion
    }
}