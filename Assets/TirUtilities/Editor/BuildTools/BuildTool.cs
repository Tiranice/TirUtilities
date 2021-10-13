using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace TirUtilities.Editor.BuildTools
{
    internal sealed class BuildToolWindow : EditorWindow
    {
        #region Prefs Keys

        private const string _BuildPathKey = "TirUtilities.BuildPath.";
        private const string _GitTargethKey = "TirUtilities.GitTarget.";

        #endregion

        #region Editor Prefs Items

        private static readonly Prefs.EditorPrefsString _BuildPathPref = new Prefs.EditorPrefsString(_BuildPathKey, new GUIContent("Build Path"), string.Empty);
        private static readonly Prefs.EditorPrefsString _GitTargetPref = new Prefs.EditorPrefsString(_GitTargethKey, new GUIContent("Git Target"), BuildTool.GitTarget.CurrentBranch.ToString());

        #endregion

        #region Labels
        
        private static Label _pathLabel;
        private static Label _buildTargetPathName;

        #endregion

        #region Settings Fields

        BuildTool.GitTarget _gitTarget = BuildTool.GitTarget.CurrentBranch;

        #endregion

        #region Open & Close

        [MenuItem("Build/Build Tool Window")]
        public static void OpenWindow() => GetWindow<BuildToolWindow>("Build Tool");

        #endregion

        #region Unity Messages

        private void CreateGUI()
        {
            var buildLocation = new Button(SetBuildLoction) { text = "Select Build Location" };
            rootVisualElement.Add(buildLocation);

            _pathLabel = new Label(_BuildPathPref) { bindingPath = nameof(_BuildPathPref) };
            rootVisualElement.Add(_pathLabel);

            var buildTarget = EditorUserBuildSettings.activeBuildTarget;

            string targetPlatform = SetTargetPlatform(buildTarget);

            _buildTargetPathName = new Label(
                    Path.Combine(Path.GetFullPath(_BuildPathPref),
                                 $"{targetPlatform}-{PlayerSettings.bundleVersion}",
                                 $"{PlayerSettings.productName}.exe")
                    );
            rootVisualElement.Add(_buildTargetPathName);

            _gitTarget = (BuildTool.GitTarget)System.Enum.Parse(typeof(BuildTool.GitTarget), _GitTargetPref);

            var gitTarget = new EnumField("Git Target", _gitTarget) { bindingPath = nameof(_gitTarget) };

            gitTarget.RegisterValueChangedCallback(SetGetTarget);

            rootVisualElement.Add(gitTarget);

            var buildButton = new Button(()
                => BuildTool.BuildWithVersion(_buildTargetPathName.text, _gitTarget, buildTarget)
                )
            {
                text = "Build"
            };
            rootVisualElement.Add(buildButton);
        }

        #endregion

        private void SetGetTarget(ChangeEvent<System.Enum> value)
        {
            _gitTarget = (BuildTool.GitTarget)value.newValue;
            _GitTargetPref.Value = _gitTarget.ToString();
        }


        private static void SetBuildLoction()
        {
            _BuildPathPref.Value = EditorUtility.OpenFolderPanel("Build Location...",
                                                       EditorApplication.applicationPath,
                                                       string.Empty);

            _pathLabel.text = BuildLocationIsValid(_BuildPathPref) ? _BuildPathPref
                                                                   : "Invalid Build Path Selected";
        }


        private static string SetTargetPlatform(BuildTarget buildTarget)
        {
#if UNITY_2020_2_OR_NEWER
            return buildTarget switch
            {
                BuildTarget.StandaloneWindows => "Windows_x64",
                BuildTarget.StandaloneWindows64 => "Windows_x86_64",
                BuildTarget.WebGL => "WebGL",
                BuildTarget.StandaloneLinux64 => "Linux_x86_64",
                _ => "No Valid Target!",
            };
#else
            string targetPlatform;
            switch (buildTarget)
            {
                case BuildTarget.StandaloneWindows:
                    targetPlatform = "Windows_x64";
                    break;
                case BuildTarget.StandaloneWindows64:
                    targetPlatform = "Windows_x86_64";
                    break;
                case BuildTarget.WebGL:
                    targetPlatform = "WebGL";
                    break;
                case BuildTarget.StandaloneLinux64:
                    targetPlatform = "Linux_x86_64";
                    break;
                default:
                case BuildTarget.NoTarget:
                    targetPlatform = "No Valid Target!";
                    break;
            }
#endif
        }

        private static bool BuildLocationIsValid(string path) => path.Length > 0 && Directory.Exists(path);
    }

    public class BuildTool : UnityEditor.Editor
    {
        public enum GitTarget { Main, CurrentBranch, }

        public static void BuildWithVersion()
        {
            PlayerSettings.bundleVersion = GitUtilities.Git.BuildVersion;

            var scenes = new List<string>();
            foreach (var scene in EditorBuildSettings.scenes)
                scenes.Add(scene.path);

            var buildPlayerOptions = new BuildPlayerOptions()
            {
                scenes = scenes.ToArray(),
                locationPathName = $"Builds/Windows_x86_{PlayerSettings.bundleVersion.Replace(".", "_")}/{PlayerSettings.productName}.exe",
                target = BuildTarget.StandaloneWindows64,
                options = BuildOptions.None,
            };

            BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
            BuildSummary summary = report.summary;

            if (summary.result == BuildResult.Succeeded)
                Debug.Log($"Build succeeded:  {summary.totalSize} bytes");
            if (summary.result == BuildResult.Failed)
                Debug.LogError("Build failed");
        }

        public static void BuildWithVersion(string location, GitTarget gitTarget, BuildTarget buildTarget, BuildOptions buildOptions = BuildOptions.None)
        {
            if (gitTarget == GitTarget.CurrentBranch)
                PlayerSettings.bundleVersion = GitUtilities.Git.BuildVersion;
            else if (gitTarget == GitTarget.Main)
                PlayerSettings.bundleVersion = GitUtilities.Git.BuildVersionMain;

            var scenes = new List<string>();
            foreach (var scene in EditorBuildSettings.scenes)
                scenes.Add(scene.path);

            var buildPlayerOptions = new BuildPlayerOptions()
            {
                scenes = scenes.ToArray(),
                locationPathName = location,
                target = buildTarget,
                options = buildOptions,
            };

            BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
            BuildSummary summary = report.summary;

            var log = $"Build targeting {summary.platform} {summary.result} after {summary.totalTime} " +
                      $"with {summary.totalWarnings} warnings, {summary.totalErrors} errors, " +
                      $"and a total size of {summary.totalSize}.";

            if (summary.result == BuildResult.Succeeded)
                Debug.Log(log);
            if (summary.result == BuildResult.Failed)
                Debug.LogError(log);
        }
    }
}