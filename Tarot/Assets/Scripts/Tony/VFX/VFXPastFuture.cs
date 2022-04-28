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

    private void court(GameObject court)
    {

        //element 1
        court.GetComponent<CardScriptReference>().elem = court.GetComponent<CardScriptReference>().court1;//temp edit to elem
        activate(court);//activate script as usual


        //element 2
        court.GetComponent<CardScriptReference>().elem = court.GetComponent<CardScriptReference>().court2;
        activate(court);//activate script as usual;

        //return stuff to original     
        court.GetComponent<CardScriptReference>().elem = "court";
    }
}
