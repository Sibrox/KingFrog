using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events; // This is so that you can extend the pointer handlers
using UnityEngine.EventSystems; // This is so that you can extend the pointer handlers

public class StartButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (Text text in gameObject.GetComponentsInChildren<Text>())
        {
            text.color = new Color(0.8f, 0.1f, 0.1f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (Text text in gameObject.GetComponentsInChildren<Text>())
        {
            text.color = new Color(1, 1, 1); text.fontSize = 30;
        }
    }
}
