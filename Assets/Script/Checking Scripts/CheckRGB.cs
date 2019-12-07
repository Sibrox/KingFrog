using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRGB : MonoBehaviour
{

    public LightRGB orange, violet, green;
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
        if(orange.isActive && violet.isActive && green.isActive)
        {
            GameManager.instance.LoadSceneByIndex(GameManager.instance.indexRight);
        }
        else
        {
            GameManager.instance.LoadSceneByIndex(GameManager.instance.indexWrong);
        }
    }
}
