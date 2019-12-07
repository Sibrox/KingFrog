using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightRGB : MonoBehaviour
{
    public bool isActive;

    public Sprite lightOn;
    Sprite lightOff;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        lightOff = GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void TurnOn()
    {
        isActive = true;
        GetComponent<Image>().sprite = lightOn;

        MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.GOLD, 0);
    }

    public void TurnOff()
    {
        isActive = false;
        GetComponent<Image>().sprite = lightOff;
        MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.CLICK2, 0);
    }
}

