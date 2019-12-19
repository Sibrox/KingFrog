using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEnigmiManager : MonoBehaviour
{
    //public bool[] interagibile, completo;
    public GameObject[] enigmi;

    public GameObject menuScenes;

    public static int WIDTH = 608;

    public int nScene;

    public bool changeRight,changeLeft;
    public float startSpeed;


    public GameObject[] scenes;

    public Canvas canvas;

    public GameObject dialogMadalina,dialogDarkKnight,dialogBogAndNil;

    public GameObject spada, popUpUscita;

    public TextPopUp firstInterrupt,secondInterrupt;
    public bool played;

    bool bog;

    // Start is called before the first frame update
    void Start()
    {
        nScene= 0;
        changeRight = false;
        played = false;
        bog = false;
        startSpeed = 40;



        //BACK FROM ENIGMA
        if (GameManager.instance.checking && GameManager.instance.rightCheck)
        {
            if (GameManager.instance.lastSolved == GameManager.instance.indexEnigma)
            {

                UpdateGold(GameManager.instance.lastSolved - 1);

                //-> MakeGold
                Solved(GameManager.instance.lastSolved);

                if(GameManager.instance.lastSolved == 11 && !played)
                {
                    StartCoroutine(StartPopUp());
                    played = true;
                }

                if (GameManager.instance.lastSolved == 26)
                {
                    StartCoroutine(StartPopUpInstagram());
                }


            }
            else
            {
                UpdateGold(GameManager.instance.lastSolved);
            }
        }
        //BACK TO ANOTHER SCENE OR COMIING FROM START
        else
        {
            if (!GameManager.instance.gameSaveData.darkKnightStarted && GameManager.instance.lastSolved == 15)
            {
                dialogDarkKnight.SetActive(true);
                GameManager.instance.gameSaveData.darkKnightStarted = true;
                GameManager.instance.StartCoroutine(GameManager.instance.SaveGame());
            }
            else
            {
                spada.SetActive(false);
            }
            UpdateGold(GameManager.instance.lastSolved);
        }

        nScene = Mathf.Min(GameManager.instance.lastSolved / 15, GameManager.instance.indexEnigma / 15);

        if(nScene == 2 && !bog)
        {
            dialogBogAndNil.SetActive(true);
        }

        //CHANGE POSITION OF CAMERA
        Vector2 pos = menuScenes.transform.localPosition;
        pos.x = -WIDTH * nScene;
        menuScenes.transform.localPosition = pos;
        PlaySongByScene();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            popUpUscita.SetActive(true);
        }

        if (changeRight && menuScenes.transform.localPosition.x > WIDTH * (-1) * nScene)
        {
            menuScenes.transform.Translate(new Vector3((-1) * startSpeed * Time.deltaTime, 0, 0));
           
        }
        else if(changeLeft && menuScenes.transform.localPosition.x < WIDTH * (-1) * nScene)
        {
            menuScenes.transform.Translate(new Vector3(startSpeed * Time.deltaTime, 0, 0));
        }
        else if(changeRight)
        {
            Vector2 pos = menuScenes.transform.localPosition;
            pos.x = -WIDTH * nScene;
            menuScenes.transform.localPosition = pos;
            PlaySongByScene();

            changeRight = false;
        }
        else if (changeLeft)
        {
            Vector2 pos = menuScenes.transform.localPosition;
            pos.x = -WIDTH * nScene;
            menuScenes.transform.localPosition = pos;
            changeLeft = false;
            PlaySongByScene();
        }
    }

    public void UpdateGold(int lastSolved)
    {
        //SET GOLD TO ALL BUTTON UNTIL LAST SOLVED RIDDLE
        for(int i = 0; i < lastSolved; i++)
        {
            enigmi[i].SetActive(true);
            enigmi[i].GetComponent<changeImage>().SetGold();
        }

        //ACTIVE NEW RIDDLE
        if(lastSolved < 30)
            enigmi[lastSolved].SetActive(true);
    }

    public void Solved(int nEnigma)
    {
        StartCoroutine(SolvedEnigma(nEnigma));
    }
    IEnumerator SolvedEnigma(int nEnigma)
    {
        yield return new WaitForSeconds(1);
        enigmi[nEnigma - 1].GetComponent<changeImage>().MakeGold();
        if (nEnigma < 30)
            enigmi[nEnigma].SetActive(true);
    }

    
    public void ChangeScenarioLeft()
    {
            nScene--;
            changeLeft = true;
    }

    IEnumerator MadalinaStop()
    {
        //TODO: FABBRO
        dialogMadalina.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        //DIALOG OPEN WITH         
    }

    IEnumerator DarkKnightStop()
    {
        //TODO: FABBRO
        dialogDarkKnight.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        //DIALOG OPEN WITH         
    }

    public void ChangeScenarioRight()
    {
        if (GameManager.instance.lastSolved < 15)
        {
            StartCoroutine(MadalinaStop());
        }
        else if (GameManager.instance.lastSolved < 30 & nScene == 1)
        {
            dialogDarkKnight.GetComponent<DialogBox>().status = DialogBox.STATUS.DIALOG;
            StartCoroutine(DarkKnightStop());
        }
        else
        {
            nScene++;
            changeRight = true;

        }
    }

    public void PlaySongByScene()
    {


        //CHANGE SONG BASED ON SCENE OF MENU
        switch (nScene)
        {
            case 0:
                MixerAudio.instance.ChangeSong(MixerAudio.SONG_TYPE.MAIN, 0.0f);
                break;
            case 1:
                MixerAudio.instance.ChangeSong(MixerAudio.SONG_TYPE.DARK_KNIGHT, 0.0f);
                break;
            case 2:
                MixerAudio.instance.ChangeSong(MixerAudio.SONG_TYPE.BOG_NIL, 0.0f);
                break;
        }

    }


    public IEnumerator StartPopUp()
    {
        yield return new WaitForSeconds(1.5f);
        firstInterrupt.Show();
    }

    public IEnumerator StartPopUpInstagram()
    {
        yield return new WaitForSeconds(1.5f);
        secondInterrupt.Show();
    }

    IEnumerator WaitingForBack()
    {
        bool stopped = false;
        yield return new WaitForSeconds(0);
        while (true)
        {

        }
    }

    public void OpenInstagram()
    {
        Application.OpenURL("https://www.instagram.com/sibroxcompany/");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

