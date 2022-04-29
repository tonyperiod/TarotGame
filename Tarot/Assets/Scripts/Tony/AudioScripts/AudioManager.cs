using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] soundsAll;

    //create all the sound sources
    private void Awake()
    {//attach sound to source
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
        //here for background music/stuff on start
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
