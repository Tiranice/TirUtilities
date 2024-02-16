using System.Collections.Generic;
using UnityEngine;

namespace TirUtilities.SettingsAssets
{
    using TirUtilities.Extensions;
    ///<!--
    /// HierarchyDividerSettings.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Created:  May 16, 2021
    /// Updated:  May 19, 2021
    /// -->
    /// <summary>
    /// Used to supply settings to the
    /// <see cref="Editor.HierarchyDividerMenu">Hierarchy Divider Menu</see>.
    /// </summary>
    /// <remarks>
    /// Is loaded from the path Assets/TirUtilities/Resources/SettingsAssets/HierarchyDividerSettings.asset
    /// </remarks>
    // Uncomment this to make ONE asset if it somehow gets deleted or isn't imported.
    //[CreateAssetMenu(fileName = nameof(HierarchyDividerSettings), menuName = "Settings Asset/Hierarchy Divider Settings")]
    internal class HierarchyDividerSettings : ScriptableObject
    {
        #region Inspector Fields

        [Header("Preview")]
        [DisplayOnly]
        [SerializeField] private List<string> _dividers;

        [Header("Titles")]
        [SerializeField] private List<string> _dividerTitles = new List<string>()
        {
            "Camera & Lighting",
            "Environment",
            "Props",
            "Player",
            "Actors",
            "UI",
        };

        [Header("Style")]
        [SerializeField] private char _separator = '=';
        [Range(1, 50)]
        [SerializeField] private int _length = 14;

        #endregion

        #region Public Properties

        public List<string> DividerTitles { get => _dividerTitles; }
        public List<string> Dividers { get => _dividers; }

        #endregion

        #region Unity Messages

        private void OnValidate()
        {
            if (_dividerTitles.IsNullOrEmpty()) return;

            _dividers.Clear();
            for (int i = 0; i < _dividerTitles.Count; i++)
            {
                SetDividerText(out string divider, i);
                _dividers.Add(divider);
            }
        }

        #endregion

        #region Private Methods

        private void SetDividerText(out string divider, int index)
        {
            divider = string.Empty;
            string separators = GetSeparators(NumSeparators(_dividerTitles[index]));

            divider += $"{separators} {_dividerTitles[index]} {separators}";
        }

        private int NumSeparators(string dividerTitle) => 
            _length - 1 - (dividerTitle.Length / 2);

        private string GetSeparators(int numSeparators)
        {
            string divider = string.Empty;

            for (int i = 0; i < numSeparators; i++)
                divider += _separator;

            return divider;
        }

        #endregion
    }
}