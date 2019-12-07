using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_car : MonoBehaviour
{
    /* The route is 
        (0,0) (1,0) (2,0) (3,0) (4,0)
                        (0,1)
            (0,2) (1,2) (2,2) (3,2) (4,2) (5,2)  
    */

    public GameObject[] cars = new GameObject[7];
    public Vector2 pos;

    public Vector2 new_pos_coord,new_pos_coord_tmp,new_pos_tmp,new_pos;
    public Vector3 start_pos,mousePosition_drag;

    public bool start_dragging,stop,car;


    Vector2 initPos, initPosGrid;

    /* 
     * 0 -> NO MOVING
     * 1 -> HORIZONTAL
     * 2 -> UP
     * 3 -> DOWN
     */
    public int direction;

    bool started;

    void Start()
    {
        //Debug.Log("Collision Enter");
        initPos = new_pos = start_pos = GetComponent<RectTransform>().localPosition;
        start_dragging = false;
        stop = false;
        initPosGrid = new_pos = pos;

        direction = 0;
        ResetCar();
    }

    public void ResetStart()
    {
        GetComponent<RectTransform>().localPosition = initPos;
        pos = initPosGrid;
        ResetCar();
    }

    void Update()
    {
        float diffX, diffY;
        diffX = Input.mousePosition.x - mousePosition_drag.x;
        diffY = Input.mousePosition.y - mousePosition_drag.y;

        if (!stop && start_dragging && car){
            //MOVE HORIZONTAL
            if( Mathf.Abs(diffX) - Mathf.Abs(diffY) >= 0 ) {

                    if (pos.y == 0 && new_pos.y !=1 && ( Mathf.Abs(pos.y - new_pos.y) < 2) )
                    {
                        if (GetComponent<RectTransform>().localPosition.x >= -222
                            && GetComponent<RectTransform>().localPosition.x <= -33)

                        GetComponent<RectTransform>().Translate(new Vector3( diffX * Time.deltaTime * 0.02f, 0, 0));
                    }

                    else if (pos.y == 2 && new_pos.y !=1 && ( Mathf.Abs(pos.y - new_pos.y) < 2) )
                    {
                        if (GetComponent<RectTransform>().localPosition.x <= 68
                            && GetComponent<RectTransform>().localPosition.x >= -130)

                        GetComponent<RectTransform>().Translate(new Vector3(diffX * Time.deltaTime * 0.02f, 0, 0));
                    }
            }
            //MOVE VERTICAL
            else {
                    if (pos.x == 3 && new_pos.x == 3)
                    {
                        if (GetComponent<RectTransform>().localPosition.y >= -80.5
                            && GetComponent<RectTransform>().localPosition.y <= 78)
                        GetComponent<RectTransform>().Translate(new Vector3(0, diffY * Time.deltaTime * 0.02f, 0));
                    }
            }
        }
    }


    public void movingCar(){

        if(!start_dragging){
            mousePosition_drag = Input.mousePosition;
            start_dragging = true;
            stop = false;
        } 
    }

    public void onDrop(){ 

        if(!findCar()){
            pos = new_pos;
            GetComponent<RectTransform>().localPosition = new_pos_coord;
            MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.IRON_WHEEL, 0);
        }
        else{
            GetComponent<RectTransform>().localPosition = start_pos;
        }

        start_pos = GetComponent<RectTransform>().localPosition;
        start_dragging = false;
        stop = false;
    }


    void OnTriggerStay2D(Collider2D col)
    {
        if (col.GetComponent<moving_car>().pos != pos)
        {

            if (col.tag == "car") stop = true;
            if (car)
            {
                new_pos_coord_tmp = new_pos_coord;
                new_pos_coord = col.gameObject.GetComponent<RectTransform>().localPosition;
                new_pos_tmp = new_pos;
                new_pos = col.gameObject.GetComponent<moving_car>().pos;
                if (findCar())
                {
                    new_pos = new_pos_tmp;
                    new_pos_coord = new_pos_coord_tmp;
                }
            }
        }
    }


    bool findCar()
    {
        foreach (GameObject c in cars)
        {
            if (c.GetComponent<moving_car>().pos.x == new_pos.x
                && c.GetComponent<moving_car>().pos.y == new_pos.y)
                return true;
        }
        return false;
    }

    public void ResetCar()
    {
        new_pos = pos;
        start_pos = new_pos_coord = GetComponent<RectTransform>().localPosition;
        stop = false;
    }

}
