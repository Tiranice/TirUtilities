using UnityEngine;

namespace TirUtilities.Editor.Prefs
{
    ///<!--
    /// EditorPrefsItem.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Sep 03, 2021
    /// Updated:  Jul 15, 2024
    /// -->
    /// <summary>
    /// Base class for settings drawers.
    /// </summary>
    /// <remarks>
    /// Based on the EditorPrefItem class in the source of RainbowFolders.
    /// </remarks>
    public abstract class EditorPrefsItem<T>
    {
        #region Read Only Properties

        /// <summary> Key used by EditorPrefs. </summary>
        protected string Key { get; }

        /// <summary> Content to be drawn. </summary>
        protected GUIContent Label { get; }

        /// <summary> The default value stored with the key when it is created. </summary>
        protected T DefaultValue { get; }

        #endregion

        #region Constructor

        protected EditorPrefsItem(string key, GUIContent label, T defaultValue)
        {
            if (string.IsNullOrEmpty(key))
                throw new System.ArgumentNullException(nameof(key));

            Key = key;
            Label = label;
            DefaultValue = defaultValue;
        }

        #endregion

        /// <summary> Actual value of the item. </summary>
        public abstract T Value { get; set; }

        /// <summary> Draw this IMGUI item. </summary>
        public abstract void Draw();

        /// <summary> Draw this IMGUI item with given width. </summary>
        /// <param name="labelWidth"></param>
        public abstract void Draw(float labelWidth);

        public static implicit operator T(EditorPrefsItem<T> other) => other.Value;
    }
}