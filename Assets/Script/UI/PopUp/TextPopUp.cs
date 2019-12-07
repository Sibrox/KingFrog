using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPopUp : MonoBehaviour
{
    public Text textPopUp;

    [TextArea]
    public string textITA;

    public bool isEnglish;
    [TextArea]
    public string textENG;

    public Image image;

    public GameObject textMultiple;
    
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.lang == Language.LANG.ENG)
        {
            textPopUp.text = textENG;
        }
        else
        {
            textPopUp.text = textITA;
        }       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Vanish()
    {
        this.gameObject.SetActive(false);
    }

    public void SetImage(Sprite sprite)
    {
        image.gameObject.SetActive(true);
        image.sprite = sprite;
    }
}
