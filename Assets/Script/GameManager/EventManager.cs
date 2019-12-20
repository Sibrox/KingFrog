using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using KingFrog;

public class EventManager : MonoBehaviour
{
    public GameObject menuScenari, mainMenu, eventMenu,xmasMenu;

    public int indexXmas;

    public Text textSolvedXmas;

    int nSolved;
    List<bool> solved;

    public GameObject playServiceDebug;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.migrationDone)
        {
            playServiceDebug.SetActive(true);
        }

        Dictionary<string,Event> events = new Dictionary<string, Event>();
        foreach (Event e in GameManager.instance.gameSaveData.events)
        {
            events.Add(e.name, e);
        }

        solved = events["XMAS 2019"].solved;

        for (int i = 0; i < solved.Capacity; i++)
        {
            if (solved[i])
            {
                nSolved++;
            }
        }

        textSolvedXmas.text = nSolved.ToString();

        switch (GameManager.instance.menu_status)
        {
            case MENU_STATUS.EVENTS:
                StartEvents();
                break;
            case MENU_STATUS.XMAS:
                StartXmas();
                break;
            case MENU_STATUS.STORY:
                StartStory();
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LoadSceneByName(string nameScene)
    {
        StartCoroutine(LoadScene(nameScene));
    }

    public void LoadScenebyIndx(int indexScene)
    {
        StartCoroutine(LoadSceneByIndex(indexScene));
    }


    public IEnumerator LoadScene(string nameScene)
    {
        var loading = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        yield return loading;

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(nameScene));
    }


    public IEnumerator LoadSceneByIndex(int indexScene)
    {
        var loading = SceneManager.LoadSceneAsync(indexScene, LoadSceneMode.Additive);
        yield return loading;

        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(indexScene));
        var closing = SceneManager.UnloadSceneAsync(GameManager.instance.indexStatus);
        yield return closing;

        GameManager.instance.indexStatus = indexScene;
    }


    public void StartStory()
    {
        menuScenari.SetActive(true);
        mainMenu.SetActive(false);
        GameManager.instance.menu_status = MENU_STATUS.STORY;
    }


    public void StartXmas()
    {
        GameManager.instance.menu_status = MENU_STATUS.XMAS;
        xmasMenu.SetActive(true);
        eventMenu.SetActive(false);
        mainMenu.SetActive(false);
        //LoadSceneByIndex(indexXmas);
    }

    public void StartEvents()
    {
        eventMenu.SetActive(true);
        mainMenu.SetActive(false);
        xmasMenu.SetActive(false);
        GameManager.instance.menu_status = MENU_STATUS.EVENTS;
    }

    public void StartMain()
    {
        menuScenari.SetActive(false);
        eventMenu.SetActive(false);
        xmasMenu.SetActive(false);
        mainMenu.SetActive(true);
        GameManager.instance.menu_status = MENU_STATUS.MENU;
        MixerAudio.instance.ChangeSong(MixerAudio.SONG_TYPE.MAIN, 0.0f);
    }

}
