using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SelectLanguage : MonoBehaviour
{

    public GameObject gm;
    public GameObject selectLanguage;
    public GameObject background;
    // Start is called before the first frame update
    void Start()
    {
        MixerAudio.instance.ChangeSong(MixerAudio.SONG_TYPE.SOLUTION, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEnglish()
    {
        GameManager.instance.lang = Language.LANG.ENG;
        selectLanguage.SetActive(false);
        background.SetActive(false);
        GameManager.instance.GetComponent<GameManager>().StartGame();
    }

    public void SetItalian()
    {
        GameManager.instance.lang = Language.LANG.ITA;
        selectLanguage.SetActive(false);
        background.SetActive(false);
        GameManager.instance.GetComponent<GameManager>().StartGame();
    }

    public void SelectLanguange(Language.LANG lang)
    {
        GameManager.instance.lang = lang;   
        selectLanguage.SetActive(false);
        background.SetActive(false);
        GameManager.instance.GetComponent<GameManager>().StartGame();
       
    }
}
