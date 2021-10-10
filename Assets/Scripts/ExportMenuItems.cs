using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

///<!--
/// ExportTest.cs
/// 
/// Project:  TirUtilities
///        
/// Author :  Devon Wilson
/// Company:  BlackPhoenixSoftware
/// Created:  Sep 30, 2021
/// Updated:  Oct 01, 2021
/// -->
/// <summary>
///
/// </summary>
public static class ExportMenuItems
{
    [MenuItem("TirUtilities/Export", priority = 20)]
    public static void Export()
    {
        AssetDatabase.ExportPackage(
            new string[] 
            { 
                "Assets/TirUtilities",
                "Assets/ScriptTemplates",
                "Assets/Plugins/RainbowAssets/RainbowFolders/Editor/Data/RainbowFoldersRuleset.asset"
            },
            ExportSettings.instance.FilePath, ExportPackageOptions.Recurse);
    }
}

[FilePath("TirUtilities/ExportSettings.json", FilePathAttribute.Location.ProjectFolder)]
public class ExportSettings : ScriptableSingleton<ExportSettings>
{
    #region Constants

    public const string VersionHeader = "0.0.0-alpha.";
    public const string FileHeader = "TirUtilities-v0.0.0-alpha."; 
    
    #endregion

    #region Fields

    [SerializeField] private string _folderPath = string.Empty;
    [SerializeField] private readonly Stack<string> _previousVersionNumbers = new Stack<string>();
    [SerializeField] private int _majorVersion = 9;
    [SerializeField] private int _patchVersion = 3;

    #endregion

    #region Properties

    internal string FolderPath 
    { 
        get => _folderPath;
        set
        {
            _folderPath = value;
            Save(true);
        }
    }

    internal string VersionNumber
    {
        get => $"{_majorVersion}.{_patchVersion}";
        private set
        {
            var dot = value.LastIndexOf('.');
            _majorVersion = int.Parse(value.Substring(0, dot));
            _patchVersion = int.Parse(value.Substring(dot + 1));
        }
    }

    internal string FilePath => $"{FolderPath}{FileHeader}{VersionNumber}.unitypackage";

    #endregion

    #region Version Methods

    public void IncrementPatchNumber()
    {
        _previousVersionNumbers.Push(VersionNumber);
        _patchVersion += 1;
        SaveBundleVersion();
    }

    public void DecrementPatchNumber()
    {
        _previousVersionNumbers.Push(VersionNumber);
        _patchVersion -= 1;
        SaveBundleVersion();
    }

    public void IncrementVersionNumber()
    {
        _previousVersionNumbers.Push(VersionNumber);
        _majorVersion += 1;
        SaveBundleVersion();
    }

    public void SetLastVersion()
    {
        if (_previousVersionNumbers == null || _previousVersionNumbers.Count < 1) return;

        VersionNumber = _previousVersionNumbers.Pop();
        SaveBundleVersion();
    } 

    #endregion

    public void Log()
    {
        Debug.Log($"ExportSettings at:  {GetFilePath()}");
        Debug.Log($"ExportSettings state:  {JsonUtility.ToJson(this, true)}");
    }

    private void SaveBundleVersion()
    {
        PlayerSettings.bundleVersion = $"{VersionHeader}{VersionNumber}";

        Save(true);
        Debug.Log($"{PlayerSettings.productName} {VersionHeader}{VersionNumber}");
    }
}

internal static class ExportSettingsMenuItems
{
    private const string _MenuName = "TirUtilities/ExportSettings/";

    [MenuItem(_MenuName + "Log")]
    internal static void LogExportSettingsState() => ExportSettings.instance.Log();

    [MenuItem(_MenuName + "Export To...")]
    internal static void ExportTo()
    {
        ExportSettings.instance.FolderPath = EditorUtility.OpenFolderPanel("Export To...", ExportSettings.instance.FolderPath, string.Empty);
        ExportSettings.instance.FolderPath += '/';
        Debug.Log(ExportSettings.instance.FolderPath);
    }

    [MenuItem(_MenuName + "Increment Patch", priority = 10)]
    internal static void IncrementPatch()
    {
        ExportSettings.instance.IncrementPatchNumber();
        Debug.Log(ExportSettings.instance.VersionNumber);
    }

    [MenuItem(_MenuName + "Decrement Patch", priority = 11)]
    internal static void DecrementPatch()
    {
        ExportSettings.instance.DecrementPatchNumber();
        Debug.Log(ExportSettings.instance.VersionNumber);
    }

    [MenuItem(_MenuName + "Set Last Version", priority = 12)]
    internal static void SetLastVersion()
    {
        ExportSettings.instance.SetLastVersion();
        Debug.Log(ExportSettings.instance.VersionNumber);
    }
}