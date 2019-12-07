using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class LineDrawer : MonoBehaviour
{

    public bool dragging,end,enter,stop;
    public List<Vector2> positions,grid;
    public List<Vector2> real_positions;
    public List<Vector2> positions_zero;
    public UILineRenderer UILineRenderer;
    public AudioSource trigger;

    public string tag_end;
    public string tag_connected;

    public bool canRefresh;
    


    // Start is called before the first frame update
    void Start()
    {
        dragging = false;
        end = false;

        positions = new List<Vector2>();
        positions_zero = new List<Vector2>();
        real_positions = new List<Vector2>();

        tag_connected = "Gennariello";        

        positions.Add(this.gameObject.GetComponent<RectTransform>().parent.InverseTransformPoint(this.gameObject.transform.position));
        positions.Add(this.gameObject.GetComponent<RectTransform>().parent.InverseTransformPoint(this.gameObject.transform.position));
        real_positions.Add(this.gameObject.GetComponent<RectTransform>().parent.InverseTransformPoint(this.gameObject.transform.position));

        positions_zero.Add(this.gameObject.transform.localPosition);
        positions_zero.Add(this.gameObject.transform.localPosition);

        grid = new List<Vector2>();
        grid.Add(new Vector2(this.gameObject.GetComponent<Grid>().pos_i, this.gameObject.GetComponent<Grid>().pos_j));
    }

    // Update is called once per frame
    void Update()
    {      
        if(positions != null)
            UILineRenderer.Points = positions.ToArray();
    }

    public void onDrag()
    {
        if (!end)
        {
            dragging = true; 
        }
        if(!stop)
            transform.position = Input.mousePosition;
    }

    public void onDrop()
    {
        dragging = false;
        transform.localPosition = positions_zero[0];

        if (!end){
            Reset();
            canRefresh = false;
        }    
        else
        {
            stop = true;
            trigger.Play();
            StartCoroutine(Wait());
        }
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        canRefresh = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 newGrid = new Vector2(other.gameObject.GetComponent<Grid>().pos_i, other.gameObject.GetComponent<Grid>().pos_j);
        Vector2 newPos = other.gameObject.GetComponent<RectTransform>().parent.InverseTransformPoint(other.gameObject.transform.position);
        if (
                    (
                        Mathf.Abs(other.gameObject.GetComponent<Grid>().pos_i - grid[grid.Count - 1].x) == 1
                        &&
                        Mathf.Abs(other.gameObject.GetComponent<Grid>().pos_j - grid[grid.Count - 1].y) == 0
                     )

                ||

                     (
                        Mathf.Abs(other.gameObject.GetComponent<Grid>().pos_i - grid[grid.Count - 1].x) == 0
                        &&
                        Mathf.Abs(grid[grid.Count - 1].y - other.gameObject.GetComponent<Grid>().pos_j) == 1
                     )

                 ||

                     (
                        Mathf.Abs(other.gameObject.GetComponent<Grid>().pos_i - grid[grid.Count - 1].x) == 0
                        &&
                        Mathf.Abs(grid[grid.Count - 1].y - other.gameObject.GetComponent<Grid>().pos_j) == 0
                     )
            )
        {
            if (other.gameObject.tag == "Magnetic" && dragging && !checkGrid(newGrid) && !end)
            {

                positions.Add(newPos);

                grid.Add(new Vector2(other.gameObject.GetComponent<Grid>().pos_i, other.gameObject.GetComponent<Grid>().pos_j));
                real_positions.Add(other.gameObject.transform.position);
                foreach(Vector2 v in grid)
                {
                    Debug.Log("pos: " + v.x + ", "+ v.y);
                }
            }
             
            if (other.gameObject.tag != "Magnetic")
            {
                if (other.gameObject.tag == tag_end)
                {
                    tag_connected = other.gameObject.tag;
                    positions.Add(newPos);

                    grid.Add(new Vector2(other.gameObject.GetComponent<Grid>().pos_i, other.gameObject.GetComponent<Grid>().pos_j));

                    real_positions.Add(other.gameObject.transform.position);
                    end = true;
                }            
                
                canRefresh = false;
                dragging = false;
            }
        }
    }

    bool checkGrid( Vector2 newGrid)
    {
        foreach (Vector2 v in grid){
            if (v.x == newGrid.x && v.y == newGrid.y) return true;
        }

        Debug.Log(newGrid+" "+grid[grid.Count - 1]);
        if (grid[grid.Count - 1].x == 1 && grid[grid.Count - 1].y == 2 && newGrid.x == 2) return true;
        if (grid[grid.Count - 1].x == 2 && grid[grid.Count - 1].y == 2 && newGrid.x == 1) return true;

        return false;
    }

    public void Reset()
    {
            dragging = false;
            end = false;
            stop = false;

            positions = new List<Vector2>();
            positions_zero = new List<Vector2>();
            real_positions = new List<Vector2>();


            positions.Add(this.gameObject.GetComponent<RectTransform>().parent.InverseTransformPoint(this.gameObject.transform.position));
            real_positions.Add(this.gameObject.GetComponent<RectTransform>().parent.InverseTransformPoint(this.gameObject.transform.position));

            positions_zero.Add(this.gameObject.transform.localPosition);
            positions_zero.Add(this.gameObject.transform.localPosition);

            grid = new List<Vector2>();
            grid.Add(new Vector2(this.gameObject.GetComponent<Grid>().pos_i, this.gameObject.GetComponent<Grid>().pos_j));
    }

    public void ResetOnClick()
    {
        if (canRefresh)
        {
            dragging = false;
            end = false;
            stop = false;

            positions = new List<Vector2>();
            positions_zero = new List<Vector2>();
            real_positions = new List<Vector2>();


            positions.Add(this.gameObject.GetComponent<RectTransform>().parent.InverseTransformPoint(this.gameObject.transform.position));
            real_positions.Add(this.gameObject.GetComponent<RectTransform>().parent.InverseTransformPoint(this.gameObject.transform.position));

            positions_zero.Add(this.gameObject.transform.localPosition);
            positions_zero.Add(this.gameObject.transform.localPosition);

            grid = new List<Vector2>();
            grid.Add(new Vector2(this.gameObject.GetComponent<Grid>().pos_i, this.gameObject.GetComponent<Grid>().pos_j));
            canRefresh = false;
        }
    }

}
