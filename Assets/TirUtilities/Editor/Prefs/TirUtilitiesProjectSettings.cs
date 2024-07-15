using UnityEditor;
using UnityEngine;

namespace TirUtilities.Editor.Prefs
{
    using static ProjectEditorPaths;
    ///<!--
    /// TirUtilitiesProjectSettings.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Compony:  Black Phoenix Creative
    /// Created:  Sep. 03, 2021
    /// Updated:  May. 29, 2024
    /// -->
    /// <summary>
    /// Controls the settings menu displayed in Unity's project settings window.
    /// </summary>
    /// <remarks>
    /// Based on the ProjectPreferences class in the source of RainbowFolders.
    /// </remarks>
    public static class TirUtilitiesProjectSettings
    {
        #region String Constants

        //==============================| Tooltips |==============================//
        private const string _HomeFolderTooltip = "Change this setting to the new location of the " +
                                                  "\"TirUtilities\" folder if you move it from its " +
                                                  "default location in the project.";
        private const string _AuthorNameTooltip = "This is the name that will be inserted into the" +
                                                  "placeholder in the script templates.";
        private const string _AutoVersionNumberTooltip = "Toggles a build preprocessor that sets " +
                                                         "the bundle version based on the git tags " +
                                                         "and current branch.";

        //================================| Keys |================================//
        private const string _HomeFolderPrefKey = "TirUtilities.HomeFolder.";
        private const string _AuthorNamePrefKey = "TirUtilities.AuthorName.";
        private const string _AutoVersionNumberPrefKey = "TirUtilities.AutoVersionNumber.";

        //==============================| Defaults |==============================//
        private const string _HomeFolderDefault = "Assets/TirUtilities";
        private const string _AuthorNameDefault = "AuthorName";
        private const bool _AutoVersionNumberDefalut = false;

        #endregion

        #region Editor Prefs Properties

        private static EditorPrefsString HomeFolderPref { get; }
        private static EditorPrefsString AuthorNamePref { get; }
        private static EditorPrefsBool AutoVersionNumberPref { get; }

        #endregion

        #region Public Properties

        public static string HomeFolder { get; private set; }
        public static string AuthorName { get; private set; }
        public static bool DoAutoVersionNumber { get; private set; }

        #endregion

        #region Constructor

        static TirUtilitiesProjectSettings()
        {
            HomeFolderPref = new EditorPrefsString($"{_HomeFolderPrefKey}{ProjectName}",
                                                   new GUIContent("Folder Location", _HomeFolderTooltip),
                                                   _HomeFolderDefault);

            AuthorNamePref = new EditorPrefsString($"{_AuthorNamePrefKey}{ProjectName}",
                                                   new GUIContent("Author Name", _AuthorNameTooltip),
                                                   _AuthorNameDefault);

            AutoVersionNumberPref = new EditorPrefsBool($"{_AutoVersionNumberPrefKey}{ProjectName}",
                                                        new GUIContent("Enable Auto Version Number", _AutoVersionNumberTooltip),
                                                        _AutoVersionNumberDefalut);

            HomeFolder = HomeFolderPref;
            AuthorName = AuthorNamePref;
            DoAutoVersionNumber = AutoVersionNumberPref;
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
                    HomeFolderPref.Draw();

                    EditorGUILayout.Separator();
                    EditorGUILayout.LabelField("Script Template Placeholders", EditorStyles.boldLabel);
                    AuthorNamePref.Draw();

                    EditorGUILayout.Separator();
                    EditorGUILayout.LabelField("Build Pipeline", EditorStyles.boldLabel);
                    AutoVersionNumberPref.Draw(200.0f);
                }
            };

        #endregion
    }
}