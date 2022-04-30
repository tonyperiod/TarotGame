using UnityEngine.Audio;
using UnityEngine;

//from brackeys tutorial!!
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public float volume = 1;
    public float pitch = 1;
    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
