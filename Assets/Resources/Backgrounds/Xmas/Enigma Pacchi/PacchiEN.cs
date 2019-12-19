using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using KingFrog;

public class PacchiEN : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image pacco;
    public GameObject palleAccese;
    public Sprite[] imagine; //pacco Blu-Blu, Blu-Rosso, Blu-Verde, Rosso-Blu, Rosso-Rosso, Rosso-Verde, Verde-Blu, Verde-Rosso, Verde-Verde
    public bool editable, powered, draggin;
    public Drawer drawer;

    public COLOR colorePacco;
    public COLOR coloreFiocco;

    public int IndexBox = 0;

    public void OnPointerDown(PointerEventData eventData)
    {
        draggin = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        draggin = false;
    }

    void Start()
    {
        pacco = GetComponent<Image>();
        editable = false;
        powered = false;
        draggin = false;
        coloreFiocco = COLOR.GREEN;
    }

    // Update is called once per frame
    void Update()
    {
        if (!powered && (SystemInfo.batteryStatus == BatteryStatus.Charging || SystemInfo.batteryStatus == BatteryStatus.Full || SystemInfo.batteryStatus == BatteryStatus.NotCharging))
        {
            powered = true;
            palleAccese.SetActive(true);

        }


        /* if (){    //Si trova in quella posizione

             editable = true;
             */

        if (editable && drawer.blue)
        {

            if (colorePacco == COLOR.BLUE)
            {
                pacco.sprite = imagine[0];
                coloreFiocco = COLOR.BLUE;
            }
            if (colorePacco == COLOR.RED)
            {
                pacco.sprite = imagine[1];
                coloreFiocco = COLOR.BLUE;
            }
            else
            {
                pacco.sprite = imagine[2];
                coloreFiocco = COLOR.BLUE;
            }

        }
        if (editable && drawer.red)
        {

            if (colorePacco == COLOR.BLUE)
            {
                pacco.sprite = imagine[3];
                coloreFiocco = COLOR.RED;
            }
            if (colorePacco == COLOR.RED)
            {
                pacco.sprite = imagine[4];
                coloreFiocco = COLOR.RED;
            }
            else
            {
                pacco.sprite = imagine[5];
                coloreFiocco = COLOR.RED;
            }
        }

        if (editable && drawer.green)
        {

            if (colorePacco == COLOR.BLUE)
            {
                pacco.sprite = imagine[6];
                coloreFiocco = COLOR.GREEN;
            }
            if (colorePacco == COLOR.RED)
            {
                pacco.sprite = imagine[7];
                coloreFiocco = COLOR.GREEN;
            }
            else
            {
                pacco.sprite = imagine[8];
                coloreFiocco = COLOR.GREEN;
            }
        }
    }

    public void ChangeColor()
    {
        if (editable && IndexBox == 0)
        {
            if (coloreFiocco == COLOR.BLUE)
            {
                pacco.sprite = imagine[0];
            }
            if (coloreFiocco == COLOR.RED)
            {
                pacco.sprite = imagine[1];
            }
            if (coloreFiocco == COLOR.GREEN)
            {
                pacco.sprite = imagine[2];
            }
        colorePacco = COLOR.BLUE;
        IndexBox++;
        }
        if (editable && IndexBox == 1)
        {
            if (coloreFiocco == COLOR.BLUE)
            {
                pacco.sprite = imagine[3];
            }
            if (coloreFiocco == COLOR.RED)
            {
                pacco.sprite = imagine[4];
            }
            if (coloreFiocco == COLOR.GREEN)
            {
                pacco.sprite = imagine[5];
            }
        colorePacco = COLOR.RED;
        IndexBox++;
        }
        if (editable && IndexBox == 2)
        {

            if (coloreFiocco == COLOR.BLUE)
            {
                pacco.sprite = imagine[6];
            }
            if (coloreFiocco == COLOR.RED)
            {
                pacco.sprite = imagine[7];
            }
            if (coloreFiocco == COLOR.GREEN)
            {
                pacco.sprite = imagine[8];
            }
        colorePacco = COLOR.GREEN;
        IndexBox = 0;
        }
    }
}
