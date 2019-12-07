using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCustom : MonoBehaviour
{

    public AudioSource click;

    // Start is called before the first frame update
    void Start()
    {
         //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); 
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BackToMenu()
    {
        GameManager.instance.OpenMenu();
    }

    public void LoadSceneByIndex(int indexScene)
    {

        GameManager.instance.LoadSceneByIndex(indexScene);
    }

    public void PlayRewardAds()
    {
        AdController.instance.PlayRewardedVideoAds();
    }

    IEnumerator WaitingForBack()
    {
        yield return new WaitForSeconds(0);
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                GameManager.instance.OpenMenu();

        }
    }
    
}
