using UnityEngine;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

public static class XmlUtility<T>
{
    public static void Save(T obj, string path)
    {
        using (StreamWriter file = File.CreateText(path))
        {
            var serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(file, obj);
        }
    }

    public static T Load(string path, T defaultValue)
    {
        T result = defaultValue;

        using (StreamReader file = File.OpenText(path))
        {
            var reader = XmlReader.Create(file);
            var serializer = new XmlSerializer(typeof(T));
            if (serializer.CanDeserialize(reader))
            {
                try
                {
                    result = (T)serializer.Deserialize(reader);
                }
                catch
                {
                    result = defaultValue;
                    Debug.LogError($"Data at {path} is invalid:  {typeof(T)}");
                }
            }
        }
        return result;
    }
}
