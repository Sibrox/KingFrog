using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CheckAnimals : MonoBehaviour
{

    public DrawLineFences[] bounds;
    public int[] n_fences;
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
        GameManager gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        if ( bounds[0].fence_connected == n_fences[0] &&
            bounds[1].fence_connected == n_fences[1] &&
            bounds[2].fence_connected == n_fences[2] &&
            bounds[3].fence_connected == n_fences[3]
            )
        {
            gm.LoadSceneByIndex(gm.indexRight);
        }
        else
        {
            gm.LoadSceneByIndex(gm.indexWrong);
        }
    }
}
