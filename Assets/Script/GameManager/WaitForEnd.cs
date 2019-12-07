using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class WaitForEnd : MonoBehaviour
{

    public VideoPlayer videoPlayerITA,videoPlayerENG;
    // Start is called before the first frame update
    void Start()
    {

        switch (GameManager.instance.lang)
        {
            case Language.LANG.ITA:
                videoPlayerITA.Play();
                videoPlayerITA.loopPointReached += EndVideo;

                break;
            case Language.LANG.ENG:
                videoPlayerENG.Play();
                videoPlayerENG.loopPointReached += EndVideo;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndVideo(VideoPlayer vp)
    { 
        GameManager.instance.LoadSceneByIndex(GameManager.instance.indexEnigma);
    }
}
