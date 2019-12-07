using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{

    public int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void upCounter()
    {
        if(count  == 9) count = 0;
        else count++;

        this.gameObject.GetComponent<Text>().text = count.ToString();     
    }

    public void downCounter()
    {
        if(count  == 0) count = 9;
        else count--;

        this.gameObject.GetComponent<Text>().text = count.ToString();    
    }
}
