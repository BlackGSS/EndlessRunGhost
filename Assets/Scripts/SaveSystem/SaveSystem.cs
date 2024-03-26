using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem<T> where T : DataSerializable
{
    public static void SavePlayerData(T playerData, string fileNamePath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + fileNamePath;
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        formatter.Serialize(stream, playerData);
        stream.Close();
    }

    public static T LoadPlayerData(string fileNamePath)
    {
        string path = Application.persistentDataPath + fileNamePath;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            T data = formatter.Deserialize(stream) as T;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}

[System.Serializable]
public class DataSerializable
{
    //TODO: Future ID
}