using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenitoPack : MonoBehaviour
{
    public GameObject paccoVero;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.gyro.attitude.z >=140 && Input.gyro.attitude.z <= 220)
        {
            paccoVero.SetActive(true);
        }
    }
}
