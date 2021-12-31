namespace TirUtilities.Extensions
{
    ///<!--
    /// StringExtensions.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Nov 22, 2021
    /// Updated:  Nov 22, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public static class StringExtensions
    {
        public static bool IsAllUpper(this string text) => text == text.ToUpper();
        public static string InsertSpaceBeforeUpper(this string text, bool preserveAcronyms = true)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;

            if (text.Length == 1 || (text.IsAllUpper() && preserveAcronyms)) return text;

            var builder = new System.Text.StringBuilder(text.Length * 2);

            char prev = text[0];
            builder.Append(prev);

            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                {
                    if (IsWordBoundry() || IsLastCharInAcronym(i))
                        builder.Append(' ');
                }

                builder.Append(text[i]);
                prev = text[i];
            }

            return builder.ToString();

            bool IsWordBoundry() => !char.IsWhiteSpace(prev) && char.IsLower(prev);

            bool NotLastChar(int i) => i < text.Length - 1;

            bool IsLastCharInAcronym(int i) => preserveAcronyms
                                               && char.IsUpper(prev)
                                               && NotLastChar(i)
                                               && char.IsLower(text[i + 1]);
        }
    }
}
