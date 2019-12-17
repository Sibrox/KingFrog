using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public Language.LANG lang;

    [Space(10)]
    public int indexStatus,indexEnigma,lastSolved;
    public int indexMenu,indexStart,indexTutorial,indexLittleFrog,indexBigFrog,indexEndDarkKnight;

    public int indexRight, indexWrong;
    public bool rightCheck, checking;
    public bool firstRun, isEnglish, tutorialEnd;

    [Space(10)]
    public bool[] enteredEnigma;

    public SaveData gameData;

    public StartAnimation startVideo;

    public static GameManager instance;

    public int nHint;

    public int nWrongs;

    public TextRiddle[] riddles;

    public bool saving;

    public bool darkKnightStarted;

    private void Awake()
    {
        TestSingleton();
    }
    // Start is called before the first frame update
    void Start()
    {
        darkKnightStarted = true;
        indexStatus = indexStart;
        Input.multiTouchEnabled = false;
        checking = false;
        lastSolved = 0;
        nWrongs = 0;
        nHint = -1;
        enteredEnigma = new bool[30];

        //GooglePlayServices.Authentication();

        for(int  i = 0; i<30; i++)
        {
            enteredEnigma[i] = false;
        }
        TextAsset jsonTextFile = Resources.Load<TextAsset>("Text/Riddles");
        riddles = JsonHelper.getJsonArray<TextRiddle>(jsonTextFile.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenTutorial()
    {
        MixerAudio.instance.ChangeSong(MixerAudio.SONG_TYPE.SOLUTION, 1);
        LoadSceneByIndex(indexTutorial);
    }

    public void OpenMenu()
    {

        if (checking && rightCheck && indexEnigma == 15)
        {
            StartCoroutine(CoroutineLoad(indexBigFrog));
            checking = false;
            rightCheck = false;
            if (lastSolved <= 15)
            {
                lastSolved = 15;
                gameData.lastSolved = lastSolved;
            }
        }
        else if (checking && rightCheck && indexEnigma == 30)
        {
            StartCoroutine(CoroutineLoad(indexEndDarkKnight));
            checking = false;
            rightCheck = false;
            if (lastSolved <= 30)
            {
                lastSolved = 30;
                gameData.lastSolved = lastSolved;
            }
        }
        else
        {
            StartCoroutine(CoroutineLoad(indexMenu));
        }
        StartCoroutine(SaveGame());
    }

    public void LoadSceneByIndex(int indexScene)
    {
        StartCoroutine(CoroutineLoad(indexScene));
    }

    IEnumerator CoroutineLoad(int indexScene)
    {

        //Aswer to Riddle
        if (indexScene == indexRight || indexScene == indexWrong)
        {
            if (indexScene == indexRight)
            {
                if (indexEnigma > lastSolved)
                {
                    lastSolved = indexEnigma;
                    gameData.lastSolved = lastSolved;
                }
                rightCheck = true;
            }
            else
            {
                rightCheck = false;
                nWrongs++;
                gameData.nWrongs = nWrongs;
            }
            checking = true;
            MixerAudio.instance.StopMusic();
        }

        //Jump to Menu
        if(indexScene == indexLittleFrog && !firstRun)
        {
            indexScene = indexMenu;
        }

        var loading = SceneManager.LoadSceneAsync(indexScene, LoadSceneMode.Additive);
        yield return loading;
            
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(indexScene));
        var closing = SceneManager.UnloadSceneAsync(indexStatus);
        yield return closing;


        // It's a Riddle
        if (indexScene > 0 && indexScene <= 30)
        {
            StartCoroutine(SaveGame());
            if (indexScene != indexEnigma) nHint = -1;
            if (!enteredEnigma[indexScene - 1])
            {
                MixerAudio.instance.ChangeSong(MixerAudio.SONG_TYPE.ENIGMA, 1);
                enteredEnigma[indexScene - 1] = true;
            }
            else if (checking)
            {
                if (rightCheck)
                {
                    MixerAudio.instance.ChangeSong(MixerAudio.SONG_TYPE.SOLUTION, 1);
                }
                else
                {

                    MixerAudio.instance.ChangeSong(MixerAudio.SONG_TYPE.ENIGMA, 1);
                }
            }
            else
            {
                MixerAudio.instance.ChangeSong(MixerAudio.SONG_TYPE.ENIGMA, 1);
            }
            indexEnigma = indexScene;
        }
        // It's Menu
        else if (indexScene == indexMenu)
        {
            StartCoroutine(SaveGame());

            checking = false;
        }
        indexStatus = indexScene;   
    }

    public void SetEnglish()
    {
        lang = Language.LANG.ENG;
        isEnglish = true;

    }

    public void SetItalian()
    {
        lang = Language.LANG.ITA;
        isEnglish = false;
    }

    public void SetLanguage(Language.LANG lang)
    {
        this.lang = lang;
    }

    public void StartGame()
    {
        MixerAudio.instance.ChangeSong(MixerAudio.SONG_TYPE.MAIN, 0);
        startVideo.enabled = true;
    }

     public void TestSingleton()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator SaveGame()
    {
        if (!saving)
        {
            //Debug.Log("Saving...");
            saving = true;
            yield return SaveSystem.SaveData(gameData);
            saving = false;
            //Debug.Log("Saved!");
        }
    }

    public void LoadGame()
    {
        gameData = SaveSystem.LoadData();
        if (gameData == null)
        {
            gameData = new SaveData();
            gameData.lastSolved = 0;
            gameData.nWrongs = 0;
            gameData.darkKnightStarted = false;
            firstRun = true;
        }
        else
        {
            lastSolved = gameData.lastSolved;
            nWrongs = gameData.nWrongs;
            indexEnigma = lastSolved;
            darkKnightStarted = gameData.darkKnightStarted;
        }

    }

    public void OpenInstagram()
    {
        Application.OpenURL("https://www.instagram.com/sibroxcompany/");
    }

}
