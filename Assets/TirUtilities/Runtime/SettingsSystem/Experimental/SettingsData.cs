using Newtonsoft.Json;
using System;

namespace TirUtilities.SettingsSystem.Experimental
{
    ///<!--
    /// SettingsData.cs
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
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class SettingsData
    {
        public SettingsData(string id) => ID = id ?? throw new ArgumentException(nameof(id));

        [JsonProperty]
        public virtual string ID { get; }

        public ValueType Value { get; set; }

        public virtual Action<SettingsData> OnUpdate { get; set; }
    }
}