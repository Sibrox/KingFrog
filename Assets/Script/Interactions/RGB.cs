using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGB
{
    public enum COLOR
    {
        RED,
        GREEN,
        BLUE
    };

    public COLOR color;

    public RGB()
    {

    }

    public static RGB operator + (RGB rgb1,RGB rgb2)
    {
        RGB sum = new RGB();



        return sum;
    }
}
