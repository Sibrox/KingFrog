using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XMasManager : MonoBehaviour
{

    public changeImage[] buttons;

    public List<bool> solved;
    Dictionary<string, Event> events;

    public GameObject dialogUnlock;

    // Start is called before the first frame update
    void Start()
    {
        events = new Dictionary<string, Event>();
        foreach (Event e in GameManager.instance.gameSaveData.events)
        {
            events.Add(e.name, e);
        }

        solved = events["XMAS 2019"].solved;

        for(int i = 0; i < solved.Capacity; i++)
        {
            if (solved[i])
            {
                buttons[i].SetGold();
            }
        }

        if (events["XMAS 2019"].unlocked) dialogUnlock.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
