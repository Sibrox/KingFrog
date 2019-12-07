using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckWine : MonoBehaviour
{

    public Text[] empty;
    public Text[] middle;
    public Text[] full;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckSolution()
    {
        if (CalculateWine())
        {
            GameManager.instance.LoadSceneByIndex(GameManager.instance.indexRight);
        }
        else
        {
            GameManager.instance.LoadSceneByIndex(GameManager.instance.indexWrong);
        }
    }

    public bool CalculateWine()
    {
        float sum = 0;
        for(int i=0; i<3; i++)
        {
            sum += int.Parse(empty[i].text);
        }
        if (sum != 7) return false;

        sum = 0;
        for (int i = 0; i < 3; i++)
        {
            sum += int.Parse(middle[i].text);
        }
        if (sum != 7) return false;

        sum = 0;
        for (int i = 0; i < 3; i++)
        {
            sum += int.Parse(full[i].text);
        }
        if (sum != 7) return false;

        sum = 0;
        for (int i = 0; i < 3; i++)
        {
            sum += float.Parse(empty[i].text);
            sum += float.Parse(middle[i].text) * 0.5f;
            if (sum != 3.5f) return false;
            sum = 0;
        }

        for (int i = 0; i < 3; i++)
        {
            sum += float.Parse(empty[i].text);
            sum += float.Parse(middle[i].text);
            sum += float.Parse(empty[i].text);

            if (sum != 7) return false;
            sum = 0;
        }

        return true;
    }
}
