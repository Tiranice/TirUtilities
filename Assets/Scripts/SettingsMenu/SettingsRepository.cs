using System;
using System.Collections.Generic;
using System.Linq;

public class SettingsRepository : ISettingsRepository
{
    private SettingsContext _context;

    public SettingsRepository(SettingsContext context) => _context = context;

    public IEnumerable<SettingsData> GetSettings => _context.Settings.Values.ToList();

    public SettingsData GetSettingByID(string id) => _context.Settings[id];
    
    public void RegisterSetting(SettingsData setting)
    {
        if (_context.Settings.ContainsKey(setting.ID)) return;
        _context.Settings[setting.ID] = setting;
    }

    public void UpdateSetting(SettingsData setting)
    {
        if (setting is null) throw new ArgumentNullException(nameof(setting));
        _context.Settings[setting.ID] = setting;
        _context.Settings[setting.ID].Callback?.Invoke(setting);
    }


    public void Save() => _context.SaveChanges();
    public void Load() => _context.Load();
}
