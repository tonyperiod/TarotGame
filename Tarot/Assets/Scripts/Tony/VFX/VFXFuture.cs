using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom script
//gets triggered from vfx manager
public class VFXFuture : MonoBehaviour
{   
    string cardElement;
    int cardValue;
    bool cardIsPlayer;

    //card = the currently played card
    //split into two to be able to have court cards activate twice
    public void activate(GameObject card) 
    {
        //getting the references that are necessary per every card played
        cardElement = card.GetComponent<CardScriptReference>().elem;
        cardValue = card.GetComponent<CardScriptReference>().value;
        cardIsPlayer = card.GetComponent<CardScriptReference>().isplayer;

        //activating the script for the actual vfx
        actualEffectActivation();
    }


    private void actualEffectActivation()
    {
        //currently no effect
    }
}
