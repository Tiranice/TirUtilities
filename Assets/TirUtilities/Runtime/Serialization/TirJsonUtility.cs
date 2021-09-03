using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace TirUtilities.Serialization
{
    ///<!--
    /// TirJsonUtility.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author : Devon Wilson
    /// Created: Mar. 11, 2021
    /// Updated: Aug. 22, 2021
    ///-->
    /// <summary>
    /// Loads song jsons from a directory.
    /// </summary>
    public class TirJsonUtility
    {
        /// <summary>
        /// Stores the paths to all files within the given directory, whose file extensions match the
        /// supplied regex.
        /// </summary>
        /// <param name="path">The path to the json files.</param>
        /// <param name="fileExtensions">A regex of file extensions, *.txt by default.</param>
        /// <returns>An IEnumerable over the file paths.</returns>
        public static IEnumerable<string> GetFilesInDirectory(string path, string fileExtensions = "*.txt") =>
            Directory.EnumerateFiles(path, fileExtensions);

        /// <summary>
        /// Deserializes a json file into a list of objects of type T.
        /// </summary>
        /// <remarks>
        /// The json must be formated so that the curly braces are on their own lines.
        /// </remarks>
        /// <param name="path">The path to the json file.</param>
        /// <returns> List of objects. </returns>
        public static List<T> ParseJsonToList<T>(string path)
        {
            var parsedObjects = new List<T>();

            string[] lines = File.ReadAllLines(path);
            string parsedJson = string.Empty;

            int depth = 0;

            // Read line by line until the end of an object then store the parsed object.
            foreach (string line in lines)
            {
                parsedJson += line;
                if (IsStartOfNewObject(line)) depth++;
                if (IsEndOfJsonObject(line))
                {
                    depth--;
                    if (depth == 0)
                    {
                        parsedObjects.Add(JsonUtility.FromJson<T>(parsedJson));
                        parsedJson = string.Empty;
                    }
                }
            }

            return parsedObjects;
#if UNITY_2020_2_OR_NEWER
            static bool IsStartOfNewObject(string line) => line.Equals("{");
            static bool IsEndOfJsonObject(string line) => line.Equals("}") || line.Equals("},");
#else
            bool IsStartOfNewObject(string line) => line.Equals("{");
            bool IsEndOfJsonObject(string line) => line.Equals("}") || line.Equals("},");
#endif
        }

        /// <summary>
        /// Deserializes a json file into a list of objects of type T. If the path is invalid, then
        /// the output list is set to null and false is returned.
        /// </summary>
        /// <typeparam name="T">Type of the objects represented by the json.</typeparam>
        /// <param name="data">The list that will hold the deserialized objects.</param>
        /// <param name="path">The path to the json file.</param>
        /// <returns>True the path is valid, false if the path is invalid.</returns>
        public static bool TryParseJsonToList<T>(out List<T> data, string path)
        {
            var parsedObjects = new List<T>();

            string[] lines;
            try { lines = File.ReadAllLines(path); }

            catch (System.Exception) 
            { 
                data = null;
                return false;
            }
            string parsedJson = string.Empty;

            int depth = 0;

            // Read line by line until the end of an object then store the parsed object.
            foreach (string line in lines)
            {
                parsedJson += line;
                if (IsStartOfNewObject(line)) depth++;
                if (IsEndOfJsonObject(line))
                {
                    depth--;
                    if (depth == 0)
                    {
                        parsedObjects.Add(JsonUtility.FromJson<T>(parsedJson));
                        parsedJson = string.Empty;
                    }
                }
            }

            data = parsedObjects;
            return true;

#if UNITY_2020_2_OR_NEWER
            static bool IsStartOfNewObject(string line) => line.Equals("{");
            static bool IsEndOfJsonObject(string line) => line.Equals("}") || line.Equals("},");
#else
            bool IsStartOfNewObject(string line) => line.Equals("{");
            bool IsEndOfJsonObject(string line) => line.Equals("}") || line.Equals("},");
#endif
        }

    }
}