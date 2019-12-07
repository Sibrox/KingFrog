using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleChoice : MonoBehaviour
{

    public bool isActive;
    public bool isRight;

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
        if (isActive)
        {
            if (isRight)
            {
                GameManager.instance.LoadSceneByIndex(GameManager.instance.indexRight);
            }
            else
            {
                GameManager.instance.LoadSceneByIndex(GameManager.instance.indexWrong);
            }
        }
    }
}


