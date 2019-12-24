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
        Debug.Log(Input.acceleration.magnitude);
        //Debug.Log(Input.gyro.attitude.eulerAngles);
        if (Input.acceleration.magnitude >= 3.0f)
        {    
            paccoVero.SetActive(true);
        }
    }
}
