using UnityEditor;
using SceneManagement = UnityEditor.SceneManagement;

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
    using static ProjectEditorPaths;

    ///<!--
    /// GameObjectContextMenuItems.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  May 03, 2022
    /// Updated:  May 03, 2022
    /// -->
    /// <summary>
    /// Context menus for the hierarchy GameObject right-click menu.
    /// </summary>
    public class GameObjectContextMenuItems : UnityEditor.Editor
    {
        private const string _TriggerVolumeContext = "GameObject/3D Object/Trigger Volume (TirUtilities)";

        [MenuItem(_TriggerVolumeContext)]
        internal static void TriggerVolumeFactory(MenuCommand command) => PrefabFactory(PathToTriggerVolume, command);

        #region Prefab Factory

        /// <summary> Instantiates the prefab found at the given path. </summary>
        /// <remarks> Also registers a created object undo. </remarks>
        /// <param name="path"></param>
        /// <param name="command"></param>
        internal static void PrefabFactory(string path, MenuCommand command)
        {
            Object prefab = AssetDatabase.LoadMainAssetAtPath(path);

            if (prefab.IsNull())
            {
                Debug.LogError($"Prefab at path {path} not found.  Please insure " +
                               $"that the folder structure and names of TirUtilities assets are " +
                               $"preserved, and that the prefab has been imported.");
                return;
            }

            var instance = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
            SceneManagement.StageUtility.PlaceGameObjectInCurrentStage(instance);

            Undo.RegisterCreatedObjectUndo(instance, $"Create {instance.name}");

            if (command.context is GameObject contextObject && contextObject.NotNull())
            {
                GameObjectUtility.SetParentAndAlign(instance, contextObject);
                Undo.SetTransformParent(instance.transform, contextObject.transform, $"Parent {instance.name}");
            }
            Selection.activeObject = instance;
        }

        #endregion
    }
}