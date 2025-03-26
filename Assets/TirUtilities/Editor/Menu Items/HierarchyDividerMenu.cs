using System.Collections.Generic;

using UnityEditor;

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

namespace TirUtilities.Editor
{
    using TirUtilities.Extensions;
    using TirUtilities.SettingsAssets;

    using static ProjectEditorPaths;

    ///<!--
    /// HeirarchDividers.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  May 16, 2021
    /// Updated:  May 19, 2021
    /// -->
    /// <summary>
    /// Creates/Destroys dividers in the hierarchy.
    /// <para>See Also — <seealso cref="HierarchyDividerSettings"/></para>
    /// </summary>
    [InitializeOnLoad]
    internal static class HierarchyDividerMenu
    {
        #region Constructor

        static HierarchyDividerMenu() =>
            _Settings = AssetDatabase.LoadAssetAtPath<HierarchyDividerSettings>(PathToHierarchyDividerSettings);

        #endregion

        #region Fields

        private static readonly HierarchyDividerSettings _Settings;

        private static readonly List<GameObject> _Dividers = new();

        private const string _ToolPath = @"Tools/TirUtilities/Hierarchy/";

        #endregion

        #region Menu Items

        /// <summary>
        /// Create the divider empties in the hierarchy.
        /// </summary>
        [MenuItem(_ToolPath + "Create Dividers", priority = 1)]
        internal static void CreateHierarchyDividers()
        {
            foreach (string divider in _Settings.Dividers)
            {
                var newDivider = new GameObject(divider);
                _Dividers.Add(newDivider);
            }
        }

        /// <summary>
        /// Destroy the divider empties in the hierarchy.
        /// </summary>
        [MenuItem(_ToolPath + "Destroy Dividers", priority = 2)]
        internal static void DestroyHierarchyDividers()
        {
            if (_Dividers.IsNullOrEmpty()) return;

            foreach (var divider in _Dividers)
                GameObject.DestroyImmediate(divider, false);

            _Dividers.Clear();
        }

        /// <summary> Selects the settings asset. </summary>
        [MenuItem(_ToolPath + "Select Divider Settings", priority = 10)]
        internal static void SelectHierarchyDividerSettings() =>
            Selection.activeObject = _Settings;

        #endregion
    }
}
