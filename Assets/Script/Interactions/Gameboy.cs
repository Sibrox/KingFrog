using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameboy : MonoBehaviour
{

    public bool isOn;

    public Image gameBoy, redButton, blueButton;


    public Sprite gameBoyOn, gameBoyOff, redButtonDown, redButtonUp, blueButtonDown, BlueButtonUp;

    public Sprite[] runes;
    public Image[] iconRune;

    public int[] sequence;

    int index;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        isOn = false;
        sequence = new int[7];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        if (isOn)
        {
            MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.CLICK2IN,0);
            gameBoy.sprite = gameBoyOff;
            redButton.sprite = redButtonUp;

        }
        else
        {
            MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.CLICK2OUT,0);
            gameBoy.sprite = gameBoyOn;
            redButton.sprite = redButtonDown;

        }

        isOn = !isOn;   
    }

    public void AddRuna(int nRuna)
    {
        if (isOn && index<7)
        {
            sequence[index] = nRuna;

            iconRune[index].sprite = runes[nRuna - 1];
            index++;
        }
    }

    public void DelRuna()
    {
        if (index > 0)
        {
            MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.CLICK,0);
            sequence[index - 1] = 0;
            iconRune[index - 1].sprite = runes[9];
            index--;
        }

        MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.CLICK,0);
    }

    public void TurnOn()
    {
        gameBoy.sprite = gameBoyOn;
        redButton.sprite = redButtonDown;
        isOn = true;
    }

    public void Solve()
    {
        sequence[0] = 8;
        iconRune[0].sprite = runes[7];

        sequence[1] = 5;
        iconRune[1].sprite = runes[4];

        sequence[2] = 8;
        iconRune[2].sprite = runes[7];

        sequence[3] = 3;
        iconRune[3].sprite = runes[2];

        sequence[4] = 5;
        iconRune[4].sprite = runes[4];

        sequence[5] = 6;
        iconRune[5].sprite = runes[5];

        sequence[6] = 5;
        iconRune[6].sprite = runes[4];

        index = 7;
    }

}
