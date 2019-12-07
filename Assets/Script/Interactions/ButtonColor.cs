using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ButtonColor : MonoBehaviour
{

    public bool clicked;
    public DisplayColor result;

    public Sprite up, down;

    public COLOR color;
    public int pos;

    public DisplayColor mini;
    public bool leva;
    public ButtonColor[] leve;
    public Image displayBig;

    public enum COLOR
    {
        RED,
        YELLOW,
        BLUE,
        ORANGE,
        GREEN,
        VIOLET,
        BLACK,
        WHITE
    };

    // Start is called before the first frame update
    void Start()
    {
        clicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnClick()
    {
        clicked = !clicked;
        if (!leva)
        {
            if (clicked)
            {
                GetComponent<Image>().sprite = down;
                result.AddColor(color, pos);
            }
            else
            {
                GetComponent<Image>().sprite = up;
                result.SubColor(color, pos);
            }
        }
        else
        {
            if (clicked)
            {
                GetComponent<Image>().sprite = down;
                leve[0].SetUp();
                leve[1].SetUp();
                if(color == mini.colorMini)
                {
                    if (color == COLOR.ORANGE)
                    {
                        displayBig.color = new Color(1.0f, 0.5f, 0.0f);
                        mini.colorBig = COLOR.ORANGE;
                    }
                    if (color == COLOR.VIOLET)
                    {
                        displayBig.color = new Color(1.0f, 0.0f, 1.0f);
                        mini.colorBig = COLOR.VIOLET;
                    }
                    if (color == COLOR.GREEN)
                    {
                        displayBig.color = new Color(0.0f, 1.0f, 0.0f);
                        mini.colorBig = COLOR.GREEN;
                    }
                }
            }
            else
            {
                GetComponent<Image>().sprite = up;
                displayBig.color = new Color(0.0f, 0.0f, 0.0f);
                mini.colorBig = COLOR.BLACK;
            }
        }
        MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.CLICK, 0);
    }

   public void SetUp()
    {
        clicked = false;
        GetComponent<Image>().sprite = up;
    }
}
