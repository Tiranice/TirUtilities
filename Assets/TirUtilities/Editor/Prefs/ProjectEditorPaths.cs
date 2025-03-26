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
    using static TirUtilities.Editor.Prefs.TirUtilitiesProjectSettings;
    ///<!--
    /// ProjectPaths.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Jun 18, 2021
    /// Updated:  Mar 26, 2025
    /// -->
    /// <summary>
    /// Paths to important locations used by editor scripts.
    /// </summary>
    public readonly ref struct ProjectEditorPaths
    {
        private const string _Prefabs = @"/Resources/Prefabs";

        public static string ProjectName => UnityEngine.Application.dataPath.Split('/')[^2];

        public static string PathToHierarchyDividerSettings =>
            $@"{HomeFolder}/Resources/SettingsAssets/HierarchyDividerSettings.asset";

        public static string PathToMenuPagePrefab =>
            $@"{HomeFolder}{_Prefabs}/MenuPageCanvas.prefab";

        public static string PathToLevelSystemPrefab =>
            $@"{HomeFolder}{_Prefabs}/LevelSystem.prefab";

        public static string PathToRootMenuPrefab =>
            $@"{HomeFolder}{_Prefabs}/RootCanvas.prefab";

        //TODO:  Decide whether or not I'm allowing spaces
        public static string PathToTriggerVolume =>
            $@"{HomeFolder}{_Prefabs}/Trigger Volume.prefab";
    }
}