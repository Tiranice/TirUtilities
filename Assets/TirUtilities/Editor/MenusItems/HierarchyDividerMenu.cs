using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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

        private static readonly List<GameObject> _Dividers = new List<GameObject>();

        #endregion

        #region Menu Items

        /// <summary>
        /// Create the divider empties in the hierarchy.
        /// </summary>
        [MenuItem("TirUtilities/Hierarchy/Create Dividers", priority = 1)]
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
        [MenuItem("TirUtilities/Hierarchy/Destroy Dividers", priority = 2)]
        internal static void DestroyHierarchyDividers()
        {
            if (_Dividers.IsNullOrEmpty()) return;

            foreach (var divider in _Dividers)
                GameObject.DestroyImmediate(divider, false);

            _Dividers.Clear();
        }

        /// <summary> Selects the settings asset. </summary>
        [MenuItem("TirUtilities/Hierarchy/Select Divider Settings", priority = 10)]
        internal static void SelectHierarchyDividerSettings() => 
            Selection.activeObject = _Settings;

        #endregion
    }
}
