using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draw : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Canvas;
    private LineRenderer lineRenderer;
    void Start()
    {
        drawLine();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void drawLine()
    {
        GameObject lineObject = new GameObject();
        this.lineRenderer = lineObject.AddComponent<LineRenderer>();
        this.lineRenderer.startWidth = 3.0f;
        this.lineRenderer.endWidth = 3.0f;
    }
}
