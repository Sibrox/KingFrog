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
    public bool editable, powered, draggin, isEnter;
    public Drawer drawer;
    public GameObject canvas;
    private Vector3 cordinateMagnete;

    public COLOR colorePacco;
    public COLOR coloreFiocco;

    public int IndexBox = 0;

    public PacchiEN other;

    public void OnPointerDown(PointerEventData eventData)
    {
        draggin = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        draggin = false;

        if (isEnter && !other.editable)
        {
            this.gameObject.transform.localPosition = cordinateMagnete;
            editable = true;
        }
        else
        {
            editable = false;
        }
    }

    void Start()
    {
        pacco = GetComponent<Image>();
        editable = false;
        powered = false;
        draggin = false;
        isEnter = false;
        coloreFiocco = COLOR.GREEN;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (!powered && (SystemInfo.batteryStatus == BatteryStatus.Charging || SystemInfo.batteryStatus == BatteryStatus.Full || SystemInfo.batteryStatus == BatteryStatus.NotCharging))
        {
            powered = true;
            palleAccese.SetActive(true);
            MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.CORRENTE, 0);

        }

        if (draggin)
        {
            GetComponent<RectTransform>().SetAsLastSibling();
            Vector2 points = new Vector2();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), Input.mousePosition, Camera.main, out points);
            GetComponent<RectTransform>().localPosition = new Vector3(points.x , points.y, 0);
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
                pacco.sprite = imagine[3];
                coloreFiocco = COLOR.BLUE;
            }
            if (colorePacco == COLOR.GREEN)
            {
                pacco.sprite = imagine[6];
                coloreFiocco = COLOR.BLUE;
            }

        }
        if (editable && drawer.red)
        {

            if (colorePacco == COLOR.BLUE)
            {
                pacco.sprite = imagine[1];
                coloreFiocco = COLOR.RED;
            }
            if (colorePacco == COLOR.RED)
            {
                pacco.sprite = imagine[4];
                coloreFiocco = COLOR.RED;
            }
            if (colorePacco == COLOR.GREEN)
            {
                pacco.sprite = imagine[7];
                coloreFiocco = COLOR.RED;
            }
        }

        if (editable && drawer.green)
        {

            if (colorePacco == COLOR.BLUE)
            {
                pacco.sprite = imagine[2];
                coloreFiocco = COLOR.GREEN;
            }
            if (colorePacco == COLOR.RED)
            {
                pacco.sprite = imagine[5];
                coloreFiocco = COLOR.GREEN;
            }
            if (colorePacco == COLOR.GREEN)
            {
                pacco.sprite = imagine[8];
                coloreFiocco = COLOR.GREEN;
            }
        }
    }

    public void ChangeColor()
    {
        if (editable && IndexBox == 0 && powered)
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
        else if (editable && IndexBox == 1 && powered)
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
        else if (editable && IndexBox == 2 && powered)
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

            //aggiungere animazione "mancata corrente?"
        }

    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Magnetic")
        {
            isEnter = true;
            cordinateMagnete = collision.gameObject.transform.localPosition;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Magnetic")
        {
            isEnter = false;
        }
    }
}
