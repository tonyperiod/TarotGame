using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public AudioSource buttonClick;
    public AudioSource playClick;



    public void ButtonClickSound()
    {
        buttonClick.Play();
    }

    public void PlayButtonClickSound()
    {
        playClick.Play();
    }

}
