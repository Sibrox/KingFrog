using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckSentinelle : MonoBehaviour
{

    public LineDrawer[] sentinelle;
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
        if (CheckSolution())
        {
            gm.LoadSceneByIndex(gm.indexRight);
        }
        else
        {
            gm.LoadSceneByIndex(gm.indexWrong);
        }
    }

    private bool CheckSolution()
    {

        for(int i = 0; i < sentinelle.Length; i++)
        {
            if (sentinelle[i].tag_connected != sentinelle[i].tag_end)
            {
                Debug.Log("Sentinella nel posto sbagliato");
                return false;
            }
        }

        for (int i = 0; i < sentinelle.Length; i++)
        {
            for (int j = i + 1; j < sentinelle.Length; j++)
            {
                if(!ComparePositions(sentinelle[i].grid, sentinelle[j].grid)){
                    Debug.Log(sentinelle[i] + ", "+sentinelle[j]);
                    return false;
                }
            }
        }

        return true;
    }

    private bool ComparePositions(List<Vector2> array1, List<Vector2> array2)
    {
        for(int i = 0; i < array1.Count; i++)
        {
            for(int j = 0; j < array2.Count; j++)
            {
                if (array1[i].x == array2[j].x && array1[i].y == array2[j].y)
                {
                    Debug.Log("STRADE SI INCROCIANO");
                    return false;
                }
            }
        }

        return true;
    }
}
