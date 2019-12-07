using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KingFrog;

public class MultipleDialog : MonoBehaviour
{

    public TextAsset jsonFile;
    public DialogSentence[] dialogComplete;

    public CHARACTER[] charSentence;

    public DialogBox dialogComponent;
    public AnimationDialog animationDialog;

    private string[] sentencesITA;
    private string[] sentencesENG;

    public bool changed;

    // Start is called before the first frame update
    void Start()
    {
        if (jsonFile != null)
        {
            changed = false;
            dialogComplete = JsonHelper.getJsonArray<DialogSentence>(jsonFile.ToString());
            charSentence = new CHARACTER[dialogComplete.Length];
            sentencesITA = new string[dialogComplete.Length];
            sentencesENG = new string[dialogComplete.Length];
            for (int i = 0; i < dialogComplete.Length; i++)
            {
                switch (dialogComplete[i].character)
                {
                    case "MD":
                        {
                            charSentence[i] = CHARACTER.MADALINA;
                            break;
                        }
                    case "DK":
                        {
                            charSentence[i] = CHARACTER.DARK_KNIGHT;
                            break;
                        }
                    case "BG":
                        {
                            charSentence[i] = CHARACTER.BOG;
                            break;
                        }
                    case "NL":
                        {
                            charSentence[i] = CHARACTER.NIL;
                            break;
                        }
                }
                sentencesITA[i] = dialogComplete[i].textITA;
                sentencesENG[i] = dialogComplete[i].textENG;
            }

            if (dialogComponent.status == DialogBox.STATUS.MULTIPLE)
            {
                if (GameManager.instance.lang == Language.LANG.ITA)
                {
                    dialogComponent.nowSentences = sentencesITA;

                }
                else
                {
                    dialogComponent.nowSentences = sentencesENG;
                }

                dialogComponent.SetIndex(0);
                dialogComponent.textDisplay.text = "";
                //animationDialog.ChangeCharacter(charSentence[0]);
                dialogComponent.StartCoroutine(dialogComponent.Type());
                //dialogComponent.StartDialog();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (jsonFile != null && !changed && dialogComponent.status == DialogBox.STATUS.MULTIPLE)
        {
            changed = true;
            animationDialog.ChangeCharacter(charSentence[0]);
        }
    }

}
