using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using KingFrog;

public class EventManager : MonoBehaviour
{

    public string nameStatus;

    public MENU_STATUS status;

    public GameObject menuScenari, mainMenu, eventMenu;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LoadSceneByName(string nameScene)
    {
        StartCoroutine(LoadScene(nameScene));
    }

    public IEnumerator LoadScene(string nameScene)
    {
        var loading = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        yield return loading;

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(nameScene));
        var closing = SceneManager.UnloadSceneAsync(nameStatus);
        yield return closing;
    }



    public void StartStory()
    {

    }


}
