using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class CardScriptReference : MonoBehaviour
{
    public ScriptableCard cardData;

    public string Cardname;
    public Sprite artWork;
    public int id;
    public string elem;
    public int value;
    public int slot;
    public bool isplayer;

    public string court1;
    public string court2;

    public int goldVal;

    public SpriteRenderer spRend;

    public bool isCourt;

    //vfx
    public VisualEffect[] visualEffects;
    public ParticleSystem[] particleSystems;

    private void Start()
    {
        //they get data from placecards

        spRend = GetComponent<SpriteRenderer>();
        spRend.sprite = cardData.artWork;
        Cardname = cardData.Cardname;
        id = cardData.id;
        elem = cardData.elem;
        value = cardData.value;

        court1 = cardData.court1;
        court2 = cardData.court2;

        artWork = cardData.artWork;
    }

}