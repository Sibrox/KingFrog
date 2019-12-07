using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TextRiddle
{
    public int number;
    public string name;

    public string text_ita;
    public string text_eng;

    public string hint1_ita;
    public string hint2_ita;
    public string hint3_ita;

    public string hint1_eng;
    public string hint2_eng;
    public string hint3_eng;

    public string solution_ita;
    public string solution_eng;

    public static TextRiddle[] CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<TextRiddle[]>(jsonString);
    }
}
