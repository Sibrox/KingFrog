using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Testo : MonoBehaviour
{
    public GameObject Opacita;
    public GameObject Confirm;
    public GameObject Esatto;
    public GameObject Sbagliato;
    public bool Video;
    public WrongAndGood componentCorrect; 

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Opacita.SetActive(true);
        Confirm.SetActive(true);
    }


    public void Show()
    {
        
    }

    public void onClick()
    {
        GameManager gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        if (componentCorrect.correctAnswer)
            Video = true;
        else
            Video = false;

        if (!Video)
            gm.LoadSceneByIndex(gm.indexWrong);
        else
            gm.LoadSceneByIndex(gm.indexRight);
    } 

}




