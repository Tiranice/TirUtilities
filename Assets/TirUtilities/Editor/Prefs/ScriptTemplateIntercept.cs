using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.Compilation;

using Debug = UnityEngine.Debug;

namespace TirUtilities.Editor.Prefs.Experimental
{
    ///<!--
    /// ScriptTemplateIntercept.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  Sep. 09, 2021
    /// Updated:  Sep. 09, 2021
    /// -->
    /// <summary>
    /// </summary>
    public class ScriptTemplateIntercept : UnityEditor.AssetModificationProcessor
    {
        public static void OnWillCreateAsset(string path)
        {
            path = path.Replace(".meta", "");

            if (!(Path.GetExtension(path) == ".cs")) return;
            if (!File.Exists(Path.GetFullPath(path))) return;

            string fileContent = File.ReadAllText(path);
#if !UNITY_2020_2_OR_NEWER
            var rootNamespace = CompilationPipeline.GetAssemblyNameFromScriptPath(path);
            if (rootNamespace == null || rootNamespace.Contains(".dll")) rootNamespace = EditorSettings.projectGenerationRootNamespace;
            if (string.IsNullOrEmpty(rootNamespace)) rootNamespace = "RootNamespace";
            fileContent = RemoveOrInsertNamespace(fileContent, rootNamespace);
#endif
            fileContent = fileContent.Replace(ScriptTemplateKeys.DateToday, FormatedDate);
            fileContent = fileContent.Replace(ScriptTemplateKeys.ProjectName, PlayerSettings.productName);
            fileContent = fileContent.Replace(ScriptTemplateKeys.CompanyName, PlayerSettings.companyName);
            fileContent = fileContent.Replace(ScriptTemplateKeys.VersionNumber, PlayerSettings.bundleVersion);
            fileContent = fileContent.Replace(ScriptTemplateKeys.AuthorName, TirUtilitesProjectSettings.AuthorName);

            File.WriteAllText(path, fileContent);
            AssetDatabase.Refresh();
        }

        private static string FormatedDate => $"{System.DateTime.Now:MMM dd, yyyy}";
#if !UNITY_2020_2_OR_NEWER
        private static string RemoveOrInsertNamespace(string content, string rootNamespace)
        {
            var rootNamespaceBeginTag = "#ROOTNAMESPACEBEGIN#";
            var rootNamespaceEndTag = "#ROOTNAMESPACEEND#";

            if (!content.Contains(rootNamespaceBeginTag) || !content.Contains(rootNamespaceEndTag))
                return content;

            if (string.IsNullOrEmpty(rootNamespace))
            {
                content = Regex.Replace(content, $"((\\r\\n)|\\n)[ \\t]*{rootNamespaceBeginTag}[ \\t]*", string.Empty);
                content = Regex.Replace(content, $"((\\r\\n)|\\n)[ \\t]*{rootNamespaceEndTag}[ \\t]*", string.Empty);

                return content;
            }

            // Use first found newline character as newline for entire file after replace.
            var newline = content.Contains("\r\n") ? "\r\n" : "\n";
            var contentLines = new List<string>(content.Split(new[] { "\r\n", "\r", "\n" }, System.StringSplitOptions.None));

            int i = 0;

            for (; i < contentLines.Count; ++i)
            {
                if (contentLines[i].Contains(rootNamespaceBeginTag))
                    break;
            }

            var beginTagLine = contentLines[i];

            // Use the whitespace between beginning of line and #ROOTNAMESPACEBEGIN# as identation.
            var indentationString = beginTagLine.Substring(0, beginTagLine.IndexOf("#"));

            contentLines[i] = $"namespace {rootNamespace}";
            contentLines.Insert(i + 1, "{");

            i += 2;

            for (; i < contentLines.Count; ++i)
            {
                var line = contentLines[i];

                if (System.String.IsNullOrEmpty(line) || line.Trim().Length == 0)
                    continue;

                if (line.Contains(rootNamespaceEndTag))
                {
                    contentLines[i] = "}";
                    break;
                }

                contentLines[i] = $"{indentationString}{line}";
            }

            return string.Join(newline, contentLines.ToArray());
        }
#endif
    }


    public readonly ref struct ScriptTemplateKeys
    {
        public static string ProjectName => "#PROJECT#";
        public static string AuthorName => "#AUTHOR#";
        public static string CompanyName => "#COMPANY#";
        public static string VersionNumber => "#VERSIONNUMBER#";
        public static string DateToday => "#DATETODAY#";
    }
}
