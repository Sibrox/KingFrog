using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerAudio : MonoBehaviour
{

    public static MixerAudio instance;
    [Space(10)]
    public AudioMixer mixer;
    [Space(2)]
    public AudioSource musicSource;
    public AudioSource effectsSource;
    
    [Space(10)]

    public bool EFFECTS;
    public AudioClip money, click, feedOrLock, ignite, gold, laugh, ironWheel, magic, unlock, click2, click2in, click2out, bip, corrente;
    [Space(10)]
    public bool SONGS;
    public AudioClip startSong, enigmaSong, solutionSong, menuSong,trasformationSong,darkSong,bogNil;

    SONG_TYPE songNow;

    public enum EFFECTS_TYPE{
        MONEY,
        CLICK,
        FEED_OR_LOCK,
        IGNITE,
        GOLD,
        LAUGH,
        IRON_WHEEL,
        MAGIC,
        UNLOCK,
        CLICK2,
        CLICK2IN,
        CLICK2OUT,
        BIP,
        CORRENTE
    }

    public enum SONG_TYPE
    {
        MAIN,
        ENIGMA,
        SOLUTION,
        MENU,
        TRANSFORMATION,
        DARK_KNIGHT,
        BOG_NIL
    }


    private void Awake()
    {
        IsSingleton();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetMusicLevel(float level)
    {
        mixer.SetFloat("Music", level);
    }

    public void SetEffectsLevel(float level)
    {
        mixer.SetFloat("Effects", level);
    }

    IEnumerator SongTransiction(AudioClip clip, float waitTime)
    {
        musicSource.Stop();
        yield return new WaitForSeconds(waitTime);
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void ChangeSong(MixerAudio.SONG_TYPE type, float waitTime)
    {
        AudioClip clip;
        switch (type)
        {
            case SONG_TYPE.MAIN:
                clip = startSong;               
                break;
            case SONG_TYPE.ENIGMA:
                clip = enigmaSong;
                break;
            case SONG_TYPE.SOLUTION:
                clip = solutionSong;
                break;
            case SONG_TYPE.MENU:
                clip = menuSong;
                break;
            case SONG_TYPE.TRANSFORMATION:
                clip = trasformationSong;
                break;
            case SONG_TYPE.DARK_KNIGHT:
                clip = darkSong;
                break;
            case SONG_TYPE.BOG_NIL:
                clip = bogNil;
                break;
            default:
                clip = startSong;
                break;
        }

        if (songNow == type && type == SONG_TYPE.MAIN) return;

        songNow = type;
        StartCoroutine(SongTransiction(clip, waitTime));
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    IEnumerator TransictionEffects(AudioClip clip, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        effectsSource.clip = clip;
        effectsSource.Play();
    }

    public void PlayEffects(MixerAudio.EFFECTS_TYPE type, float waitTime)
    {
        AudioClip clip = money;
        switch (type)
        {
            case EFFECTS_TYPE.MONEY:
                clip = money;
                break;
            case EFFECTS_TYPE.IGNITE:
                clip = ignite;
                break;
            case EFFECTS_TYPE.FEED_OR_LOCK:
                clip = feedOrLock;
                break;
            case EFFECTS_TYPE.CLICK:
                clip = click;
                break;
            case EFFECTS_TYPE.GOLD:
                clip = gold;
                break;
            case EFFECTS_TYPE.LAUGH:
                clip = laugh;
                break;
            case EFFECTS_TYPE.IRON_WHEEL:
                clip = ironWheel;
                break;
            case EFFECTS_TYPE.MAGIC:
                clip = magic;
                break;
            case EFFECTS_TYPE.UNLOCK:
                clip = unlock;
                break;
            case EFFECTS_TYPE.CLICK2:
                clip = click2;
                break;
             case EFFECTS_TYPE.CLICK2IN:
                clip = click2in;
                break;
             case EFFECTS_TYPE.CLICK2OUT:
                clip = click2out;
                break;
            case EFFECTS_TYPE.BIP:
                clip = bip;
                break;
            case EFFECTS_TYPE.CORRENTE:
                clip = corrente;
                break;
        }
        StartCoroutine(TransictionEffects(clip, waitTime));

    }

    private void IsSingleton()
    {
        if (instance != null){
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
