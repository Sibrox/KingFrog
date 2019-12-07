using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSpada : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        SetBoolAnimation();

    }

    // Update is called once per frame
    void Update()
    {
    
    }

public void SetBoolAnimation(){

  if(GameManager.instance.lastSolved == 15){
      anim.SetBool("IsCavaliereNero", true);
      MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.UNLOCK, 1.0f);
  }  
  else{
      this.gameObject.SetActive(false);
  } 
}
}
