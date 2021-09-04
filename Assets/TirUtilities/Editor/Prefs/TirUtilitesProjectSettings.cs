using UnityEditor;
using UnityEngine;

namespace TirUtilities.Editor.Prefs
{
    using static ProjectEditorPaths;
    ///<!--
    /// TirUtilitesProjectSettings.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon
    /// Created:  Sep. 03, 2021
    /// Updated:  Sep. 03, 2021
    /// -->
    /// <summary>
    /// </summary>
    /// <remarks>
    /// Based on the ProjectPreferences class in the source of RainbowFolders.
    /// </remarks>
    public static class TirUtilitesProjectSettings
    {
        #region String Constants

        private const string _HomeFolderTooltip = "Change this setting to the new location of the " +
                                                  "\"TirUtilities\" folder if you move it from its " +
                                                  "default location in the project.";

        private const string _HomeFolderPrefKey = "TirUtilities.HomeFolder.";

        private const string _HomeFolderDefault = "Assets/TirUtilities";

        #endregion

        #region Editor Prefs Properties

        private static EditorPrefsString HomeFolderPref { get; }

        #endregion

        #region Public Properties

        public static string HomeFolder { get; set; }

        #endregion

        #region Constructor

        static TirUtilitesProjectSettings()
        {
            var homeLable = new GUIContent("Folder Location", _HomeFolderTooltip);
            HomeFolderPref = new EditorPrefsString($"{_HomeFolderPrefKey}{ProjectName}", homeLable, _HomeFolderDefault);
            HomeFolder = HomeFolderPref.Value;
        }

        #endregion

        #region Settings Provider

        [SettingsProvider]
        public static SettingsProvider CreateSettingsProvider() =>
            new SettingsProvider("TirUtilities/Preferences", SettingsScope.Project)
            {
                label = "Settings",
                guiHandler = searchContect =>
                {
                    EditorGUILayout.LabelField("General", EditorStyles.boldLabel);
                    EditorGUILayout.Separator();

                    HomeFolderPref.Draw();
                }
            };

        #endregion
    }
}