using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveSolid : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool draggin;
    public GameObject canvas;

    public void OnPointerDown(PointerEventData eventData)
    {
        draggin = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        draggin = false;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
            

        if (draggin)
        {
            GetComponent<RectTransform>().SetAsLastSibling();
            Vector2 points = new Vector2();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), Input.mousePosition, Camera.main, out points);
            GetComponent<RectTransform>().localPosition = new Vector3(points.x, points.y, 0);
        }
        
    }
}
