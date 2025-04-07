using System.Collections.Generic;
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
///     You should have received a copy of the GNU General Public License
///     along with this program.  If not, see <https://www.gnu.org/licenses/>.
///-->

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

        public readonly int SceneCount => _additiveScenes is null ? 1 : 1 + _additiveScenes.Count;

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