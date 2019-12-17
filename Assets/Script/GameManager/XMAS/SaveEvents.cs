using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Event
{
    public string name { get; set; }
    public List<bool> solved { get; set; }
    public bool unlocked { get; set; }
}

public class GameSaved
{
    public string lang { get; set; }
    public int lastSolved { get; set; }
    public int nWrongs { get; set; }
    public bool darkKnightStarted { get; set; }
    public List<Event> events { get; set; }

    public GameSaved()
    {
        lang = "ITA";
        lastSolved = 0;
        nWrongs = 0;
        darkKnightStarted = false;

    }

    public static GameSaved MigrateSaving(SaveData save)
    {
        GameSaved newSaved;


        return newSaved;

    }
}


