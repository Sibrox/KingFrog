using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CheckTorch : MonoBehaviour
{

    public GridTorch [] torchs;
    public GameObject counter;
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
        GameManager gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        if (int.Parse(counter.GetComponent<Text>().text) == 5){
            foreach(GridTorch torch in torchs){
                if(torch.torch  <= 0){
                    gm.LoadSceneByIndex(gm.indexWrong);
                    return;
                }
            }
            gm.LoadSceneByIndex(gm.indexRight);
        }
        else{
            gm.LoadSceneByIndex(gm.indexWrong);
        }
        
    }
}
