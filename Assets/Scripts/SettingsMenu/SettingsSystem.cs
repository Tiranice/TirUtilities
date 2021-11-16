using System;
using System.IO;
using UnityEngine;

public static class SettingsSystem
{
    //TODO : Allow user to set the path for save data.
    //TODO : Default path should be to the persistent data path.
    private static readonly string _PathToJson = Path.Combine(Application.dataPath, @"Settings.json");
    private static readonly ISettingsRepository _Repository = new SettingsRepository(new SettingsContext(_PathToJson));

    public static void RegisterSettingsEnum<T>(T defaultValue, System.Action<SettingsEnum<T>> callback)
        where T : System.Enum
    {
        _Repository.RegisterSetting(
            new SettingsEnum<T>(typeof(T).Name)
            {
                Value = defaultValue,
                Callback = callback
            });
        _Repository.Save();
    }

    public static void ApplyAndSave<T>(SettingsEnum<T> setting) where T : Enum
    {
        if (setting is null) throw new ArgumentNullException(nameof(setting));
        _Repository.UpdateSetting(setting);
    }

    public static void RefreshContext() => _Repository.Load();
}
