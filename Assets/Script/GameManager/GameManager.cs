using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using KingFrog;
public class GameManager : MonoBehaviour
{
    public Language.LANG lang;

    [Space(10)]
    public int indexStatus,indexEnigma,lastSolved;
    public int indexMenu,indexStart,indexTutorial,indexLittleFrog,indexBigFrog,indexEndDarkKnight;
    public int xMasScene;

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

    public MENU_STATUS menu_status;

    //NEW INFO
    [Header("SAVE DATA")]
    public GameSaved gameSaveData;

    public TextRiddle[] xMasRiddle;

    public bool migrationDone;

    private void Awake()
    {
        TestSingleton();
    }
    // Start is called before the first frame update
    void Start()
    {
        migrationDone = false;

        darkKnightStarted = true;
        indexStatus = indexStart;
        Input.multiTouchEnabled = false;
        checking = false;
        lastSolved = 0;
        nWrongs = 0;
        nHint = -1;
        enteredEnigma = new bool[30];

        GooglePlayServices.Authentication();

        for(int  i = 0; i<30; i++)
        {
            enteredEnigma[i] = false;
        }
        TextAsset jsonTextFile = Resources.Load<TextAsset>("Text/Riddles");
        riddles = JsonHelper.getJsonArray<TextRiddle>(jsonTextFile.ToString());

        TextAsset jsonTextFileXmas = Resources.Load<TextAsset>("Text/RiddlesXMas");
        xMasRiddle = JsonHelper.getJsonArray<TextRiddle>(jsonTextFileXmas.ToString());

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
            lastSolved = 15;
            gameSaveData.lastSolved = lastSolved;
        }
        else if (checking && rightCheck && indexEnigma == 30)
        {
            StartCoroutine(CoroutineLoad(indexEndDarkKnight));
            checking = false;
            rightCheck = false;
            lastSolved = 30;
            gameSaveData.lastSolved = lastSolved;
        }
        else
        {
            StartCoroutine(CoroutineLoad(indexMenu));
        }
        StartCoroutine(SaveGame());
        GooglePlayServices.SaveToCloud();
    }

    public void LoadSceneByIndex(int indexScene)
    {
        if (menu_status == MENU_STATUS.XMAS)
        {
            StartCoroutine(CoroutineLoadXMas(indexScene));
        }
        else
        {
            StartCoroutine(CoroutineLoad(indexScene));
        }
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
                    gameSaveData.lastSolved = lastSolved;
                }
                rightCheck = true;
            }
            else
            {
                rightCheck = false;
                nWrongs++;
                gameSaveData.nWrongs = nWrongs;
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
            GooglePlayServices.SaveToCloud();
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
            GooglePlayServices.SaveToCloud();

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
            saving = true;

            yield return SaveSystem.SaveDataJson(gameSaveData);

            saving = false;
        }
    }

    public void LoadGame()
    {
        gameData = SaveSystem.LoadData();
        if (gameData != null) // NEED MIGRATION
        {
            lastSolved = gameData.lastSolved;
            nWrongs = gameData.nWrongs;
            indexEnigma = lastSolved;
            darkKnightStarted = gameData.darkKnightStarted;
            gameSaveData = SaveSystem.MigrateSaving(gameData);
            StartCoroutine(SaveGame());

            //TODO: ELIMINARE VECCHIO SALVATAGGIO
            SaveSystem.DeleteDeprecatedSaving();

            migrationDone = true;
        }
        else
        {
            gameSaveData = SaveSystem.LoadDataJson();
            if (gameSaveData == null)
            {
                GooglePlayServices.LoadFromCloud(); // In questa funzione il salvataggio viene inizializzato se la load non va a buon fine
            }
            else
            {
                SetSave();
            }

        }
    }

    public void OpenInstagram()
    {
        Application.OpenURL("https://www.instagram.com/sibroxcompany/");
    }

    IEnumerator CoroutineLoadXMas(int indexScene)
    {
        //Aswer to Riddle
        if (indexScene == GameManager.instance.indexRight || indexScene == GameManager.instance.indexWrong)
        {
            if (indexScene == GameManager.instance.indexRight)
            {

                GameManager.instance.rightCheck = true;
            }
            else
            {
                GameManager.instance.rightCheck = false;
            }
            GameManager.instance.checking = true;
            MixerAudio.instance.StopMusic();
        }

        var loading = SceneManager.LoadSceneAsync(indexScene, LoadSceneMode.Additive);
        yield return loading;

        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(indexScene));
        var closing = SceneManager.UnloadSceneAsync(GameManager.instance.indexStatus);
        yield return closing;


        // It's a Riddle
        if (indexScene >= 38 && indexScene <= 41)
        {

            if (indexScene != GameManager.instance.indexEnigma) GameManager.instance.nHint = -1;

            if (GameManager.instance.checking)
            {
                if (GameManager.instance.rightCheck)
                {
                    MixerAudio.instance.ChangeSong(MixerAudio.SONG_TYPE.SOLUTION, 1);
                    gameSaveData.events[indexScene - 38].solved[0] = true;
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
            GameManager.instance.indexEnigma = indexScene;
        }
        
        GameManager.instance.indexStatus = indexScene;
    }


    public void SetSave()
    {

        lastSolved = gameSaveData.lastSolved;
        nWrongs = gameSaveData.nWrongs;
        indexEnigma = lastSolved;
        darkKnightStarted = gameSaveData.darkKnightStarted;
    }

}
