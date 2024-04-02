using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem<T> where T : DataSerializable
{
    public static void SavePlayerData(T playerData, string fileNamePath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, fileNamePath);
        using (FileStream stream = new FileStream(path, FileMode.Create))
            formatter.Serialize(stream, playerData);
        // Debug.Log("Saved data");
    }

    public static T LoadPlayerData(string fileNamePath)
    {
        string path = Path.Combine(Application.persistentDataPath, fileNamePath);
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                T data = formatter.Deserialize(stream) as T;
                // Debug.Log("Load data");
                return data;
            }
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