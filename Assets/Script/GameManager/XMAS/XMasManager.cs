using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class XMasManager : MonoBehaviour
{

    public static XMasManager instance;
    public changeImage[] buttons;

    public List<bool> solved;
    Dictionary<string, Event> events;

    public GameObject dialogUnlock,dialogEnd;

    public int lastXmas;

    public TextAsset textEnd;

    private void Awake()
    {
        TestSingleton();
    }

    public void TestSingleton()
    {
        if (instance != null) Destroy(gameObject);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        lastXmas = 0;
        instance = this;
        DontDestroyOnLoad(gameObject);
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
                lastXmas++;
            }
        }

        if (lastXmas == 4)
        {
            dialogEnd.SetActive(true);
        }
        else if(!events["XMAS 2019"].unlocked)
        {
            UnlockXmas();
        }


        UpdateGold();
        Debug.Log(JsonUtility.ToJson(GameManager.instance.gameSaveData).ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }  

    private void UpdateGold()
    {
        for(int j = 0; j < lastXmas; j++)
        {
            buttons[j].SetGold();
            buttons[j].GetComponent<Button>().interactable = true;
        }
        if(lastXmas < 4)
        {
            buttons[lastXmas].GetComponent<Button>().interactable = true;
        }
    }

    private void UnlockXmas()
    {
        //ACHIVEMENT GPS
        foreach (Event e in GameManager.instance.gameSaveData.events)
        {
            if (e.name.CompareTo("XMAS 2019") == 0)
            {
                e.unlocked = true;
            }
        }
        dialogUnlock.SetActive(true);
    }

}
