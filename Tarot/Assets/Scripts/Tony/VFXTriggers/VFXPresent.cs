using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXPresent : MonoBehaviour
{
    string cardElement;
    int cardValue;
    bool cardIsPlayer;

    //card = the currently played card
    public void activate(GameObject card) //don't touch the starting line, the rest do what ya want
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
