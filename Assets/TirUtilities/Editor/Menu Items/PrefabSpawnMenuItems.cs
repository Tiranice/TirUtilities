using UnityEditor;
using UnityEngine;

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
    /// Created:  Sep. 09, 2021
    /// Updated:  Sep. 09, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    internal static class PrefabSpawnMenuItems
    {
        private const string _RootPath = "TirUtilities/Prefabs/";

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
