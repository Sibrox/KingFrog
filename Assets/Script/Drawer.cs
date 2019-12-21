using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class Drawer : MonoBehaviour
{
    public bool drawing;
    public GameObject painter,painterRed,painterGreen,painterBox;

    // BLACK,RED,GREEN
    public Sprite[] colors;

    public changeImage buttonBlack,buttonRed,buttonGreen,buttonBlue;
    Vector2 lastPos;

    List<GameObject> lines;
    public List<Vector2> posisitions;
    public GameObject renderBlack,renderRed,renderGreen,renderBlue;

    int nLines;

    public bool black, red, green, blue;

    public bool isOverlay;

    public Canvas canvas;


    // Start is called before the first frame update
    void Start()
    {
        drawing = false;
        buttonBlack.SetDown();
        lines = new List<GameObject>();
        posisitions = new List<Vector2>();
        nLines = 0;

        
    }

    // Update is called once per frame
    void Update()
    {

        if (drawing )
        {
            Vector2 pos;
            if (!isOverlay)
            {
                RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), Input.mousePosition, Camera.main, out pos);
                

                if (lastPos != pos)
                {
                    lastPos = pos;

                    posisitions.Add(pos);
                    lines[nLines - 1].GetComponent<UILineRenderer>().Points = posisitions.ToArray();
                }
            }
            else
            {
                pos = gameObject.GetComponent<RectTransform>().InverseTransformPoint(Input.mousePosition);

                if (lastPos != pos)
                {
                    lastPos = pos;

                    posisitions.Add(pos);
                    lines[nLines - 1].GetComponent<UILineRenderer>().Points = posisitions.ToArray();
                }

            }
        }
        
    }

    public void StartDrawLine()
    {
        if (!drawing)
        {
            GameObject newPainter;
            Vector2 pos;

            GooglePlayServices.UnlockAchivement(GooglePlayServices.ARTIST);

            if (!buttonBlack.isUp)
            {
                newPainter = GameObject.Instantiate(renderBlack);
                black = true;
                red = false;
                green = false;
                blue = false;

            }
            else if (!buttonRed.isUp)
            {
                newPainter = GameObject.Instantiate(renderRed);
                black = false;
                red = true;
                green = false;
                blue = false;
            }
            else if (!buttonBlue.isUp)
            {
                newPainter = GameObject.Instantiate(renderBlue);
                black = false;
                red = false;
                green = false;
                blue = true;
            }
            else
            {
                newPainter = GameObject.Instantiate(renderGreen);
                black = false;
                red = false;
                green = true;
                blue = false;
            }
            newPainter.transform.SetParent(renderBlack.transform.parent);
            //newPainter.transform.parent = renderBlack.transform.parent;
            newPainter.transform.localScale = new Vector3(1, 1, 1);
            newPainter.transform.position = renderBlack.transform.position;


            lines.Add(newPainter);
            nLines++;

            posisitions.Clear();
            drawing = true;
        }

    }

    public void StopDrawLine()
    {
        drawing = false;
    }
    
    public void ResetDrawing()
    {
       for(int i = 12; i< painterBox.transform.childCount;i++)
        {
            if(painterBox.transform.GetChild(i) != null)
            {
                Destroy(painterBox.transform.GetChild(i).gameObject);
            }
        }
    }


}
