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

    public int indexXmas;

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

    public void LoadScenebyIndx(int indexScene)
    {
        StartCoroutine(LoadSceneByIndex(indexScene));
    }


    public IEnumerator LoadScene(string nameScene)
    {
        var loading = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        yield return loading;

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(nameScene));
        var closing = SceneManager.UnloadSceneAsync(nameStatus);
        yield return closing;
    }


    public IEnumerator LoadSceneByIndex(int indexScene)
    {
        var loading = SceneManager.LoadSceneAsync(indexScene, LoadSceneMode.Additive);
        yield return loading;

        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(indexScene));
        var closing = SceneManager.UnloadSceneAsync(GameManager.instance.indexStatus);
        yield return closing;

        GameManager.instance.indexStatus = indexScene;
    }


    public void StartStory()
    {

    }


    public void StartXmas()
    {
        LoadSceneByIndex(indexXmas);
    }

}
