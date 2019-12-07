using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialDialog : MonoBehaviour
{
    public int statusTutorial;
    public int endSTATUS;
    DialogBox dialogBox;

    [Space(10)]

    [TextArea]
    public string[] sentences = new string[8];

    [Space(10)]

    [TextArea]
    public string[] sentencesENG = new string[8];

    public string[][] tutorialSentences = new string[9][];

    [Space(10)]

    public GameObject[] objectStatus;

    bool tutorialEnd;

    // Start is called before the first frame update
    void Start()
    {
        statusTutorial = 0;
        dialogBox =  gameObject.GetComponent<DialogBox>();


        switch(GameManager.instance.lang) {
            case Language.LANG.ITA:

                for (int i = 0; i < sentences.Length; i++)
                {
                   tutorialSentences[i] = dialogBox.UnpackText(sentences[i]);
                }
                break;

            case Language.LANG.ENG:

                for (int i = 0; i < sentences.Length; i++)
                {
                    tutorialSentences[i] = dialogBox.UnpackText(sentencesENG[i]);
                }
                break;
        }

        dialogBox.nowSentences = tutorialSentences[0];

        StartCoroutine(ChangeStatusTutorial());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ChangeStatusTutorial()
    {

        if (tutorialEnd)
        {
            statusTutorial++;
            if (statusTutorial < endSTATUS)
            {
                dialogBox.nowSentences = tutorialSentences[statusTutorial];
                dialogBox.SetIndex(0);
                dialogBox.StartCoroutine(dialogBox.Type());
            }
        }
        else
        {

            foreach (Image image in gameObject.GetComponentsInChildren<Image>())
            {
                image.enabled = false;
            }

            foreach (Text text in gameObject.GetComponentsInChildren<Text>())
            {
                text.enabled = false;
            }

            if (statusTutorial >= 0 && objectStatus[statusTutorial])
                objectStatus[statusTutorial].SetActive(true);
            yield return new WaitForSeconds(2);

            foreach (Image image in gameObject.GetComponentsInChildren<Image>())
            {
                image.enabled = true;
            }

            foreach (Text text in gameObject.GetComponentsInChildren<Text>())
            {
                text.enabled = true;
            }

            dialogBox.textDisplay.text = "";

            
            if (statusTutorial < endSTATUS)
            {
                dialogBox.nowSentences = tutorialSentences[statusTutorial];
                dialogBox.SetIndex(0);
                dialogBox.StartCoroutine(dialogBox.Type());
            }
            statusTutorial++;
        }
    }


    public void EndTutorialBeforFinished()
    {
        dialogBox.continueButton.SetActive(false);
        statusTutorial = 6;
        tutorialEnd = true;
        dialogBox.StopAllCoroutines(); 
        dialogBox.textDisplay.text = "";
        dialogBox.nowSentences = tutorialSentences[statusTutorial];
        dialogBox.SetIndex(0);
        StartCoroutine(ChangeStatusTutorial());
    }
}

