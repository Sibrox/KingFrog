using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerMultiple : MonoBehaviour
{

    public MultipleChoice multipleChoice;

    public string textITA;
    public string textENG;
    private string text;

    public TextPopUp popUp;

    public bool value;
    public bool hasImage;
    public bool hasText;
  

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.instance.lang == Language.LANG.ITA)
        {
            text = textITA;
        }
        else
        {
            text = textENG;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        multipleChoice.isRight = value;
        popUp.gameObject.SetActive(true);
        if (hasText)
        {
            popUp.textMultiple.SetActive(true);
            popUp.textMultiple.GetComponent<Text>().text = text;
        }
        if (hasImage)
        {
            popUp.SetImage(GetComponent<Image>().sprite);
        }

    }

}
