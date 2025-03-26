using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.Compilation;
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

namespace TirUtilities.Editor.Prefs.Experimental
{
    ///<!--
    /// ScriptTemplateIntercept.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Sep 09, 2021
    /// Updated:  Mar 26, 2025
    /// -->
    /// <summary>
    /// Intercepts the creation of .cs files and replaces the template keys with correct values.
    /// </summary>
    public class ScriptTemplateIntercept : UnityEditor.AssetModificationProcessor
    {
        public static void OnWillCreateAsset(string path)
        {
            path = path.Replace(".meta", "");

            if (!(Path.GetExtension(path) == ".cs")) return;
            if (!File.Exists(Path.GetFullPath(path))) return;

            string fileContent = File.ReadAllText(path);

            fileContent = fileContent.Replace(ScriptTemplateKeys.DateToday, FormatedDate);
            fileContent = fileContent.Replace(ScriptTemplateKeys.ProjectName, PlayerSettings.productName);
            fileContent = fileContent.Replace(ScriptTemplateKeys.CompanyName, PlayerSettings.companyName);
            fileContent = fileContent.Replace(ScriptTemplateKeys.VersionNumber, PlayerSettings.bundleVersion);
            fileContent = fileContent.Replace(ScriptTemplateKeys.AuthorName, TirUtilitiesProjectSettings.AuthorName);

            File.WriteAllText(path, fileContent);
            AssetDatabase.Refresh();
        }

        private static string FormatedDate => $"{System.DateTime.Now:MMM dd, yyyy}";
    }

    public readonly ref struct ScriptTemplateKeys
    {
        //TODO:  Add license field

        public static string ProjectName => "#PROJECT#";
        public static string AuthorName => "#AUTHOR#";
        public static string CompanyName => "#COMPANY#";
        public static string VersionNumber => "#VERSIONNUMBER#";
        public static string DateToday => "#DATETODAY#";
    }
}
