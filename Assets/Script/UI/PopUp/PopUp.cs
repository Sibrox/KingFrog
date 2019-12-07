using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{

    public GameObject opacity;
    public Animation animation;


    /* start is a state variable:
     * 0 -> first popup
     * 1 -> bigger
     * 2 -> smaller
     * 3 -> right dimension and so END
     * */
    public int start;
    // Start is called before the first frame update
    void Start()
    {
        start = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void show()
    {
        this.gameObject.SetActive(true);
        opacity.SetActive(true);

        animation["Show"].wrapMode = WrapMode.Once;
        animation.Play("Show");
    }

    public void vanish()
    {
        this.gameObject.SetActive(false);
        opacity.SetActive(false);
        start = 0;
        GameObject.Find("Left Frame").GetComponent<LeftFrame>().Restore();
    }
}
