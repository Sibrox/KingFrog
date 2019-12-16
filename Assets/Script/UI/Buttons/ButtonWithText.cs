using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonWithText : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [TextArea]
    public string textITA;
    [TextArea]
    public string textENG;

    [Space(10)]
    public Text text;
    [Space(5)]
    public Sprite up, down;

    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = down;
        MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.CLICK, 0.0f);
        Vector3 newPos = text.transform.localPosition;
        newPos.y -= 2.0f;
        text.transform.localPosition = newPos;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = up;
        Vector3 newPos = text.transform.localPosition;
        newPos.y += 2.0f;
        text.transform.localPosition = newPos;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.instance.lang == Language.LANG.ITA)
        {
            text.text = textITA;
        }
        if (GameManager.instance.lang == Language.LANG.ENG)
        {
            text.text = textENG;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
