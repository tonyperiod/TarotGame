using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXPastFuture : MonoBehaviour
{
    string cardElement;
    int cardValue;
    bool cardIsPlayer;


    //card = the currently played card
    public void activate(GameObject card)
    {
        //getting the references that are necessary per every card played
        cardElement = card.GetComponent<CardScriptReference>().elem;
        //cardValue = card.GetComponent<CardScriptReference>().value;
        //cardIsPlayer = card.GetComponent<CardScriptReference>().isplayer;

        //activating the script for the actual vfx
        actualEffectActivation();

    }


    private void actualEffectActivation()
    {
        
    }
}
