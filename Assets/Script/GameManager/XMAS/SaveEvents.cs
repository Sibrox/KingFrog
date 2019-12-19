using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSaved
{
    public string lang;
    public int lastSolved;
    public int nWrongs;
    public bool darkKnightStarted;
    public List<Event> events;
    public List<Extra> extras;

    public GameSaved()
    {
        lang = "ITA";
        lastSolved = 0;
        nWrongs = 0;
        darkKnightStarted = false;

        //EVENTO NATALIZIO
        Event xmasEvent = new Event();
        xmasEvent.name = "XMAS 2019";
        xmasEvent.solved = new List<bool>();
        for (int i = 0; i < 4; i++)
        {
            xmasEvent.solved.Add(false);
        }
        xmasEvent.unlocked = false;

        events = new List<Event>();
        events.Add(xmasEvent);

        extras = new List<Extra>();
    }
}

[System.Serializable]
public class Event
{
    public string name;
    public List<bool> solved;
    public bool unlocked;
}

public class Extra
{
    public string ID;
    public string _string;
    public int integer;
    public bool _bool;
}

