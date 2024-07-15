using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

using UnityEngine;

namespace TirUtilities.Editor
{
    ///<!--
    /// AutoVersionNumber.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  May 29, 2024
    /// Updated:  May 29, 2024
    /// -->
    /// <summary>
    /// Preprocessor that sets the bundle version based on the git tags.
    /// </summary>
    /// <remarks>
    /// See:  <see cref="GitUtilities.Git"/>
    /// </remarks>
    public class AutoVersionNumber : IPreprocessBuildWithReport
    {
        public int callbackOrder => 0;

        public void OnPreprocessBuild(BuildReport report)
        {
            if (!Prefs.TirUtilitiesProjectSettings.DoAutoVersionNumber) return;
            PlayerSettings.bundleVersion = GitUtilities.Git.BuildVersion;
            Debug.Log("TirUtilities.Editor.AutoVersionNumber.OnPreprocessBuild : " + GitUtilities.Git.BuildVersion);
        }
    }
}