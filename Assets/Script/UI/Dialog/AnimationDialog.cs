using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KingFrog;

/*
 * This script is for animation of a DialogBox
 * it can't work withou Dialog script 
 */

public class AnimationDialog : MonoBehaviour
{
    public CHARACTER character;

    [Space(10)]

    public Sprite[] spritesNow;
    public Sprite[] madalinaSprites;
    public Sprite[] darkKnightSprites;
    public Sprite[] bogSprites;
    public Sprite[] nilSprites;

    public Text nameDialog;

    public Dictionary<CHARACTER, Sprite[]> sprites;
    public Dictionary<CHARACTER, string> namesITA;
    public Dictionary<CHARACTER, string> namesENG;
    public Image portrait;

    //Animation Speed
    public float waitTime;

    //True if couroutine Type() is working on Dialog script
    public bool talking;

    float timer;

    // Start is called before the first frame update
    void Start()
    {

        sprites = new Dictionary<CHARACTER, Sprite[]>
        {
            [CHARACTER.MADALINA] = madalinaSprites,
            [CHARACTER.DARK_KNIGHT] = darkKnightSprites,
            [CHARACTER.BOG] = bogSprites,
            [CHARACTER.NIL] = nilSprites
        };

        namesITA = new Dictionary<CHARACTER, string>
        {
            [CHARACTER.MADALINA] = "Madalina",
            [CHARACTER.DARK_KNIGHT] = "Dark Knight",
            [CHARACTER.BOG] = "Bog",
            [CHARACTER.NIL] = "Nil"
        };

        ChangeCharacter(character);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (talking && timer > waitTime)
        {
            if (portrait.GetComponent<Image>().sprite == spritesNow[0])
            {
                portrait.sprite = spritesNow[1];
            }
            else
            {
                portrait.sprite = spritesNow[0];
            }
            timer = 0.0f;
        }
    }

    public void ChangeCharacter(CHARACTER character)
    {
        this.character = character;
        Debug.Log(character);
        spritesNow = sprites[character];
        nameDialog.text = namesITA[character];
    }

    public void StopTalking()
    {
        talking = false;
        portrait.sprite = spritesNow[0];
    }
}
