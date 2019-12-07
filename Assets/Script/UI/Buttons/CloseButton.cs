using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        GameObject.Find("Left Frame").GetComponent<LeftFrame>().Restore();
    }

    public void OpenLeftFrame()
    {
        GameObject.Find("Left Frame").SetActive(true);
    }

}
