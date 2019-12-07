using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DragTorch : MonoBehaviour
{   

    public GameObject counter,Canvas;
    GameObject torch;
    public bool startDragging,disable,delete,endDragging;

    bool catched;

    public float timestamp;

    public AudioSource ignite;

    
    Vector2 start_pos,pos,new_pos_coord;
    // Start is called before the first frame update
    void Start()
    {
        pos.x = -1;
        pos.y = -1;
        startDragging = false;
        disable = false;
        endDragging = false;
        catched = false;
        new_pos_coord = new Vector2(0,0);
        start_pos = new Vector2(0,0);
        timestamp = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(disable && !startDragging && endDragging){
            transform.position = new_pos_coord;
        }  
    }

    public void draggingTorch()
    {
        if(!startDragging){
            startDragging = true;
            endDragging = false;
            if(!disable){
                int counter_num = int.Parse(counter.GetComponent<Text>().text);
                counter_num+=1;
                counter.GetComponent<Text>().text = counter_num.ToString();

                GameObject canvas = GameObject.Find("Canvas/HUD_Enigma/PostDialog");
                torch = GameObject.Instantiate(this.gameObject);
                torch.transform.parent = canvas.transform;
                torch.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                torch.GetComponent<DragTorch>().disable = true;
                torch.GetComponent<Animator>().enabled = false;
                torch.GetComponent<DragTorch>().ignite = ignite;
                torch.tag = "torch";
            }
        }
        else{
            if(!disable){
                torch.transform.position = new Vector3(Input.mousePosition.x,Input.mousePosition.y,0);
                torch.GetComponent<DragTorch>().disable = true;
            }
            else{
                transform.position = new Vector3(Input.mousePosition.x,Input.mousePosition.y,0);           
            }
        }   
    }

    public void dropTorch(){
        startDragging = false;
        if(delete){
            Destroy(this.gameObject);
            int counter_num = int.Parse(counter.GetComponent<Text>().text);
            counter_num-=1;
            counter.GetComponent<Text>().text = counter_num.ToString();
        }
        else if(disable){
            if(new_pos_coord.x != 0 && new_pos_coord.y != 0){
                start_pos = transform.position = new_pos_coord;
                MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.IGNITE, 0);
            }
        }
        else{
            torch.GetComponent<DragTorch>().endDragging = true;
            if(!torch.GetComponent<DragTorch>().catched && start_pos.x == 0 && start_pos.y == 0){
                Destroy(torch);
                int counter_num = int.Parse(counter.GetComponent<Text>().text);
                counter_num-=1;
                counter.GetComponent<Text>().text = counter_num.ToString();
                
            }
            else{
                torch.transform.position = start_pos;
                MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.IGNITE, 0);
            }
        }   

        catched = false;    
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Recycler"){
            delete = true;
        }
        else if(other.gameObject.tag != "torch"){         
            if(other.GetComponent<GridTorch>().torch == 0){
                other.GetComponent<GridTorch>().torch = timestamp;
                new_pos_coord = other.gameObject.transform.position;
                catched = true;
            }   
        }
    }


    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Recycler"){
            delete = false;
        }
        else if (other.gameObject.tag != "torch"){
            if(other.GetComponent<GridTorch>().torch == timestamp){
                other.GetComponent<GridTorch>().torch = 0.0f;
            }
        }
    }


    public void Refresh()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("torch"))
        {
            if (obj.name == "Dragger(Clone)")
            {
                Destroy(obj);
            }
        }

        counter.GetComponent<Text>().text = "0";    
    }
}
