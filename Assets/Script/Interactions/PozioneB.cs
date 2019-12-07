using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PozioneB : MonoBehaviour
{
   public GameObject background;
   public GameObject pop_up;
   public GameObject testo;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void onClick( ){
        background.GetComponent<WrongAndGood>().correctAnswer = true;
        testo.GetComponent<Text>().text = this.gameObject.name;
        pop_up.SetActive(true);
    }
}