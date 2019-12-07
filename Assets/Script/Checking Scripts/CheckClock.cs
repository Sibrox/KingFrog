using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckClock : MonoBehaviour
{

    public ClockDrawing clock1, clock2;
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
        if(clock1.locked && clock2.locked)
        {
            GameManager.instance.LoadSceneByIndex(GameManager.instance.indexRight);
        }
        else
        {
            GameManager.instance.LoadSceneByIndex(GameManager.instance.indexWrong);
        }
    }
}
