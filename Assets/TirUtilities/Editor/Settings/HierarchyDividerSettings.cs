using System.Collections.Generic;

using UnityEngine;

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

namespace TirUtilities.SettingsAssets
{
    using TirUtilities.Extensions;
    ///<!--
    /// HierarchyDividerSettings.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
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
        [SerializeField]
        private List<string> _dividerTitles = new List<string>()
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