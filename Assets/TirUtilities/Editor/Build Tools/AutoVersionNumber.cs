using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

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