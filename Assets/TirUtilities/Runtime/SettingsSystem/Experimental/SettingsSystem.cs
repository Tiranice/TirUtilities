using System;
using System.IO;
using UnityEngine;
using UnityEngine.TestTools;

namespace TirUtilities.SettingsSystem.Experimental
{
    ///<!--
    /// SettingsSystem.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Nov 21, 2021
    /// Updated:  Dec 28, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public static class SettingsSystem
    {
        #region Fields

        private static string _FileName;
        private static string _RootPath;

        private static ISettingsRepository _Repository;

        #endregion
    
        #region Constructor
    
        [ExcludeFromCoverage]
        static SettingsSystem()
        {
            _FileName ??= @"Settings.json";
            _RootPath ??= Application.persistentDataPath;

            _Repository = new SettingsRepository(new SettingsContext(PathToJson));
        }

        #endregion

        #region Public Methods

        public static void CreateSettingsEnumFor<T>(T defaultValue, Action<SettingsEnum<T>> onUpdate)
            where T : Enum
        {
            if (_Repository.GetSettingByID(typeof(T).Name) != null)
            {
                _Repository.Load();
                return;
            }

            _Repository.RegisterSetting(
                new SettingsEnum<T>(typeof(T).Name, defaultValue)
                {
                    OnUpdate = onUpdate,
                });
            _Repository.Save();
        }

        public static void ApplyAndSave(SettingsData setting)
        {
            if (setting is null) throw new ArgumentNullException(nameof(setting));
            _Repository.UpdateSetting(setting);
            _Repository.Save();
        }

        public static void ApplyAndSave<T>(T value) where T : Enum
        {
            (_Repository as SettingsRepository).UpdateSettingsEnum(value);
            _Repository.Save();
        }

        public static void RefreshContext() => _Repository.Load();

        public static T GetEnumByType<T>() where T : Enum => GetEnumById<T>(typeof(T).Name);

        public static T GetEnumById<T>(string id) where T : Enum => 
            (_Repository.GetSettingByID(id) as SettingsEnum<T>).Value;

        public static T GetValueById<T>(string id) where T : struct =>
            (T)_Repository.GetSettingByID(id).Value;

        #endregion

        #region File & Path Properties

        public static string FileName
        {
            get => _FileName;

            set
            {
                try { Path.GetFileName(value); }
                catch (Exception e)
                {
                    throw new AggregateException($"{nameof(value)} is malformed file name:  {value}", e);
                }

                _FileName = value;
                _Repository = new SettingsRepository(new SettingsContext(PathToJson));
            }
        }

        public static string RootPath
        {
            get => _RootPath;

            set
            {
                var path = Path.Combine(value, _FileName);
                try { Path.GetDirectoryName(path); }
                catch (Exception e)
                {
                    throw new AggregateException($"{nameof(value)} creates malformed path:  {path}", e);
                }

                _RootPath = value;
                _Repository = new SettingsRepository(new SettingsContext(PathToJson));
            }
        }

        public static string PathToJson => Path.Combine(_RootPath, _FileName);

        #endregion
    }
}