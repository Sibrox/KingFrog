using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class ClockDrawing : MonoBehaviour
{

    public bool isEntered,dragging,locked;

    public UILineRenderer lineRender;

    public Canvas canvas;

    public Vector2 startPos,endPos;
    Vector2[] positions;

    ClockDrawing endClock;

    ClockDrawing[] allClocks;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        endPos = transform.localPosition;

        allClocks = gameObject.transform.parent.gameObject.GetComponentsInChildren<ClockDrawing>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), Input.mousePosition, Camera.main, out pos);

            positions = new Vector2[2];
            positions[0] = startPos;
            positions[1] = pos;
            lineRender.Points = positions;

            transform.localPosition = pos;
        }
        else
        {
            transform.localPosition = startPos;
        }
    }

    public void OnDrag()
    {
        if (!dragging)
        {
            ResetAll();
            dragging = true;
            positions = new Vector2[2];
            positions[0] = startPos;
            positions[1] = startPos;
            lineRender.Points = positions;
            locked = false;
            if(endClock != null)
            endClock.locked = false;
        }
    }

    public void OnDrop()
    {

        if (dragging)
        {
            dragging = false;
            transform.localPosition = startPos;
            if (!locked)
            {
                positions = new Vector2[2];
                positions[0] = startPos;
                positions[1] = startPos;
                lineRender.Points = positions;

            }
            else
            {
                positions = new Vector2[2];
                positions[0] = startPos;
                positions[1] = endPos;
                lineRender.Points = positions;
                endClock.locked = true;

                MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.FEED_OR_LOCK, 0);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dragging)
        {
            locked = true;
            endPos = collision.transform.localPosition;
            endClock = collision.gameObject.GetComponent<ClockDrawing>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (dragging)
        {
            locked = false;
        }
        else
        {
            OnDrop();
        }
    }

    public void ResetLine()
    {
        locked = false;
        positions = new Vector2[2];
        positions[0] = startPos;
        positions[1] = startPos;
        lineRender.Points = positions;
    }


    public void ResetAll()
    {
        foreach (ClockDrawing clock in allClocks)
        {
            clock.locked = false;
        }
    }
}
