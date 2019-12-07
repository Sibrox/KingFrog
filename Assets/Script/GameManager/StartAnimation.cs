using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StartAnimation : MonoBehaviour
{

    public GameObject start;

    public VideoPlayer videoplayer;
    public bool end;
    // Start is called before the first frame update
    void Start()
    {
        videoplayer.Play();
        videoplayer.loopPointReached += EndVideo;
        end = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndVideo(VideoPlayer vp)
    {
        if (!end)
        {
            start.SetActive(true);
            end = true;
        }
    }
}
