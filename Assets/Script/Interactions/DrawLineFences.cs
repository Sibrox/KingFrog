using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class DrawLineFences : MonoBehaviour
{
    public UILineRenderer[] lineRenderer;
    public List<Vector2> positions;

    public DrawLineFences counter;

    public Vector2 start_pos, end_pos,pos_connected,localStart;

    public bool connected;
    public bool dragging;

    public bool work;

    public int count, this_count, n_fence,fence_connected;
    public AudioSource trigger;

    public int entered;
    GameObject connected_object;

    // Start is called before the first frame update
    void Start()
    {
        localStart = transform.localPosition;
        start_pos = transform.position;
        end_pos = gameObject.GetComponent<RectTransform>().parent.InverseTransformPoint(gameObject.transform.position);
        positions.Add(end_pos);
        positions.Add(end_pos);

        dragging = false;
        connected = false;
        count = 0;
        entered = 0;
        this_count = counter.count;
        fence_connected = n_fence;
    }

    // Update is called once per frame
    void Update()
    {

        if (dragging)
        {
            this_count = counter.count;
            positions[1] = gameObject.GetComponent<RectTransform>().parent.InverseTransformPoint(gameObject.transform.position);
            lineRenderer[counter.count].Points = positions.ToArray();
            transform.position = Input.mousePosition;
        }
    }

    public void OnDrag()
    {
        if (!connected && counter.count < 4)
            dragging = true;
    }

    public void OnDrop()
    {
        if (entered > 0)
        {
            dragging = false;
            connected = true;
            connected_object.GetComponent<DrawLineFences>().connected = true;
            MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.FEED_OR_LOCK, 0);
            transform.localPosition = localStart;
            
            positions[1] = pos_connected;
            lineRenderer[counter.count].Points = positions.ToArray();
            counter.count += 1;           
        }
        else
        {
            dragging = false;
            transform.localPosition = localStart;
            positions[0] = gameObject.GetComponent<RectTransform>().parent.InverseTransformPoint(gameObject.transform.position);
            positions[1] = positions[0];
            if(counter.count < 4)
                lineRenderer[counter.count].Points = positions.ToArray(); 
        }

        entered = 0;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (!collision.gameObject.GetComponent<DrawLineFences>().connected && dragging)
        {
            pos_connected = collision.gameObject.GetComponent<RectTransform>().parent.InverseTransformPoint(collision.gameObject.transform.position);
            
            fence_connected = collision.gameObject.GetComponent<DrawLineFences>().n_fence;
            collision.gameObject.GetComponent<DrawLineFences>().fence_connected = n_fence;
            entered++;
            collision.gameObject.GetComponent<DrawLineFences>().entered = 0;
            connected_object = collision.gameObject;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (!connected && dragging)
        {
            //collision.gameObject.GetComponent<DrawLineFences>().connected = false;
            entered--;
        }
    }

    public void Reset()
    {
        start_pos = transform.position;
        end_pos = gameObject.GetComponent<RectTransform>().parent.InverseTransformPoint(gameObject.transform.position);
        positions.Add(end_pos);
        positions.Add(end_pos);

        dragging = false;
        connected = false;
        entered = 0;
        count = 0;
        //cunter.count = 0;
        fence_connected = n_fence;
    }

    public void RefreshAnimals()
    {
        GameObject go;

        for(int i = 0; i < 40; i++)
        {
            go = GameObject.Find("Button (" + i.ToString() + ")");
            if (go != null)
            {
                if(go.GetComponent<DrawLineFences>()!=null)
                go.GetComponent<DrawLineFences>().Reset();
            }
        }

        for(int i = 0; i < 4; i++)
        {
            lineRenderer[i].Points = positions.ToArray();
        }
    }


    public void DeleteLastStep()
    {
        
        if (counter.count > 0)
        {
            Vector2 pos = lineRenderer[counter.count - 1].Points[0];
            List<Vector2> resetPos = new List<Vector2>();
            resetPos.Add(gameObject.transform.position);
            resetPos.Add(gameObject.transform.position);
            lineRenderer[counter.count - 1].Points = resetPos.ToArray();

            counter.count--;

            SearchForDisconnect(pos);
        }
    }

    public void SearchForDisconnect(Vector2 pos0)
    {
        int n = 100;
        Vector3 pos = new Vector3(pos0.x, pos0.y, 0);
        foreach(DrawLineFences fence in gameObject.transform.parent.gameObject.GetComponentsInChildren<DrawLineFences>())
        {
            if (fence.connected)
            {
                Debug.Log(fence.gameObject.name);
                Debug.Log(fence.gameObject.GetComponent<RectTransform>().parent.InverseTransformPoint(fence.gameObject.transform.position));
                Debug.Log(pos0);
            }
            if(Mathf.Abs(fence.gameObject.GetComponent<RectTransform>().parent.InverseTransformPoint(fence.gameObject.transform.position).x - pos.x) < 0.1f
                && Mathf.Abs(fence.gameObject.GetComponent<RectTransform>().parent.InverseTransformPoint(fence.gameObject.transform.position).y - pos.y) < 0.1f)
            {
                n = fence.fence_connected;
                fence.Reset();
                
                break;
            }
        }

        foreach (DrawLineFences fence in gameObject.transform.parent.gameObject.GetComponentsInChildren<DrawLineFences>())
        {
            if (fence.n_fence == n)
            {
                fence.Reset();
                Debug.Log("UNLOCKED");
                break;
            }
        }
    }

    public void Disconnect()
    {
        connected = false;
    }
}
