using System;

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