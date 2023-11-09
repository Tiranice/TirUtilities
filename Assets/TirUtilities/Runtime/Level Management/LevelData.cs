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
    /// Updated:  Oct 16, 2023
    /// -->
    /// <summary>
    /// Data container for the <see cref="LevelSystem"/>.
    /// </summary>
    [System.Serializable]
    public struct LevelData : System.IEquatable<LevelData>
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
        public readonly int SceneCount => _additiveScenes is null ? 1 : 1 + _additiveScenes.Count;

        #endregion

        #region IEquatable

        public override readonly bool Equals(object obj) => Equals((LevelData)obj);

        public readonly bool Equals(LevelData other)
        {
            if (GetType() != other.GetType()) return false;

            if (other._activeScene != _activeScene) return false;

            if (other.SceneCount != SceneCount) return false;

            if (other._additiveScenes != _additiveScenes) return false;

            if (_additiveScenes != null)
            {
                for (int i = 0; i < _additiveScenes.Count; i++)
                {
                    if (other._additiveScenes[i] != _additiveScenes[i]) return false;
                }
            }

            return true;
        }

        public override readonly int GetHashCode() => (_activeScene, _additiveScenes).GetHashCode();

        public static bool operator ==(LevelData left, LevelData right) => left.Equals(right);
        public static bool operator !=(LevelData left, LevelData right) => !(left == right); 

        #endregion
    }
}