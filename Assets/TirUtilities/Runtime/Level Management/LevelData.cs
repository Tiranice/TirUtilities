using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace TirUtilities.LevelManagement
{
    ///<!--
    /// LevelData.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  May 05, 2021
    /// Updated:  Feb 22, 2024
    /// -->
    /// <summary>
    /// Data container for the <see cref="LevelSystem"/>.
    /// </summary>
    [System.Serializable]
    public struct LevelData : System.IEquatable<LevelData>
    {
        #region Fields

        [SerializeField] private string _levelName;
        public readonly string LevelName => _levelName;
        [Space]
        [ScenePath][SerializeField] private string _activeScene;
        public readonly string ActiveScene => _activeScene;

        [ScenePath][SerializeField] private List<string> _additiveScenes;
        public readonly IReadOnlyList<string> AdditiveScenes => _additiveScenes;

        #endregion

        #region Constructor

        public LevelData(string levelName, string activeScene, List<string> additiveScenes = null)
        {
            _levelName = levelName;
            _activeScene = activeScene;
            _additiveScenes = additiveScenes ?? new List<string>();
        }

        public LevelData(string activeScene, List<string> additiveScenes = null)
            : this(string.Empty, activeScene, additiveScenes) { }

        #endregion

        #region Public Propitiates

        public readonly int SceneCount => _additiveScenes is null ? 1 : 1 + _additiveScenes.Count;

        #endregion

        #region IEquatable

        public override readonly bool Equals(object obj) => Equals((LevelData)obj);

        public readonly bool Equals(LevelData other) =>
            other.GetType() == GetType()
            && other._levelName == _levelName
            && other._activeScene == _activeScene
            && other.SceneCount == SceneCount
            && other._additiveScenes.SequenceEqual(_additiveScenes);

        public override readonly int GetHashCode() => (_activeScene, _additiveScenes).GetHashCode();

        public static bool operator ==(LevelData left, LevelData right) => left.Equals(right);
        public static bool operator !=(LevelData left, LevelData right) => !(left == right);

        #endregion
    }
}