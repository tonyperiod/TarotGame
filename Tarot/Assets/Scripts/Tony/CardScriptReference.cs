using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardScriptReference : MonoBehaviour
{
    public ScriptableCard cardData;

    private string Cardname;
    private Sprite artWork;    
    private int id;
    private string symbol;
    private int value;

    private SpriteRenderer spRend;



    private void Start()
    {
        //sprite
        spRend = GetComponent<SpriteRenderer>();
        spRend.sprite = artWork;

        //data
        Cardname = cardData.Cardname;
        Debug.Log(Cardname);
    }
}
