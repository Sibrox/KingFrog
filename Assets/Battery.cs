using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{

    public bool charging;

    public Sprite[] battery;
    // Start is called before the first frame update
    void Start()
    {
        charging = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!charging && (SystemInfo.batteryStatus ==  BatteryStatus.Charging || SystemInfo.batteryStatus == BatteryStatus.Full || SystemInfo.batteryStatus == BatteryStatus.NotCharging))
        {
            charging = true;
            StartCoroutine(TurnBattery());
        }


    }


    IEnumerator TurnBattery()
    {
        for(int i = 0; i < 7 && charging; i++)
        {
            GetComponent<Image>().sprite = battery[i];
            yield return new WaitForSeconds(0.5f);
        }
    }

}
