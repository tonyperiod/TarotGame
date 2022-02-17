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

    private SpriteRenderer spRend;



    private void Start()
    {
        FirstCard(PlayerDatabase.GetRandomCard());//now make this the first one
               
               
       
    }

    private void FirstCard(ScriptableCard s)
    {
        //data
        spRend = GetComponent<SpriteRenderer>();
        spRend.sprite = s.artWork;                
        Cardname = cardData.Cardname;
        id = cardData.id;
        symbol = cardData.symbol;
        value = cardData.value;
    }


}
