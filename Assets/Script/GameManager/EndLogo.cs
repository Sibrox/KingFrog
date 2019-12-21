using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EndLogo : MonoBehaviour
{

    public VideoPlayer videoPlayerLogo;
    public GameObject start,startVideo;
    public GameObject selectLanguage;
    public GameObject background;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayerLogo.Play();
        videoPlayerLogo.loopPointReached += EndVideo;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndVideo(VideoPlayer vp)
    {
        StartCoroutine(Wait());
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        GameManager.instance.LoadGame();
        videoPlayerLogo.gameObject.SetActive(false);
        if (GameManager.instance.firstRun)
        {
            start.SetActive(true);
        }
        else
        {
            start.SetActive(true);
            selectLanguage.SetActive(false);
            background.SetActive(false);
            GameManager.instance.StartGame();
                       
        }
    }
}
