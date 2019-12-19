using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudEnigma : MonoBehaviour
{
    public int nEnigma;

    [Space(10)]

    public GameObject leftFrame;
    public GameObject solutionPopUp, 
        showPopUp, hintsPopUp, elements, dialogComponent, popupInteractive,drawPopUp,painterBox;

    private SolutionEnigma solutionComponent;
    private ShowEnigma showComponent;
    private HintsPopUp hintsComponent;
    private DialogBox dialogBox;

    public TextRiddle riddle;

    public enum TYPE
    {
        LEFT_FRAME,
        SOLUTION,
        SHOW,
        HINTS,
        DIALOG,
        ELEMENTS,
        CONFIRM_POPUP,
        DRAW_POPUP
    };

    // Start is called before the first frame update
    void Start()
    {
        if (dialogComponent.GetComponent<DialogBox>().status != DialogBox.STATUS.TUTORIAL)
        {

            switch (GameManager.instance.menu_status)
            {
                case KingFrog.MENU_STATUS.STORY:
                    riddle = GameManager.instance.riddles[nEnigma - 1];
                    break;
                case KingFrog.MENU_STATUS.XMAS:
                    riddle = GameManager.instance.xMasRiddle[nEnigma - 1];
                    break;
            }          

            //Debug.Log(riddle.text_ita);
            if (GameManager.instance.enteredEnigma[nEnigma - 1]
                && !GameManager.instance.checking)
            {
                Vanish(TYPE.DIALOG);
                ShowEnigma();
            }
            else
            {
                VanishAll();
                Show(TYPE.DIALOG);
            }

            solutionComponent = solutionPopUp.GetComponent<SolutionEnigma>();
            showComponent = showPopUp.GetComponent<ShowEnigma>();
            hintsComponent = hintsPopUp.GetComponent<HintsPopUp>();
            dialogBox = dialogComponent.GetComponent<DialogBox>();
            SetTextFromJSON();
        }


    }

    private void SetTextFromJSON()
    {
        solutionComponent.solutionITA = riddle.solution_ita;
        solutionComponent.solutionENG = riddle.solution_eng;

        hintsComponent.textHint1_ITA = riddle.hint1_ita;
        hintsComponent.textHint2_ITA = riddle.hint2_ita;
        hintsComponent.textHint3_ITA = riddle.hint3_ita;

        hintsComponent.textHint1_ENG = riddle.hint1_eng;
        hintsComponent.textHint2_ENG = riddle.hint2_eng;
        hintsComponent.textHint3_ENG = riddle.hint3_eng;

        showComponent.textEnigma_English = riddle.text_eng;
        showComponent.textEnigma = riddle.text_ita;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.instance.OpenMenu();
        }
    }

    public void ShowEnigma()
    {
        leftFrame.SetActive(true);
        elements.SetActive(true);
    }

    public void ShowAll()
    {
        leftFrame.SetActive(true);
        solutionPopUp.SetActive(true);
        showPopUp.SetActive(true);
        hintsPopUp.SetActive(true);
        elements.SetActive(true);
    }

    public void Show(TYPE type)
    {
        switch (type)
        {
            case TYPE.DIALOG:
                dialogComponent.SetActive(true);
                break;
            case TYPE.LEFT_FRAME:
                leftFrame.SetActive(true);
                break;
            case TYPE.SOLUTION:
                solutionPopUp.SetActive(true);
                break;
            case TYPE.HINTS:
                hintsPopUp.SetActive(true);
                break;
            case TYPE.SHOW:
                showPopUp.SetActive(true);
                break;
            case TYPE.ELEMENTS:
                elements.SetActive(true);
                break;
            case TYPE.DRAW_POPUP:
                drawPopUp.SetActive(true);
                painterBox.SetActive(true);
                break;
        }
    }

    public void VanishAll()
    {
        leftFrame.SetActive(false);
        solutionPopUp.SetActive(false);
        showPopUp.SetActive(false);
        hintsPopUp.SetActive(false);
        elements.SetActive(false);
    }

    public void ShowPopup(){

        popupInteractive.SetActive(true);
    }

    public void Vanish(TYPE type)
    {
        switch (type)
        {
            case TYPE.DIALOG:
                dialogComponent.SetActive(false);
                break;
            case TYPE.LEFT_FRAME:
                leftFrame.SetActive(false);
                break;
            case TYPE.SOLUTION:
                solutionPopUp.SetActive(false);
                break;
            case TYPE.HINTS:
                hintsPopUp.SetActive(false);
                break;
            case TYPE.SHOW:
                showPopUp.SetActive(false);
                break;
            case TYPE.ELEMENTS:
                elements.SetActive(false);
                break;
            case TYPE.DRAW_POPUP:
                drawPopUp.SetActive(false);
                painterBox.SetActive(false);
                break;
                
        }
    }

    public void VanishDrawPopUp()
    {
        Vanish(HudEnigma.TYPE.DRAW_POPUP);
    }

}
