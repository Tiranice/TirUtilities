using UnityEngine;

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
    /// Updated:  Jul 15, 2024
    /// -->
    /// <summary>
    ///
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
#if UNITY_2020_2_OR_NEWER
            using var process = new System.Diagnostics.Process();
            int exitCode = process.Run(@"git", arguments, Application.dataPath, out var output, out var errors);

            return exitCode == 0 ? output : throw new GitException(exitCode, errors);
#else
            using (var process = new System.Diagnostics.Process())
            {
                int exitCode = process.Run(@"git", arguments, Application.dataPath, out var output, out var errors);

                return exitCode == 0 ? output
                                     : throw new GitException(exitCode, errors);
            }
#endif
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

        private static string GetBuildVersion(string branch = "")
        {
            // Full describe. v0.0.0-alpha.10.5-109-gc28696e
            string version = Run(@"describe --tags --long --match ""v[0-9]*""" + branch);

            int lastDot = version.LastIndexOf('.');

            // Remove the commit hash. v0.0.0-alpha.10.4-109
            version = version.Remove(version.LastIndexOf('-'));

            // Remove tag number. v0.0.0-alpha.10.109
            version = version.Remove(lastDot + 1, version.LastIndexOf('-') - lastDot);
            return version.Substring(1);
        }

        /// <summary> The currently active branch. </summary>
        public static string Branch => Run(@"rev-parse --abbrev-ref HEAD");

        /// <summary> Returns a listing of all uncommitted or untracked (added) files. </summary>
        public static string Status => Run(@"status --porcelain");

    }
}