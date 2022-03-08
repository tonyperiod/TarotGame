using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardScriptReference : MonoBehaviour
{
    public ScriptableCard cardData;

    public string Cardname;
    public Sprite artWork;
    public int id;
    public string symbol;
    public int value;
    public int slot;
    public bool isplayer;

    public string court1;
    public string court2;


    private SpriteRenderer spRend;


    private void Start()
    {
        //choice between is player and is enemy
        if (isplayer == true)
            FirstCard(PlayerInGameDeck.PickCard()); //it's ok to use random as long as the value is removed
        else
            EnFirstCard(EnemyInGameDeck.PickCard());



    }

    private void FirstCard(ScriptableCard s)
    {
        //data
        spRend = GetComponent<SpriteRenderer>();
        spRend.sprite = s.artWork;
        Cardname = s.Cardname;
        id = s.id;
        symbol = s.symbol;
        value = s.value;
        isplayer = true;

        court1 = s.court1;
        court2 = s.court2;

    }

    private void EnFirstCard(ScriptableCard e)
    {
        //data
        spRend = GetComponent<SpriteRenderer>();
        spRend.sprite = e.artWork;
        Cardname = e.Cardname;
        id = e.id;
        symbol = e.symbol;
        value = e.value;
        isplayer = false;

        court1 = e.court1;
        court2 = e.court2;

    }
}