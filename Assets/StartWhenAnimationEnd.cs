using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartWhenAnimationEnd : MonoBehaviour
{

    public Image spriteNow;
    public Sprite spriteEnd;

    public GameObject dialog;

    public bool started;
    // Start is called before the first frame update
    void Start()
    {
        MixerAudio.instance.PlayEffects(MixerAudio.EFFECTS_TYPE.MAGIC, 0);
        MixerAudio.instance.ChangeSong(MixerAudio.SONG_TYPE.TRANSFORMATION, 1);
    }

    IEnumerator Wait()
    {

        yield return new WaitForSeconds(0.3f);
        dialog.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!started && spriteNow.sprite == spriteEnd)
        {
            StartCoroutine(Wait());
            started = true;
        }
    }
}
