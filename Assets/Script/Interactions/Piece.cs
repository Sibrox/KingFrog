using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piece : MonoBehaviour
{
    public bool isPiece,dragging;
    public int nPiece,offset,offset_x;

    public Piece car;
    public Camera cam;
    public  Vector3 new_pos,start_pos;
    public GameObject canvas;

    public int[,] grid =  new int[,] { 
                                        {0, 0, 0, 0, 0, 0, 0},
                                        {0, 0, 0, 0, 0, 0, 0},
                                        {0, 0, 0, 0, 0, 0, 0},
                                        {0, 0, 0, 0, 0, 0, 0}  
                                    };

   public int[][,] grid_piece = new int[5][,] 
    {
        new int[,] { { 1, 1, 1 },{ 0, 0, 1} },
        new int[,] { { 1, 1, 0, 1, 1 }, { 0, 1, 1, 1, 0} },
        new int[,] { { 0, 1, 0 },{ 1, 1 ,1},{0, 1, 1} }, 
        new int[,] { { 1, 1, 1, 1 }, { 0, 0, 0, 1} }, 
        new int[,] { { 1, 0 , 0, 0, 0},{ 1, 1, 1, 1, 1 } } 
    };

    private int [,] pivots = new int[,] {
                                            {0,1},
                                            {1,2},
                                            {1,1},
                                            {0,2},
                                            {1,2},
                                        };

    private int match;
    public bool attached;
    public int [] pos = new int[2];
    public int [] pos_temp = new int[2];

    public AudioSource mixer;
    
    // Start is called before the first frame update
    void Start()
    {
        dragging = false;
        //new_pos = gameObject.GetComponent<RectTransform>().localPosition;
        new_pos = GetComponent<RectTransform>().localPosition;
        //canvas = GameObject.Find("Canvas");
        match = 0;
        attached = false;

        start_pos = GetComponent<RectTransform>().localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            GetComponent<RectTransform>().SetAsLastSibling();
            Vector2 points = new Vector2();
            RectTransformUtility.ScreenPointToLocalPointInRectangle( canvas.GetComponent<RectTransform>(),Input.mousePosition,cam,out points );
            GetComponent<RectTransform>().localPosition = new Vector3( points.x - offset_x,points.y-offset,0);
        }
    }

    public void OnDrag()
    {
        dragging = true;
        if(attached)
            GoOut();
    }

    public void OnDrop()
    {
        dragging = false;

        if(match > 0 && CheckAndFill(pos_temp[0],pos_temp[1])){
            pos[0] = pos_temp[0];
            pos[1] = pos_temp[1];
            gameObject.GetComponent<RectTransform>().localPosition = new_pos;         
            attached = true;
            MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.FEED_OR_LOCK, 0);
        }
        else if(attached){
            attached = false;
            gameObject.GetComponent<RectTransform>().localPosition = start_pos;       
        }
        else{
            gameObject.GetComponent<RectTransform>().localPosition = start_pos;
        }

        string matrix = "";
        for(int i = 0;i<=grid_piece[nPiece - 1].GetUpperBound(0);i++){
            for(int j = 0;j<=grid_piece[nPiece -1].GetUpperBound(1);j++){
                matrix += grid_piece[nPiece-1][i,j].ToString()+", ";          
            }
            matrix+=" -> ";
        }

        //Debug.Log(matrix);
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Magnetic" && dragging)
        {
            new_pos = other.GetComponent<RectTransform>().localPosition;
            new_pos.x -= offset_x;
            new_pos.y -= offset;

            pos_temp[0] = other.GetComponent<Grid>().pos_i;
            pos_temp[1] = other.GetComponent<Grid>().pos_j;
            match++;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(dragging)
            match--;
    }

    public bool CheckAndFill(int pos_i, int pos_j)
    {

        for(int i = 0; i <= grid_piece[nPiece-1].GetUpperBound(0); i++  ){
            for( int j = 0; j <= grid_piece[nPiece-1].GetUpperBound(1);j++) {
                
                if(
                    (i - pivots[nPiece - 1 , 0] + pos_i >= 0) &&
                    (i - pivots[nPiece - 1 , 0] + pos_i < 4) &&
                    (j - pivots[nPiece - 1 , 1] + pos_j  >= 0) && 
                    (j - pivots[nPiece - 1 , 1] + pos_j < 7))
                    {
                        if( car.grid[i - pivots[nPiece - 1, 0] + pos_i, j - pivots[nPiece - 1, 1] + pos_j] == 1 &&
                            grid_piece[nPiece-1][i,j] == 1 ) {

                                //Debug.Log("FALSE FOR NO SPACE");
                                return false;
                            }
                    }
                else{
                    //Debug.Log("FALSE FOR OUT OF DIMENSIONS");
                    return false;
                }
            }
        }

        for(int i = 0; i <= grid_piece[nPiece-1].GetUpperBound(0); i++  ){
            for( int j = 0; j <= grid_piece[nPiece-1].GetUpperBound(1);j++) {
                    if( grid_piece[nPiece - 1][i,j] == 1 ) 
                        car.grid[i - pivots[nPiece - 1,0] + pos_i, j - pivots[nPiece - 1,1] + pos_j]  = 1;
            }
        }

        return true;
    }

    public void GoOut()
    {
        for(int i = 0; i <= grid_piece[nPiece-1].GetUpperBound(0); i++  ){
            for( int j = 0; j <= grid_piece[nPiece-1].GetUpperBound(1);j++) {
                    if( grid_piece[nPiece-1][i,j] == 1 ) 
                        car.grid[i - pivots[nPiece - 1, 0] + pos[0], j - pivots[nPiece - 1, 1] + pos[1]]  = 0;
            }
        }
    }

}
