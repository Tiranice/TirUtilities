using System;

namespace TirUtilities.Editor.GitUtilities
{
    ///<!--
    /// GitException.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Apr 11, 2021
    /// Updated:  Oct 13, 2021
    /// -->
    /// <summary>
    /// Includes the error output from Git.Run() command as well as the ExitCode it returned.
    /// </summary>
    public class GitException : InvalidOperationException
    {
        /// <summary> The exit code returned when running the Git command. </summary>
        public int ExitCode { get; private set; }

        public GitException(int exitCode, string errors) : base(errors) => this.ExitCode = exitCode;
    }
}