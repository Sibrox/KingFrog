using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftFrame : MonoBehaviour
{
    public int index;
    public GameObject opacity;
    public HudEnigma hud;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickButtons()
    {
        opacity.SetActive(true);
    }

    public void Restore()
    {
        opacity.SetActive(false);
    }

    public void SetActive()
    {
        this.gameObject.SetActive(true);
    }

    public void ShowEnigma()
    {
        hud.Show(HudEnigma.TYPE.SHOW);
    }

    public void ShowHints()
    {
        if (hud != null)
        {
            hud.Show(HudEnigma.TYPE.HINTS);
        }
    }


    public void ShowDrawPopUp()
    {
        hud.Show(HudEnigma.TYPE.DRAW_POPUP);
    }
}
