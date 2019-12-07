using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToGame : MonoBehaviour
{
    public GameObject popUp;
    public GameObject image;
    public GameObject confirm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void onClick()
    {
        popUp.SetActive(false);
        image.SetActive(false);
        confirm.SetActive(false);
    } 
}
