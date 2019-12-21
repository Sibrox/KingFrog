using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenitoPack : MonoBehaviour
{
    public GameObject paccoVero;
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.gyro.attitude.eulerAngles);
        if(Input.gyro.attitude.eulerAngles.z >=220 && Input.gyro.attitude.eulerAngles.z <= 360)
        {
            paccoVero.SetActive(true);
        }
    }
}
