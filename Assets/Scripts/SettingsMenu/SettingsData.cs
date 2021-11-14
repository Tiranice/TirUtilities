using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class SettingsData
{
    public SettingsData(string id) => ID = id ?? throw new ArgumentNullException(nameof(id));

    public Action<SettingsData> Callback { get; set; }

    [JsonProperty]
    public string ID { get;}
}
