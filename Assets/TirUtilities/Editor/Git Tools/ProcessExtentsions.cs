using System.Diagnostics;
using System.Text;

namespace TirUtilities.Editor.GitUtilities
{
    public static class ProcessExtentsions
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