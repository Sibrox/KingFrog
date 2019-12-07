using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingGameBoy : MonoBehaviour
{


    public Gameboy gb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckSolution()
    {
        
        if (   gb.sequence[0] == 8
            && gb.sequence[1] == 5
            && gb.sequence[2] == 8

            && gb.sequence[3] == 3
            && gb.sequence[4] == 5
            && gb.sequence[5] == 6
            && gb.sequence[6] == 5)
        {
            GameManager.instance.LoadSceneByIndex(GameManager.instance.indexRight);
        }
        else
        {
            GameManager.instance.LoadSceneByIndex(GameManager.instance.indexWrong);
        }
        
    }
}
