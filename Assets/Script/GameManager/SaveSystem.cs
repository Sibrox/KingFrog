using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    /* DEPRECATED
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
    */

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

    public static void DeleteDeprecatedSaving()
    {
        string path = Application.persistentDataPath + "/gameData.sav";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public static bool SaveDataJson(GameSaved saved)
    {
        File.WriteAllText(Application.persistentDataPath + "/updateGameData.json",JsonUtility.ToJson(saved));

        return true;
    }

    public static GameSaved LoadDataJson()
    {
        GameSaved gameSaved = null;
        string jsonSave;
       

        if(File.Exists(Application.persistentDataPath + "/updateGameData.json"))
        {
            jsonSave = File.ReadAllText(Application.persistentDataPath + "/updateGameData.json");
            gameSaved = JsonUtility.FromJson<GameSaved>(jsonSave);
        }

        return gameSaved;
    }

    public static GameSaved MigrateSaving(SaveData save)
    {
        GameSaved newSaved = new GameSaved();

        switch (GameManager.instance.lang)
        {
            case Language.LANG.ITA:
                newSaved.lang = "ITA";
                break;
            case Language.LANG.ENG:
                newSaved.lang = "ENG";
                break;
            default:
                newSaved.lang = "ITA";
                break;
        }

        newSaved.lastSolved = save.lastSolved;
        newSaved.nWrongs = save.nWrongs;
        newSaved.darkKnightStarted = save.darkKnightStarted;
        //newSaved.events = new List<Event>();

        Debug.Log(JsonUtility.ToJson(newSaved));

        return newSaved;

    }
}
