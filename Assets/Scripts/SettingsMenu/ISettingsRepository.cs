using System.Collections.Generic;

public interface ISettingsRepository
{
    IEnumerable<SettingsData> GetSettings { get; }
    SettingsData GetSettingByID(string id);
    void RegisterSetting(SettingsData setting);
    void UpdateSetting(SettingsData setting);
    void Save();
    //TODO : Remove when the context is converted to a disposable.
    void Load();
}
