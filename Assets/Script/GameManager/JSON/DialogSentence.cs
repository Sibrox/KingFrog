using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogSentence
{
    public string character;
    public string textITA;
    public string textENG;

    public static DialogSentence[] CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<DialogSentence[]>(jsonString);
    }
}
