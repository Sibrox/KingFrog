using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPergamena : MonoBehaviour
{
    public GameObject red, green, blue, black;

    public GameObject fakePopUp,realPopUp;

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
        if (red.activeSelf && blue.activeSelf && green.activeSelf && black.activeSelf)
        {
                GameManager.instance.LoadSceneByIndex(GameManager.instance.indexRight);
        }
        else
        {
            if (fakePopUp.activeSelf)
            {
                GameManager.instance.LoadSceneByIndex(GameManager.instance.indexWrong);
            }
            fakePopUp.GetComponent<PopUp>().show();
        }
    }



}
