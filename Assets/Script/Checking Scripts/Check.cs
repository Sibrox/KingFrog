using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Check : MonoBehaviour
{
    public int left_int,middle_int,right_int;

    public GameObject left,middle,right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkSolution()
    {
        if(int.Parse(left.GetComponent<Text>().text) == left_int 
        && int.Parse(middle.GetComponent<Text>().text) == middle_int 
        && int.Parse(right.GetComponent<Text>().text) == right_int){
            //Achivement "First steps"
            if(GameManager.instance.indexEnigma == 1)
            {
                Debug.Log("Unlocking achivement...");
                GooglePlayServices.instance.UnlockFirstStep(GooglePlayServices.ACHIVEMENT.FIRST_STEP);
            }

            GameManager.instance.LoadSceneByIndex(GameManager.instance.indexRight);
        }
        else{
            GameManager.instance.LoadSceneByIndex(GameManager.instance.indexWrong);
        }
    }
}
