using System;
using System.Collections.Generic;

namespace TirUtilities.SettingsSystem.Experimental
{
    ///<!--
    /// SettingsRepository.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Nov 21, 2021
    /// Updated:  Nov 21, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public class SettingsRepository : ISettingsRepository
    {
        #region Fields

        private SettingsContext _context;

        #endregion

        #region Constructor

        public SettingsRepository(SettingsContext context) =>
            _context = context ?? throw new ArgumentNullException(nameof(context));

        #endregion

        #region Public Methods

        public SettingsData GetSettingByID(string id)
        {
            _context.Settings.TryGetValue(id, out var settingsData);
            return settingsData;
        }

        public void RegisterSetting(SettingsData settings) => 
            _context.Settings[settings.ID] = settings;

        public void UpdateSetting(SettingsData setting)
        {
            _context.Settings[setting.ID] = setting ?? throw new ArgumentNullException(nameof(setting));
            _context.Settings[setting.ID].OnUpdate?.Invoke(setting);
        }

        public void UpdateSettingsEnum<T>(T value) where T : Enum
        {
            var key = typeof(T).Name;
            (_context.Settings[key] as SettingsEnum<T>).Value = value;
            _context.Settings[key].OnUpdate?.Invoke(_context.Settings[key]);
        }

        public void Save() => _context.SaveChanges();
        public void Load() => _context.Load();

        #endregion

        #region Public Properties

        public IEnumerable<SettingsData> GetSettings => _context.Settings.Values;

        #endregion
    }
}