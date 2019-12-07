using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class changeImage : MonoBehaviour,IPointerDownHandler,IPointerUpHandler{

     public Sprite down,up,upGold,downGold,upRuna,downRuna;
     public bool isGold;
     public bool isRuna;
     public Gameboy gameboy;

    public bool isUp;

    public Transform text;

    private void Awake()
    {
        up = this.GetComponent<Image>().sprite;
        isUp = true;
    }

    void Start () {

        if(this.gameObject.transform.childCount > 0)
            text = this.gameObject.transform.GetChild(0);
        
        
     }
     
     void Update () {
     }

     public void onButtonClick(){

        if(!isGold){
            if(isRuna){
                if(gameboy.isOn){

                    this.gameObject.GetComponent<Image>().sprite = downRuna;

                }
            }
            else{
                    
                this.gameObject.GetComponent<Image>().sprite = down;
                MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.CLICK, 0);
            }
            
        }
    
        else{
            this.gameObject.GetComponent<Image>().sprite = downGold;
            MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.CLICK, 0);
        }

        if(text != null)
        {
            text.localPosition += new Vector3(0, -2,0);
        }

        
     }

     public void onButtonRelease(){

        if(!isGold){
            if(isRuna){
                if(gameboy.isOn){
                    MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.BIP,0);
                    this.gameObject.GetComponent<Image>().sprite = upRuna;

                }

            }
            else{
                this.gameObject.GetComponent<Image>().sprite = up;
            }
        }
        else{
            this.gameObject.GetComponent<Image>().sprite = upGold;
        }

        if (text != null)
        {
            text.localPosition += new Vector3(0, 2, 0);
        }

      
     }

     public void MakeGold(){
        isGold = true;      
        this.gameObject.GetComponent<Image>().sprite = upGold;
        GetComponent<Image>().color = new Color(255, 255, 255);

        MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.GOLD, 0);
    }
    public void SetGold(){

        isGold = true;
        GetComponent<Image>().color = new Color(255, 255, 255);
        this.gameObject.GetComponent<Image>().sprite = upGold;
    }

    public void SetDown()
    {
        this.gameObject.GetComponent<Image>().sprite = down;
        isUp = false;
    }


    public void SetUp()
    {
        this.gameObject.GetComponent<Image>().sprite = up;
        isUp = true;
    }

    public void Toogle()
    {
        if (isUp) SetDown();
        else SetUp();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isGold)
        {
            if (isRuna)
            {
                if (gameboy.isOn)
                {

                    this.gameObject.GetComponent<Image>().sprite = downRuna;

                }
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isGold)
        {
            if (isRuna)
            {
                if (gameboy.isOn)
                {
                    MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.BIP, 0);
                    this.gameObject.GetComponent<Image>().sprite = upRuna;

                }
            }
        }
    }
}
