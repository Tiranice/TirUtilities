using System;
using UnityEngine;

namespace TirUtilities
{
    ///<!--
    /// RichTextColor.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
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
            new RichTextColor(color.ToString(), color);

        #endregion
    }
}