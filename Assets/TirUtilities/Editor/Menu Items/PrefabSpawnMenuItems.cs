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

    using static TirUtilities.Editor.ProjectEditorPaths;
    ///<!--
    /// PrefabSpawnMenuItems.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Sep. 09, 2021
    /// Updated:  Sep. 09, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    internal static class PrefabSpawnMenuItems
    {
        private const string _RootPath = "Tools/TirUtilities/Prefabs/";

        //TODO:  This functionality should be extracted to a static utility.
        internal static void SpawnPrefabInCurrentStage(string prefabPath, MenuCommand command)
        {
            Object prefab = AssetDatabase.LoadMainAssetAtPath(prefabPath);

            if (prefab.IsNull())
            {
                Debug.LogError($"Prefab at path {prefabPath} not found.  Please insure " +
                               $"that the folder structure and names of TirUtilities assets are " +
                               $"preserved, and that the prefab has been imported.");
                return;
            }

            var page = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
            UnityEditor.SceneManagement.StageUtility.PlaceGameObjectInCurrentStage(page);

            Undo.RegisterCreatedObjectUndo(page, $"Create {page.name}");

            if (command.context is GameObject contextObject && contextObject.NotNull())
            {
                GameObjectUtility.SetParentAndAlign(page, contextObject);
                Undo.SetTransformParent(page.transform, contextObject.transform, $"Parent {page.name}");
            }
            Selection.activeObject = page;
        }

        /// <summary> Creates a copy of the level system prefab. </summary>
        [MenuItem(_RootPath + "Level System")]
        internal static void SpawnLevelSystem(MenuCommand command) =>
            SpawnPrefabInCurrentStage(PathToLevelSystemPrefab, command);

        /// <summary> Creates a copy of the root menu prefab. </summary>
        [MenuItem(_RootPath + "Root Menu")]
        internal static void SpawnRootMenu(MenuCommand command) =>
            SpawnPrefabInCurrentStage(PathToRootMenuPrefab, command);
    }
}
