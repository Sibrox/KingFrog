using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericDrag : MonoBehaviour
{
    public bool dragging,draggable;


    public new bool camera;
    // Start is called before the first frame update
    void Start()
    {
        dragging = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if(dragging && draggable && !camera)
        {
            transform.position = Input.mousePosition;
        }

        if(dragging && draggable && camera)
        {
            transform.localPosition = Input.mousePosition;
        }
    }

    public void OnDrag()
    {
        dragging = true;
    }

    public void OnDrop()
    {
        dragging = false;
    }
}
