using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{

    public static bool SaveData(SaveData gameData)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gameData.sav";
        FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate,
                                       FileAccess.ReadWrite,
                                       FileShare.None);

        binaryFormatter.Serialize(fileStream, gameData);
        fileStream.Close();

        return true;
    }

    public static SaveData LoadData()
    {
        SaveData gameData = null;
        string path = Application.persistentDataPath + "/gameData.sav";
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Open);

            gameData = binaryFormatter.Deserialize(file) as SaveData;
            file.Close();
            return gameData;
        }

        return gameData;
    }
}
