using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintsPopUp : MonoBehaviour
{

    public GameObject popUp;
    public GameObject[] hints;

    public  Sprite[] sprites;
    public Text textObjectHint1, textObjectHint2,textObjectHint3;

    [TextArea]
    public string textHint1_ITA, textHint2_ITA, textHint3_ITA;
    [TextArea]
    public string textHint1_ENG, textHint2_ENG, textHint3_ENG;

    public bool[] hintsActived;
    public int lastUnlock;

    public GameObject buttonAds,blockADS;
    public Text textAds;

    [TextArea]
    public string adsTextITA, adsTextITAprev;

    [TextArea]
    public string adsTextENG, adsTextENGprev;

    private string adsText;
    private string adsTextPrev;


    private void OnEnable()
    {
        GameManager gm = GameManager.instance;
        //lastUnlock = gm.nHint;

        hintsActived = new bool[3];
        for (int i = 0; i < 3; i++)
        {
            hintsActived[i] = false;
            if (i <= lastUnlock) hintsActived[i] = true;
        }

        if (lastUnlock >= 0)
            ShowHints(lastUnlock);
        else
            ShowHints(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        lastUnlock = -1;
        GameManager gm = GameManager.instance;
        switch (gm.lang)
        {
            case Language.LANG.ITA:
                textObjectHint1.text = textHint1_ITA;
                textObjectHint2.text = textHint2_ITA;
                textObjectHint3.text = textHint3_ITA;

                adsText = adsTextITA;
                adsTextPrev = adsTextITAprev;
                break;

            case Language.LANG.ENG:
                textObjectHint1.text = textHint1_ENG;
                textObjectHint2.text = textHint2_ENG;
                textObjectHint3.text = textHint3_ENG;

                adsText = adsTextENG;
                adsTextPrev = adsTextENGprev;
                break;
        }

        lastUnlock = gm.nHint;
        hintsActived = new bool[3];      
        for(int i = 0; i< 3; i++)
        {
            hintsActived[i] = false;
            if (i <= lastUnlock) hintsActived[i] = true;
        }

        if (lastUnlock >= 0)
            ShowHints(lastUnlock);
        else
            ShowHints(0);
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void ShowHints(int nHint)
    {

        if (!hintsActived[nHint])
        {
            blockADS.SetActive(true);
            if (lastUnlock == nHint - 1)
            {
                textAds.text = adsText;
                buttonAds.SetActive(true);

            }
            else
            {
                buttonAds.SetActive(false);
                textAds.text = adsTextPrev;
            }

            for (int i = 0; i < 3; i++)
            {
                    hints[i].SetActive(false);
            }
        }
        else
        {
            blockADS.SetActive(false);
            for(int i = 0; i < 3; i++)
            {
                if(nHint == i)
                {
                    hints[i].SetActive(true);
                }
                else
                {
                    hints[i].SetActive(false);
                }
            }
        }

        popUp.GetComponent<Image>().sprite = sprites[nHint];
    }

    public void Vanish()
    {
        popUp.GetComponent<Image>().sprite = sprites[0];
        gameObject.SetActive(false);
    }

    public void UnlockHint()
    {
        hintsActived[lastUnlock+1] = true;
        lastUnlock++;
        GameManager.instance.nHint = lastUnlock;
        ShowHints(lastUnlock);
    }
}
