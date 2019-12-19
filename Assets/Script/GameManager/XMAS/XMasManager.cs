using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class XMasManager : MonoBehaviour
{

    public static XMasManager instance;
    public changeImage[] buttons;

    public List<bool> solved;
    Dictionary<string, Event> events;

    public GameObject dialogUnlock;

    public TextRiddle[] xMasRiddle;

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
                buttons[i].SetGold();
            }
        }

        if (events["XMAS 2019"].unlocked) dialogUnlock.SetActive(false);

        TextAsset jsonTextFileXmas = Resources.Load<TextAsset>("Text/RiddlesXMas");
        xMasRiddle = JsonHelper.getJsonArray<TextRiddle>(jsonTextFileXmas.ToString());

        UpdateGold();
    }

    // Update is called once per frame
    void Update()
    {
        
    }  

    private void UpdateGold()
    {
        int i = 0;
        for (i = 0; i < 4 && solved[i]; i++) ;

        for(int j = 0; j < i; j++)
        {
            buttons[i].SetGold();
        }

        if (i < 4) buttons[i].MakeGold();
    }
}
