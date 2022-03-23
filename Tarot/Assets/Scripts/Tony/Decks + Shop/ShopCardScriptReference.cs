using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopCardScriptReference : MonoBehaviour
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

    private SpriteRenderer spRend;



    private void Start()
    {
        /*FirstCard(Shop.PickCard());*/ //playeringamedeck.pick card gives variables and instances, this will then reference
    }


    private void FirstCard(ScriptableCard s)
    {
        //data
        spRend = GetComponent<SpriteRenderer>();
        spRend.sprite = s.artWork;
        Cardname = s.Cardname;
        id = s.id;
        elem = s.elem;
        value = s.value;
        isplayer = true;

        court1 = s.court1;
        court2 = s.court2;

        goldVal = s.goldVal;
    }

}
