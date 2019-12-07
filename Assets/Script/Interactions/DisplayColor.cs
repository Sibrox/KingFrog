using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayColor : MonoBehaviour
{
    public ButtonColor.COLOR[] colors;

    public int nColor;

    public ButtonColor.COLOR colorMini,colorBig;



    // Start is called before the first frame update
    void Start()
    {
        nColor = 0;
        colorMini = ButtonColor.COLOR.BLACK;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void AddColor(ButtonColor.COLOR color,int pos)
    {
        colors[pos] = color;
        nColor++;
        Display();
    }

    public void SubColor(ButtonColor.COLOR color,int pos)
    {
        colors[pos] = ButtonColor.COLOR.BLACK;
        nColor--;
        Display();
    }
  
     public void Display()
    {
        bool red = false, yellow = false, blue = false;

        if (colors[0] == ButtonColor.COLOR.RED) red = true;
        if (colors[1] == ButtonColor.COLOR.YELLOW) yellow = true;
        if (colors[2] == ButtonColor.COLOR.BLUE) blue = true;

        switch (nColor) {

            case 0:
                GetComponent<Image>().color = new Color(0, 0, 0);
                colorMini = ButtonColor.COLOR.BLACK;
                break;

            case 1:
                if (red)
                {
                    GetComponent<Image>().color = new Color(1.0f, 0, 0);
                    colorMini = ButtonColor.COLOR.RED;
                }
                if (yellow)
                {
                    GetComponent<Image>().color = new Color(1.0f, 1.0f, 0);
                    colorMini = ButtonColor.COLOR.YELLOW;
                }
                if (blue)
                {
                    GetComponent<Image>().color = new Color(0, 0, 1.0f);
                    colorMini = ButtonColor.COLOR.BLUE;
                }
                break;

            case 2:
                if(red && yellow)
                {
                    GetComponent<Image>().color = new Color(1.0f, 0.5f, 0);
                    colorMini = ButtonColor.COLOR.ORANGE;
                }
                if(red && blue)
                {
                    GetComponent<Image>().color = new Color(1.0f, 0, 1.0f);
                    colorMini = ButtonColor.COLOR.VIOLET;
                }
                if(yellow && blue)
                {
                    GetComponent<Image>().color = new Color(0, 1.0f, 0);
                    colorMini = ButtonColor.COLOR.GREEN;
                }
                break;

            case 3:
                GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
                colorMini = ButtonColor.COLOR.WHITE;
                break;
        } 
    }

}
