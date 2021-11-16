using System.Linq;
using TirUtilities.SettingsSystem.Experimental;
using TMPro;
using UnityEngine;

public class TextureQualitySetting : SettingsComponent
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Dropdown _dropdown;

    protected override void Awake()
    {
        SettingsSystem.RegisterSettingsEnum((TextureQuality)QualitySettings.masterTextureLimit, Apply);

        _label.SetText(nameof(TextureQuality).InsertSpaceBeforeUpper());
        _dropdown.ClearOptions();
        _dropdown.AddOptions(System.Enum.GetNames(typeof(TextureQuality)).ToList());
        _dropdown.value = QualitySettings.masterTextureLimit;
    }

    public override void Apply<T>(T data) =>
        QualitySettings.masterTextureLimit = (int)(data as SettingsEnum<TextureQuality>).Value;


    [ContextMenu(nameof(Foo))]
    private void Foo() => SettingsSystem.RefreshContext();
}


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
