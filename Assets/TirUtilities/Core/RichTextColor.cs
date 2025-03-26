using System;

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
///     You should have received a copy of the GNU General Public License
///     along with this program.  If not, see <https://www.gnu.org/licenses/>.
///-->

namespace TirUtilities
{
    ///<!--
    /// RichTextColor.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Jan 09, 2022
    /// Updated:  Jan 09, 2022
    /// -->
    /// <summary>
    /// Used to represent colors used by Unity's rich text interpreter.
    /// </summary>
    public readonly struct RichTextColor
    {
        #region Fields

        private readonly string _name;
        private readonly string _hex;
        private readonly Color _unityColor;

        #endregion

        #region Constructor

        public RichTextColor(string name, string hex)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _hex = hex ?? throw new ArgumentNullException(nameof(hex));
            ColorUtility.TryParseHtmlString(hex, out _unityColor);
        }

        public RichTextColor(string name, Color unityColor)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _unityColor = unityColor;
            _hex = ColorUtility.ToHtmlStringRGBA(unityColor);
        }

        #endregion

        #region Public Properties

        public string Name => _name;
        public string Hex => _hex;
        public Color UnityColor => _unityColor;

        #endregion

        #region Overrides & Operators

        public override string ToString() => _name;

        public static implicit operator Color(RichTextColor self) => self.UnityColor;
        public static implicit operator RichTextColor(Color color) =>
            new(color.ToString(), color);

        #endregion
    }
}