using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveData 
{
    public static void SavePlayerData(collision col) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.hira";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(col);


        formatter.Serialize(stream, data);
        stream.Close();


    }

    public static PlayerData LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/player.hira";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
  
            return null;
        }
    }
}
