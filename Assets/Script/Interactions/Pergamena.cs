using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pergamena : MonoBehaviour
{
    public GameObject redCircle, blackCircle, blueCircle, greenCircle;
    public Drawer drawer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (drawer.red)
        {
            redCircle.SetActive(true);
        }

        if (drawer.black)
        {
            blackCircle.SetActive(true);
        }

        if (drawer.blue)
        {
            blueCircle.SetActive(true);
        }

        if (drawer.green)
        {
            greenCircle.SetActive(true);
        }

    }
}
