using UnityEngine.Audio;
using UnityEngine;

//from brackeys tutorial
public class AudioManager : MonoBehaviour
{
    public Sound[] soundsAll;

    public string[] startAudio;//little custom addon to be able to play on start 
    bool isBattle;

    //create all the sound sources
    private void Awake()
    {//attach sound to source
        if (isBattle == false)
        {
            Debug.Log("default audio");
            foreach (Sound s in soundsAll)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
        }
    }

    //for tonycardtesting, added to fix a bug
    public void CustomAwake()
    {//attach sound to source
        isBattle = true;
        foreach (Sound s in soundsAll)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }


    private void Start()
    {
        //here for background music/stuff on start, my addon to the tutorial
        if (startAudio != null)
        {
            for (int i = 0; i < startAudio.Length; i++)
            {
                Play(startAudio[i]);
            }
        }
    }
    //play sound of name 
    public void Play(string name)
    {
        for (int i = 0; i < soundsAll.Length; i++)
        {
            if (soundsAll[i].name == name)
                soundsAll[i].source.Play();
        }
    }
}
