using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{

    public Image flagITA, flagENG;

    public Language.LANG lang;

    // Start is called before the first frame update
    void Start()
    {
        GameManager gm = GameManager.instance;
        lang = gm.lang;
        if(lang == Language.LANG.ENG)
        {
            SwapFlag();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMusicLevel(float level)
    {
        MixerAudio.instance.SetMusicLevel(level);
    }

    public void SetEffectsLevel(float level)
    {
        MixerAudio.instance.SetEffectsLevel(level);
    }

    public void SetLanguage()
    {
        if(lang == Language.LANG.ENG)
        {
            lang = Language.LANG.ITA;
        }
        else
        {
            lang = Language.LANG.ENG;
        }

        GameManager.instance.lang = lang;
        SwapFlag();
    }

    private void SwapFlag()
    {
        Sprite tmp = flagENG.sprite;
            flagENG.sprite = flagITA.sprite;
            flagITA.sprite = tmp;
    }

    public void RateApp()
    {
        Application.OpenURL("market://details?id="+Application.identifier);
        Debug.Log("market://details?id="+Application.identifier);
    }
}
