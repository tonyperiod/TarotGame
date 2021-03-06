using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//edited version of cardscriptreference
public class ShopCardScriptReference : MonoBehaviour
{
    [SerializeField] Shop manager;

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
        FirstCard(); // gives variables and instances, this will then reference                                        
    }


    private void FirstCard()
    {
        ScriptableCard s;
        //data
        s = cardData; // I'm setting the card data from the main shop script
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