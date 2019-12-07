using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckCarello : MonoBehaviour
{

    public Piece [] pieces;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckEnigma()
    {
        GameManager gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        bool value = true;
        for(int i = 0; i < pieces.Length; i++)
        {
            if (!pieces[i].attached)
            {
                value = false;
                break;
            }
        }

        if(value)
        {
            gm.LoadSceneByIndex(gm.indexRight);
        }
        else
        {
            gm.LoadSceneByIndex(gm.indexWrong);
        }

    }
}
