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
    /// UnityRichTextColors.cs
    /// 
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Jan 09, 2022
    /// Updated:  Jan 09, 2022
    /// -->
    /// <summary>
    /// All supported colors used by Unity's rich text interpreter.
    /// </summary>
    /// <remarks>
    /// See Also:  <seealso cref="RichTextColor"/>
    /// </remarks>
    public readonly ref struct UnityRichTextColors
    {
        public static RichTextColor Aqua => new("aqua", "#00ffffff");
        public static RichTextColor Black => new("black", "#000000ff");
        public static RichTextColor Blue => new ("blue", "#0000ffff");
        public static RichTextColor Brown => new ("brown", "#a52a2aff");
        public static RichTextColor Cyan => Aqua;
        public static RichTextColor DarkBlue => new ("darkblue", "#0000a0ff");
        public static RichTextColor Fuchsia => new ("fuchsia", "#ff00ffff");
        public static RichTextColor Green => new ("green", "#008000ff");
        public static RichTextColor Grey => new ("grey", "#808080ff");
        public static RichTextColor LightBlue => new ("lightblue", "#add8e6ff");
        public static RichTextColor Lime => new ("lime","#00ff00ff");
        public static RichTextColor Magenta => Fuchsia;
        public static RichTextColor Maroon => new ("maroon","#800000ff");
        public static RichTextColor Navy => new ("navy","#000080ff");
        public static RichTextColor Olive => new ("olive","#808000ff");
        public static RichTextColor Orange => new ("orange","#ffa500ff");
        public static RichTextColor Purple => new ("purple","#800080ff");
        public static RichTextColor Red => new ("red","#ff0000ff");
        public static RichTextColor Silver => new ("silver","#c0c0c0ff");
        public static RichTextColor Teal => new ("teal","#008080ff");
        public static RichTextColor White => new("white", "#ffffffff");
        public static RichTextColor Yellow => new ("yellow","#ffff00ff");
    }
}