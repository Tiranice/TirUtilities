using UnityEngine;

namespace TirUtilities.Editor.GitUtilities
{
    public static class Git
    {
        #region Public Methods

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

            return exitCode == 0 ? output 
                                 : throw new GitException(exitCode, errors);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Retrieves the build version from git based on the most recent matching tag and commit
        /// history.
        /// </summary>
        /// <remarks>
        /// This returns the version as:  major.minor.build where 'build' represents the nth commit
        /// after the tagged commit.
        /// <para>
        /// Note:  The initial 'v' and the commit hash code are removed.
        /// </para>
        /// </remarks>
        public static string BuildVersion
        {
            get
            {
                string version = Run(@"describe --tags --long --match ""v[0-9]*""");
                version = version.Remove(version.LastIndexOf('.'), version.IndexOf('-') - version.LastIndexOf('.'));
                version = version.Replace('-', '.');
                version = version.Substring(1, version.LastIndexOf('.') - 1);
                return version;
            }
        }

        public static string BuildVersionMain
        {
            get
            {
                string version = Run(@"describe --tags --long --match ""v[0-9]*"" main");
                version = version.Substring(0, version.LastIndexOf('-'));
                var lastDot = version.LastIndexOf('.');
                var lastDash = version.LastIndexOf('-');
                var oldPatchLength = version.Length - lastDash;
                version = version.Remove(lastDot + 1, oldPatchLength);
                return version;
            }
        }

        /// <summary> The currently active branch. </summary>
        public static string Branch => Run(@"rev-parse --abbrev-ref HEAD");

        /// <summary> Returns a listing of all uncommitted or untracked (added) files. </summary>
        public static string Status => Run(@"status --porcelain");

        #endregion
    }
}