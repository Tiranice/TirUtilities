using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TirUtilities.SettingsSystem.Experimental
{
    ///<!--
    /// SettingsEnum.cs
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
    public class SettingsEnum<TEnum> : SettingsData where TEnum : Enum
    {
        #region Constructors
    
        public SettingsEnum(string id) : base(id) { }

        [JsonConstructor]
        public SettingsEnum(string id, TEnum value) : this(id) { Value = value; }

        #endregion
    
        #region Public Properties
    
        new public Action<SettingsEnum<TEnum>> OnUpdate { get; set; }

        [JsonProperty] new public TEnum Value { get; set; }

        public Array EnumValues => Enum.GetValues(typeof(TEnum));
        public IEnumerable<string> EnumNames => Enum.GetNames(typeof(TEnum));

        #endregion

        public static implicit operator TEnum(SettingsEnum<TEnum> settings) => settings.Value;
    }
}