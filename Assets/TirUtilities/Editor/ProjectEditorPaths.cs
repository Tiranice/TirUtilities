namespace TirUtilities.Editor
{
    ///<!--
    /// ProjectPaths.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  June 18, 2021
    /// Updated:  June 18, 2021
    /// -->
    /// <summary>
    /// Paths to important locations used by editor scripts.
    /// </summary>
    public readonly ref struct ProjectEditorPaths
    {
        public static string PathToHierarchyDividerSettings => 
            @"Assets/TirUtilities/Resources/SettingsAssets/HierarchyDividerSettings.asset";

        public static string PathToMenuPagePrefab =>
            @"Assets/TirUtilities/Resources/Prefabs/MenuPageCanvas.prefab";
    }
}