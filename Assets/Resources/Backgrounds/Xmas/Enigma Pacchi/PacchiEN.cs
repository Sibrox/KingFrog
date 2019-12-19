using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KingFrog;

public class NewBehaviourScript : MonoBehaviour
{
    public Image paccoVero, paccoFalso;
    public Sprite [] pacco; //pacco Blu-Blu, Blu-Rosso, Blu-Verde, Rosso-Blu, Rosso-Rosso, Rosso-Verde, Verde-Blu, Verde-Rosso, Verde-Verde
    public bool editableVero, editableFalso, powered;
    public Drawer drawer;
    public COLOR colorePacco;
    public GameObject paccoVeroGM;
    

    void Start()
    {
        editableVero = false;
        editableFalso = false;
        powered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!powered && (SystemInfo.batteryStatus == BatteryStatus.Charging || SystemInfo.batteryStatus == BatteryStatus.Full || SystemInfo.batteryStatus == BatteryStatus.NotCharging))
        {
            powered = true;

        }

    
        if (){    //Si trova in quella posizione

            editableVero = true;

        if(Input.gyro.x >= 120 && Input.gyro.x <= 180)
        {
            paccoVeroGM.SetActive(true);
        }
    
        
        if(editableVero && drawer.blue){

            if(colore == COLOR.BLUE){
                paccoVero.sprite = pacco[0]:
            }
            if(colore == COLOR.RED){
                paccoVero.sprite = pacco[1];                
            }
            else{
                PaccoVero.sprite = Pacco[2];
            }
            
        }
        if(editableFalse && drawer.blue){
            
            if(colore == COLOR.BLUE){
                paccoFalso.sprite = pacco[0]:
            }
            if(colore == COLOR.RED){
                paccoFalso.sprite = pacco[1];                
            }
            else{
                paccoFalso.sprite = pacco[2];
            }

            
        }

        }
    
}
}
