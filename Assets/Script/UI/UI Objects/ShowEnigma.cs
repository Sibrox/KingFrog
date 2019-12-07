using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowEnigma : MonoBehaviour
{

    [TextArea]
    public string textEnigma;
    [TextArea]
    public string textEnigma_English;

    public Text textEnigmaObject;
   
    // Start is called before the first frame update
    void Start()
    {
        GameManager gm = GameManager.instance;
        switch (gm.lang)
        {
            case Language.LANG.ITA:
                textEnigmaObject.text = textEnigma;
                break;
            case Language.LANG.ENG:
                textEnigmaObject.text = textEnigma_English;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
