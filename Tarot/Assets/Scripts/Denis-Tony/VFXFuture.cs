using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXFuture : MonoBehaviour
{
    //general rules
    //change the naming you want in here
    //DONT modify and values on the referenced components
    //already inserted this into the scene (VFX Handler) with references set up  -------------------------------------

    // the different values that you asked for. The names aren't good, just tried to make them explicative.
    string cardElement;
    int cardValue;
    bool cardIsPlayer;

    //these are directly referenced within the editor
    public Transform PlayerCardPosition;
    public Transform EnemyCardPosition;
    public Transform PlayerSpritePosition;
    public Transform EnemySpritePosition;



    //card = the currently played card
    public void activate(GameObject card) //don't touch the starting line, the rest do what ya want
    {
        //getting the references that are necessary per every card played
        cardElement = card.GetComponent<CardScriptReference>().symbol;
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
