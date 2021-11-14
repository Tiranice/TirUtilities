using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class SettingsEnum<TEnum> : SettingsData where TEnum : System.Enum
{
    #region Constructors
    
    public SettingsEnum(string id) : base(id) { }

    [JsonConstructor]
    public SettingsEnum(string id, TEnum value) : this(id) { Value = value; }

    #endregion

    new public Action<SettingsEnum<TEnum>> Callback { get; set; }

    [JsonProperty]
    public TEnum Value { get; set; }

    public System.Array EnumValues => System.Enum.GetValues(typeof(TEnum));
    public IEnumerable<string> EnumNames => System.Enum.GetNames(typeof(TEnum));
}
