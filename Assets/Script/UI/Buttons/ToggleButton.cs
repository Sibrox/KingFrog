using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToggleButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{

    public Sprite up, down;
    public bool clicked;
    public bool drawer;

    public GameObject frameName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = down;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = up;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        clicked = !clicked;
        if (clicked)
        {
            GetComponent<Image>().sprite = down;
            frameName.SetActive(true);
        }
        else
        {
            GetComponent<Image>().sprite = up;
            frameName.SetActive(false);
        }
        MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.CLICK, 0.0f);
    }
}
