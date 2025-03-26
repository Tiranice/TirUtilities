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

namespace TirUtilities.Editor.GitUtilities
{
    ///<!--
    /// Git.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Apr 11, 2021
    /// Updated:  Mar 26, 2025
    /// -->
    /// <summary>
    /// Run various git commands.  Mostly just getting the version number based on tags.
    /// </summary>
    public static class Git
    {
        /// <summary>
        /// Runs git.exe with the specified arguments and returns the output.
        /// </summary>
        /// <param name="arguments"> Arguments passed to git cmd. </param>
        /// <returns> Git's standard output. </returns>
        /// <exception cref="GitException"> Thrown if exit code is not zero. </exception>
        public static string Run(string arguments)
        {
            using var process = new System.Diagnostics.Process();
            int exitCode = process.Run(@"git", arguments, Application.dataPath, out var output, out var errors);

            return exitCode == 0 ? output : throw new GitException(exitCode, errors);
        }

        /// <summary>
        /// Retrieves the build version from git based on the most recent matching
        /// tag and commit history.
        /// </summary>
        /// <remarks>
        /// This returns the version as:  major.minor.build where 'build' represents
        /// the n^th commit after the tagged commit.
        /// <para>
        /// Note:  The initial 'v' and the commit hash code are removed.
        /// </para>
        /// </remarks>
        public static string BuildVersion => GetBuildVersion();

        /// <summary>
        /// Retrieves the build version from git based on the most recent matching 
        /// tag and commit history from the <c>main</c> branch.
        /// </summary>
        /// <remarks>
        /// This returns the version as:  major.minor.build where 'build' represents
        /// the n^th commit after the tagged commit.
        /// <para>
        /// Note:  The initial 'v' and the commit hash code are removed.
        /// </para>
        /// </remarks>
        public static string BuildVersionMain => GetBuildVersion(@" main");

        /// <summary>
        /// Retrieves the build version from git based on the most recent matching 
        /// tag and commit history from the <c>master</c> branch.
        /// </summary>
        /// <remarks>
        /// This returns the version as:  major.minor.build where 'build' represents
        /// the n^th commit after the tagged commit.
        /// <para>
        /// Note:  The initial 'v' and the commit hash code are removed.
        /// </para>
        /// </remarks>
        public static string BuildVersionMaster => GetBuildVersion(@" master");

        public static string BuildVersionTrunk => GetBuildVersion(@" trunk");

        private static string GetBuildVersion(string branch = "")
        {
            // Full describe:  v0.0.0-alpha.10.4-190-gc22d3af
            string version = Run(@"describe --tags --long --match ""v[0-9]*""" + branch);

            int lastDash = version.LastIndexOf('-');

            // Remove the commit hash:  v0.0.0-alpha.10.4-190
            version = version.Remove(lastDash);

            //v0.0.0-alpha.10→.←4-190
            int lastDot = version.LastIndexOf('.');
            int afterDot = lastDot + 1;
            lastDash = version.LastIndexOf('-');

            // Get the previous patch number:  v0.0.0-alpha.10.→5←-109
            string previousPatchNumber = version.Substring(afterDot, lastDash - lastDot - 1);
            int.TryParse(previousPatchNumber, out int versionNumber);

            // v0.0.0-alpha.10.190
            version = version.Remove(afterDot, lastDash - lastDot);

            versionNumber += int.Parse(version[afterDot..]);

            version = version[..afterDot] + versionNumber.ToString();

            return version;
        }

        /// <summary> The currently active branch. </summary>
        public static string Branch => Run(@"rev-parse --abbrev-ref HEAD");

        /// <summary> Returns a listing of all uncommitted or untracked (added) files. </summary>
        public static string Status => Run(@"status --porcelain");

    }
}