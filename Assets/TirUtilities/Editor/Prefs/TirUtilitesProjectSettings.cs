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
    /// Author :  Devon Wilson
    /// Created:  Sep. 03, 2021
    /// Updated:  Sep. 09, 2021
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
        private const string _AuthorNameTooltip = "This is the name that will be inserted into the" +
                                                  "#AUTHOR# placeholder in the script templates.";

        private const string _HomeFolderPrefKey = "TirUtilities.HomeFolder.";
        private const string _AuthorNamePrefKey = "TirUtilities.AuthorName.";

        private const string _HomeFolderDefault = "Assets/TirUtilities";
        private const string _AuthorNameDefault = "AuthorName";

        #endregion

        #region Editor Prefs Properties

        private static EditorPrefsString HomeFolderPref { get; }
        private static EditorPrefsString AuthorNamePref { get; }

        #endregion

        #region Public Properties

        public static string HomeFolder { get; private set; }
        public static string AuthorName { get; private set; }

        #endregion

        #region Constructor

        static TirUtilitesProjectSettings()
        {
            var homeLabel = new GUIContent("Folder Location", _HomeFolderTooltip);
            var authorLabel = new GUIContent("Author Name", _AuthorNameTooltip);
            HomeFolderPref = new EditorPrefsString($"{_HomeFolderPrefKey}{ProjectName}",
                                                   homeLabel,
                                                   _HomeFolderDefault);

            AuthorNamePref = new EditorPrefsString($"{_AuthorNamePrefKey}{ProjectName}",
                                                   authorLabel,
                                                   _AuthorNameDefault);
            HomeFolder = HomeFolderPref;
            AuthorName = AuthorNamePref;
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

                    EditorGUILayout.Separator();

                    EditorGUILayout.LabelField("Script Template Placeholders", EditorStyles.boldLabel);
                    EditorGUILayout.Separator();
                    
                    AuthorNamePref.Draw();
                }
            };

        #endregion
    }
}