using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLight : MonoBehaviour
{

    public DisplayColor display;
    public LightRGB orange, green, violet;


    public int on;
    // Start is called before the first frame update
    void Start()
    {
        on = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {

        switch (on)
        {
            case 0:
                if(display.colorBig == ButtonColor.COLOR.ORANGE)
                {
                    orange.TurnOn();
                    on++;
                }                
                break;
            case 1:
                if (display.colorBig == ButtonColor.COLOR.VIOLET)
                {
                    violet.TurnOn();
                    on++;
                }
                else
                {
                    orange.TurnOff();
                    on--;
                }
                break;
            case 2:
                if (display.colorBig == ButtonColor.COLOR.GREEN)
                {
                    green.TurnOn();
                    on++;
                }
                else
                {
                    orange.TurnOff();
                    violet.TurnOff();
                    on = 0;
                }
                break;
                
        }

    }
}
