using System;

namespace TirUtilities.Editor.GitUtilities
{
    /// <summary>
    /// Includes the error output from Git.Run() command as well as the ExitCode it returned.
    /// </summary>
    public class GitException : InvalidOperationException
    {
        #region Public Properties

        /// <summary>
        /// The exit code returned when running the Git command.
        /// </summary>
        public int ExitCode { get; private set; }

        #endregion

        #region Constructor

        public GitException(int exitCode, string errors) : base(errors) => this.ExitCode = exitCode;

        #endregion
    }
}