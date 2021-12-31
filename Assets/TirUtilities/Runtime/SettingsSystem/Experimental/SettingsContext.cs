using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace TirUtilities.SettingsSystem.Experimental
{
    using static TirLogger;

    ///<!--
    /// SettingsContext.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Nov 16, 2021
    /// Updated:  Dec 30, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class SettingsContext
    {
        private readonly string _path = string.Empty;
        private readonly JsonSerializer _jsonSerializer = new JsonSerializer() { TypeNameHandling = TypeNameHandling.All };

        [JsonProperty]
        public Dictionary<string, SettingsData> Settings { get; set; }

        #region Constructor
        
        public SettingsContext(string path)
        {
            _path = path;
            if (!File.Exists(path))
            {
                Settings = new Dictionary<string, SettingsData>();
                return;
            }

            using (StreamReader reader = File.OpenText(path))
            {
                try
                {
                    Load();
                }
                catch (JsonReaderException e)
                {
                    Debug.LogException(e);
                }
            }
        }

        #endregion

        #region Save & Load
        
        public void SaveChanges()
        {
            var jobject = (JObject)JToken.FromObject(this, _jsonSerializer);

            using (StreamWriter file = File.CreateText(_path))
            using (var writer = new JsonTextWriter(file) { Formatting = Formatting.Indented })
            {
                jobject.WriteTo(writer);
            }
        }

        public void Load()
        {
            var jobject = JObject.Parse(File.ReadAllText(_path));

            Settings = jobject.ToObject<SettingsContext>(_jsonSerializer).Settings;
        } 

        #endregion
    }
}