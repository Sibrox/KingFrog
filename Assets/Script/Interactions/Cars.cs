using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cars : MonoBehaviour
{

    public Vector2 posGrid;
    Vector2 pos, newPos,mousePos;

    bool startDragging;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrag()
    {
        if (!startDragging)
        {
            mousePos= Input.mousePosition;
            startDragging = true;
        }
    }

    public void OnDrop()
    {

    }
}
