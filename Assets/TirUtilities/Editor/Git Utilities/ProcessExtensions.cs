using System.Diagnostics;
using System.Text;

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
    /// ProcessExtensions.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Apr 11, 2021
    /// Updated:  Oct 13, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public static class ProcessExtensions
    {
        /// <summary>
        /// Runs the specified process and waits for it to exit.
        /// </summary>
        /// <remarks>
        /// This should be disposed after used.  It won't work properly if kept alive.
        /// </remarks>
        /// <param name="process"> This process. </param>
        /// <param name="application"> The name of the application to be run. </param>
        /// <param name="arguments"> Arguments passed to the application. </param>
        /// <param name="workingDirectory"></param>
        /// <param name="output"> Output of the application. </param>
        /// <param name="errors"> The errors returned. </param>
        /// <returns> The application's exit code. </returns>
        public static int Run(this Process process, string application, string arguments,
                              string workingDirectory, out string output, out string errors)
        {
            process.StartInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                FileName = application,
                Arguments = arguments,
                WorkingDirectory = workingDirectory
            };

            var outputBuilder = new StringBuilder();
            var errorsBuilder = new StringBuilder();

            process.OutputDataReceived += (_, args) => outputBuilder.AppendLine(args.Data);
            process.ErrorDataReceived += (_, args) => errorsBuilder.AppendLine(args.Data);

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();

            output = outputBuilder.ToString().TrimEnd();
            errors = errorsBuilder.ToString().TrimEnd();
            return process.ExitCode;
        }
    }
}