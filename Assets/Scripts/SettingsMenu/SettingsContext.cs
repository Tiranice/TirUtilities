using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.IO;
using TirUtilities.SettingsSystem.Experimental;
using UnityEngine;

[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class SettingsContext //TODO : System.IDisposable
{
    private string _path = string.Empty;
    private JsonSerializer _jsonSerializer = new JsonSerializer() { TypeNameHandling = TypeNameHandling.All };

    [JsonProperty]
    public Dictionary<string, SettingsData> Settings { get; set; }

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
        Debug.Log((Settings[nameof(TextureQuality)] as SettingsEnum<TextureQuality>).Value);
    }
}
