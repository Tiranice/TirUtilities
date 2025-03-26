using UnityEditor;

using UnityEngine;

using SceneManagement = UnityEditor.SceneManagement;
using UEditor = UnityEditor.Editor;

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

    using static ProjectEditorPaths;
    ///<!--
    /// MenuPageContextMenu.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  June 18, 2021
    /// Updated:  June 18, 2021
    /// -->
    /// <summary>
    /// Context menu to create new Menu Pages int he hierarchy.
    /// </summary>
    public class MenuPageContextMenu : UEditor
    {
        private const string _MenuPageContext = "GameObject/UI/Menu Page (TirUtilities)";

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
    }
}