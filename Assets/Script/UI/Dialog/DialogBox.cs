using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    public bool debug;
    public STATUS status;
    public Language.LANG lang;

    [Space(10)]
 
    public float typingSpeed;
    public GameObject continueButton;
    public Text textDisplay; 
    public string[] nowSentences;
    [TextArea]
    public string[] sentencesGood1ITA;
    [TextArea]
    public string [] sentencesGood2ITA;
    [TextArea]
    public string [] sentencesGood3ITA;
    [TextArea]
    public string [] sentencesGood1ENG;
    [TextArea]
    public string [] sentencesGood2ENG;
    [TextArea]
    public string [] sentencesGood3ENG;

    AnimationDialog animationDialog;
    TutorialDialog tutorialDialog;
    MultipleDialog multipleDialog;
    HudEnigma hud;

    int index;
    bool isSkippable = false;
    bool isWriting = false;

    //Status of Dialog
    public enum STATUS
    {
        START,
        ENIGMA,
        WRONG,
        CORRECT,
        TUTORIAL,
        DIALOG,
        END,
        MULTIPLE
    }



    [Space(10)]

    [TextArea]
    public string textITA;
    string[] sentencesITA;

    [Space(2)]

    [TextArea]
    public string textCorrectITA;
    string[] sentencesCorrectITA;

    [Space(2)]

    [TextArea]
    public string textWrongITA;
    string[] sentencesWrongITA;

    [Space(10)]

    [TextArea]
    public string textENG;
    string[] sentencesENG;

    [Space(2)]

    [TextArea]
    public string textCorrectENG;
    string[] sentencesCorrectENG;

    [Space(2)]
    [TextArea]
    public string textWrongENG;
    string[] sentencesWrongENG;

    TextRiddle riddle;

    private void OnEnable()
    {
        InitDialog();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Coroutine end diplaying text
        if(nowSentences != null && nowSentences.Length > 0
            && index < nowSentences.Length
            && textDisplay.text != null
            && textDisplay.text.CompareTo(nowSentences[index]) == 0
          )
        {
            continueButton.SetActive(true);
            animationDialog.StopTalking();
            StopCoroutine(Type());
        }
    }

    

    private void InitDialog()
    {
        index = 0;

        //Get HUD
        if (status == STATUS.ENIGMA)
        {
            hud = gameObject.transform.parent.gameObject.GetComponent<HudEnigma>();
            riddle = GameManager.instance.riddles[hud.nEnigma - 1];

            //Set Text
            textITA = riddle.text_ita;
            textENG = riddle.text_eng;
            textCorrectITA = GoodSentencesITA();
            textCorrectENG = GoodSentencesENG();
        }

        UnpackTexts();
        //Set Languange
        lang = GameManager.instance.lang;
        switch (lang)
        {
            case Language.LANG.ITA:
                nowSentences = sentencesITA;

                break;
            case Language.LANG.ENG:
                nowSentences = sentencesENG;

                break;
        }

        //Get Animation
        animationDialog = gameObject.GetComponent<AnimationDialog>();
        animationDialog.talking = true;

        //Get Status
        GameManager gm = GameManager.instance;
        if (gm.checking)
        {
            if (gm.rightCheck && status != STATUS.MULTIPLE)
            {
                if (GameManager.instance.indexEnigma == 25 && status == STATUS.ENIGMA)
                {
                    //animationDialog.ChangeCharacter(KingFrog.CHARACTER.BOG);
                    status = STATUS.MULTIPLE;
                    StartDialog();
                }
                else
                {
                    CorrectAnswer();
                }
            }
            else if(status != STATUS.MULTIPLE)
            {
                WrongAnswer();
            }
        }
        //Start Coroutine
        textDisplay.text = "";
        if (status == STATUS.TUTORIAL)
        {
            tutorialDialog = gameObject.GetComponent<TutorialDialog>();
        }
        else if(status == STATUS.MULTIPLE)
        {
            multipleDialog = gameObject.GetComponent<MultipleDialog>();
        }
        else
        {
            StartCoroutine(Type());
        }
    }


    public void SetIndex(int index)
    {
        this.index = index;
    }

    public string GoodSentencesITA(){

        string finalGoodSentencesITA = sentencesGood1ITA[Random.Range(0,4)] + sentencesGood2ITA[Random.Range(0,4)] + sentencesGood3ITA[Random.Range(0,4)];
        return finalGoodSentencesITA;
    }

    public string GoodSentencesENG(){

        string finalWrongSentencesENG = sentencesGood1ENG[Random.Range(0,4)] + sentencesGood2ENG[Random.Range(0,4)] + sentencesGood3ENG[Random.Range(0,4)];
        return finalWrongSentencesENG;
    }

    public void CorrectAnswer()
    {
        status = STATUS.CORRECT;
        if (GameManager.instance.lang == Language.LANG.ENG)
        {
            nowSentences = sentencesCorrectENG;
        }
        else
        {
            nowSentences = sentencesCorrectITA;
        }

        StartDialog();
    }

    public void WrongAnswer()
    {
        status = STATUS.WRONG;
        if (GameManager.instance.lang == Language.LANG.ENG)
        {
            nowSentences = sentencesWrongENG;
            nowSentences[nowSentences.Length - 1] += ""+ GameManager.instance.nWrongs;
        }
        else
        {
            nowSentences = sentencesWrongITA;
            nowSentences[nowSentences.Length - 1] += "Siamo gia' a " + GameManager.instance.nWrongs;
        }
        

        StartDialog();
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Vanish()
    {
        switch (status)
        {
            case STATUS.ENIGMA:
                hud.ShowEnigma();
                gameObject.SetActive(false);
                break;

            case STATUS.CORRECT:
                hud.Show(HudEnigma.TYPE.SOLUTION);
                gameObject.SetActive(false);
                break;
            case STATUS.WRONG:
                ShowAds();
                StopCoroutine(Type());
                break;

            case STATUS.TUTORIAL:
                GameManager.instance.OpenMenu();
                break;

            case STATUS.END:
                GameManager.instance.OpenMenu();
                break;

            case STATUS.MULTIPLE:
                if ( hud != null && hud.nEnigma == 25)
                {
                    hud.Show(HudEnigma.TYPE.SOLUTION);
                    gameObject.SetActive(false);
                }
                else if(GameManager.instance.lastSolved == 30 && GameManager.instance.indexStatus == GameManager.instance.indexEndDarkKnight)
                {
                    GameManager.instance.OpenMenu();
                }
                else
                {
                    textDisplay.text = "";
                    StopAllCoroutines();
                    index = 0;
                    gameObject.SetActive(false);
                }
                break;

            default:
                textDisplay.text = "";
                StopAllCoroutines();
                index = 0;
                gameObject.SetActive(false);
                break;
        }
    }

    public void NextSentences()
    {
        MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.CLICK, 0);

        animationDialog.talking = true;
        continueButton.SetActive(false);

        if (index < nowSentences.Length)
        {
            index++;
            if (index >= nowSentences.Length)
            {
                switch (status)
                {
                    case STATUS.WRONG:
                        ShowAds();
                        break;
                    case STATUS.CORRECT:
                        Vanish();
                        break;
                    case STATUS.START:
                        GameManager.instance.OpenTutorial();
                        break;
                    case STATUS.ENIGMA:
                        Vanish();
                        break;
                    case STATUS.TUTORIAL:
                        if (tutorialDialog.statusTutorial == tutorialDialog.endSTATUS - 1)
                        {
                            GameManager.instance.OpenMenu();
                        }
                        else
                        {
                            tutorialDialog.StartCoroutine(tutorialDialog.ChangeStatusTutorial());
                        }
                        break;
                    default:
                        Vanish();
                        break;
                }
            }
            else
            {
                if (status == STATUS.MULTIPLE)
                {
                    animationDialog.ChangeCharacter(multipleDialog.charSentence[index]);
                }
                textDisplay.text = "";
                StartCoroutine(Type());
            }
        }
    }

    public void StartDialog()
    {
        if(hud != null)
         hud.VanishAll();
    }

    private void UnpackTexts()
    {
        sentencesITA = UnpackText(textITA);  
        sentencesWrongITA = UnpackText(textWrongITA);
        sentencesCorrectITA = UnpackText(textCorrectITA);

        sentencesENG = UnpackText(textENG);
        sentencesWrongENG = UnpackText(textWrongENG);
        sentencesCorrectENG = UnpackText(textCorrectENG);
    }

    public string[] UnpackText(string text)
    {
        int maxChar = 120;
        int nChar = 0;
        string line = "";
        string lineSenteces = "";
        List<string> unpackText = new List<string>();

        if (text != null)
        {

            foreach (string s in text.Split(' '))
            {
                line += s + " ";
                if (s.Contains(".") || s.Contains("!") || s.Contains("...")
                    || s.Contains(",") || s.Contains("?") || s.Contains(":") || s.Contains(")"))
                {
                    if (nChar + line.Length > maxChar)
                    {
                        unpackText.Add(lineSenteces);
                        lineSenteces = "";
                        lineSenteces += line;
                        line = "";
                        nChar = lineSenteces.Length;
                    }
                    else
                    {
                        lineSenteces += line + " ";
                        nChar += lineSenteces.Length;
                        line = "";
                    }
                }
            }

            unpackText.Add(lineSenteces);
        }

        return unpackText.ToArray();
    }

    public void ShowAds()
    {
        if (status == STATUS.WRONG)
        {
            StartCoroutine(MoneyAndAds());
        }
    }

    public void SetLanguage()
    {

    }

    public IEnumerator Type()
    {
        int nChar = 0;

        if (nowSentences.Length > 0)
        {
            isWriting = true;
            foreach (char letter in nowSentences[index].ToCharArray())
            {

                if(isSkippable)
                {
                    textDisplay.text = nowSentences[index];
                    isSkippable = false;
                    break;
                }
                nChar++;
                textDisplay.text += letter;
                yield return new WaitForSeconds(typingSpeed);

                if (nowSentences[index].Contains("eheheh") || nowSentences[index].Contains("EHEHEH"))
                {
                    if (index == nowSentences.Length - 1
                        && nChar >= nowSentences[index].Length - 10)
                    {
                        MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.LAUGH, 0);
                        nChar = 0;
                    }
                }
            }
            nChar = 0;
            isWriting = false;
        }
    }
    IEnumerator MoneyAndAds()
    {
        MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.MONEY, 0.0f);
        yield return new WaitForSeconds(0.8f);
        AdController.instance.PlayVideoAds();
        gameObject.SetActive(false);
        hud.ShowEnigma();
    }
    public void SkipDialog()
    {
        if (isWriting)
        {
            isSkippable = true;
        }
      
    }
}
