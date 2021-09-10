namespace TirUtilities.Editor
{
    using static TirUtilities.Editor.Prefs.TirUtilitesProjectSettings;
    ///<!--
    /// ProjectPaths.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  June 18, 2021
    /// Updated:  Sep. 09, 2021
    /// -->
    /// <summary>
    /// Paths to important locations used by editor scripts.
    /// </summary>
    public readonly ref struct ProjectEditorPaths
    {
        public static string ProjectName
        {
            get
            {
                var splitPath = UnityEngine.Application.dataPath.Split('/');
                return splitPath[splitPath.Length - 2];
            }
        }

        public static string PathToHierarchyDividerSettings => 
            $@"{HomeFolder}/Resources/SettingsAssets/HierarchyDividerSettings.asset";

        public static string PathToMenuPagePrefab =>
            $@"{HomeFolder}/Resources/Prefabs/MenuPageCanvas.prefab";

        public static string PathToLevelSystemPrefab =>
            $@"{HomeFolder}/Resources/Prefabs/LevelSystem.prefab";

        public static string PathToRootMenuPrefab =>
            $@"{HomeFolder}/Resources/Prefabs/RootCanvas.prefab";
    }
}