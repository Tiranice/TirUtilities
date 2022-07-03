namespace TirUtilities
{
    ///<!--
    /// UnityRichTextColors.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
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
        public static RichTextColor Aqua => new RichTextColor("aqua", "#00ffffff");
        public static RichTextColor Black => new RichTextColor("black", "#000000ff");
        public static RichTextColor Blue => new RichTextColor("blue", "#0000ffff");
        public static RichTextColor Brown => new RichTextColor("brown", "#a52a2aff");
        public static RichTextColor Cyan => Aqua;
        public static RichTextColor DarkBlue => new RichTextColor("darkblue", "#0000a0ff");
        public static RichTextColor Fuchsia => new RichTextColor("fuchsia", "#ff00ffff");
        public static RichTextColor Green => new RichTextColor("green", "#008000ff");
        public static RichTextColor Grey => new RichTextColor("grey", "#808080ff");
        public static RichTextColor LightBlue => new RichTextColor("lightblue", "#add8e6ff");
        public static RichTextColor Lime => new RichTextColor("lime","#00ff00ff"); 	
        public static RichTextColor Magenta => Fuchsia; 	
        public static RichTextColor Maroon => new RichTextColor("maroon","#800000ff"); 	
        public static RichTextColor Navy => new RichTextColor("navy","#000080ff"); 	
        public static RichTextColor Olive => new RichTextColor("olive","#808000ff"); 	
        public static RichTextColor Orange => new RichTextColor("orange","#ffa500ff"); 	
        public static RichTextColor Purple => new RichTextColor("purple","#800080ff"); 	
        public static RichTextColor Red => new RichTextColor("red","#ff0000ff"); 	
        public static RichTextColor Silver => new RichTextColor("silver","#c0c0c0ff"); 	
        public static RichTextColor Teal => new RichTextColor("teal","#008080ff"); 	
        public static RichTextColor White => new RichTextColor("white","#ffffffff"); 	
        public static RichTextColor Yellow => new RichTextColor("yellow","#ffff00ff");
    }
}