using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SolutionEnigma : MonoBehaviour
{

    [TextArea]
    public string solutionITA;
    public bool isEnglish;
    [TextArea]
    public string solutionENG;

    public Text textDisplay;

    // Start is called before the first frame update
    void Start()
    {
        GameManager gm = GameManager.instance;
        switch (gm.lang)
        {
            case Language.LANG.ITA:
                textDisplay.text = solutionITA;
                break;

            case Language.LANG.ENG:
                textDisplay.text = solutionENG;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
