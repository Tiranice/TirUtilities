namespace TirUtilities.Editor
{
    using static TirUtilities.Editor.Prefs.TirUtilitesProjectSettings;
    ///<!--
    /// ProjectPaths.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Jun 18, 2021
    /// Updated:  May 03, 2022
    /// -->
    /// <summary>
    /// Paths to important locations used by editor scripts.
    /// </summary>
    public readonly ref struct ProjectEditorPaths
    {
        private const string _Prefabs = @"/Resources/Prefabs";

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
            $@"{HomeFolder}{_Prefabs}/MenuPageCanvas.prefab";

        public static string PathToLevelSystemPrefab =>
            $@"{HomeFolder}{_Prefabs}/LevelSystem.prefab";

        public static string PathToRootMenuPrefab =>
            $@"{HomeFolder}{_Prefabs}/RootCanvas.prefab";

        public static string PathToTriggerVolume =>
            $@"{HomeFolder}{_Prefabs}/Trigger Volume.prefab";
    }
}