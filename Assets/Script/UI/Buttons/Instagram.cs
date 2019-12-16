using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instagram : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenInstagram()
    {
        Application.OpenURL("https://www.instagram.com/sibroxcompany/");
    }

    public void OpenFacebook()
    {
        Application.OpenURL("https://www.facebook.com/Sibrox-Co-101061278057087/");
    }

}
