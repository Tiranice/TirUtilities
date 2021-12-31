using System.Collections.Generic;

namespace TirUtilities.SettingsSystem.Experimental
{
    ///<!--
    /// ISettingsRepository.cs
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
    public interface ISettingsRepository
    {
        IEnumerable<SettingsData> GetSettings { get; }
        SettingsData GetSettingByID(string id);
        void RegisterSetting(SettingsData setting);
        void UpdateSetting(SettingsData settings);
        void Save();
        void Load();
    }
}