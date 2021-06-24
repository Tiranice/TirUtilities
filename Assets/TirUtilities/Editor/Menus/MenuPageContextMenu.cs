using UnityEngine;
using UnityEditor;
using SceneManagement = UnityEditor.SceneManagement;
using UEditor = UnityEditor.Editor;

namespace TirUtilities.Editor
{
    using TirUtilities.Extensions;

    using static ProjectEditorPaths;
    ///<!--
    /// MenuPageContextMenu.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  June 18, 2021
    /// Updated:  June 18, 2021
    /// -->
    /// <summary>
    /// Context menu to create new Menu Pages int he hierarchy.
    /// </summary>
    public class MenuPageContextMenu : UEditor
    {
        #region Constants

        private const string _MenuPageContext = "GameObject/UI/Menu Page (TirUtilities)";

        #endregion

        #region Factory

        [MenuItem(_MenuPageContext)]
        internal static void MenuPageFactory(MenuCommand command)
        {
            Object prefab = AssetDatabase.LoadMainAssetAtPath(PathToMenuPagePrefab);

            if (prefab.IsNull())
            {
                Debug.LogError($"Prefab at path {PathToMenuPagePrefab} not found.  Please insure " +
                               $"that the folder structure and names of TirUtilities assets are " +
                               $"preserved, and that the prefab has been imported.");
                return;
            }

            var page = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
            SceneManagement.StageUtility.PlaceGameObjectInCurrentStage(page);

            Undo.RegisterCreatedObjectUndo(page, $"Create {page.name}");

            if (command.context is GameObject contextObject && contextObject.NotNull())
            {
                GameObjectUtility.SetParentAndAlign(page, contextObject);
                Undo.SetTransformParent(page.transform, contextObject.transform, $"Parent {page.name}");
            }
            Selection.activeObject = page;
        }

        #endregion
    }
}