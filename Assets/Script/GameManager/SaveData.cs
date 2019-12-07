using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{

    public int lastSolved;
    public int nWrongs;
    public bool darkKnightStarted;

    public SaveData()
    {
        lastSolved = 0;
        nWrongs = 0;
        darkKnightStarted = false;
    }

}
