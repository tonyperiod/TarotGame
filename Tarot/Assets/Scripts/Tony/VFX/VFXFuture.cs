using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXFuture : MonoBehaviour
{   
    string cardElement;
    int cardValue;
    bool cardIsPlayer;

    public void activate(GameObject card) 
    {
        //getting the references that are necessary per every card played
        cardElement = card.GetComponent<CardScriptReference>().elem;
        cardValue = card.GetComponent<CardScriptReference>().value;
        cardIsPlayer = card.GetComponent<CardScriptReference>().isplayer;

        //activating the script for the actual vfx
        actualEffectActivation();

    }


    private void actualEffectActivation()//put what ya want in here, I'd suggest to look at how I did the actual past, present... scripts
    {

        //if you could insert a delay even when there is no effect that would be good, just to separate out things a sec.
    }
}
