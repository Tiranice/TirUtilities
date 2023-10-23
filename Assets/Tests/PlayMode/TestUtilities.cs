using NUnit.Framework;

using UnityEditor;

using UnityEngine;

namespace TirUtilities.Runtime.Tests
{
    public sealed class TestUtilities
    {
        /// <summary>
        /// Returns the first <see cref="ScriptableObject"/> of type <c>T</c> found with the given 
        /// name if any exists; returns <c>null</c> otherwise.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="scriptableObjectName"></param>
        /// <returns><see cref="ScriptableObject"/> of type <c>T</c></returns>
        public static T LoadScriptableObject<T>(string scriptableObjectName) where T : ScriptableObject
        {
            string[] guids = AssetDatabase.FindAssets($"t: {typeof(T)} {scriptableObjectName}");

            if (guids.Length == 0)
            {
                Assert.Fail($"No {typeof(T)} found named {scriptableObjectName}");
                return null;
            }

            if (guids.Length > 1)
                Debug.LogWarning($"Found {guids.Length} {typeof(T)} named {scriptableObjectName}, taking the first one.");

            return AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guids[0]), typeof(T)) as T;
        }
    }
}
