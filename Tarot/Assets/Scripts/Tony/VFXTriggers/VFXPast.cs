using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXPast : MonoBehaviour
{
    string cardElement;
    int cardValue;
    bool cardIsPlayer;
    Transform location;

    CardScriptReference cRef;

    
    public void activate(GameObject card)
    {
        //getting the references that are necessary per every card played
        cRef = card.GetComponent<CardScriptReference>();
        cardElement = cRef.elem;
        //cardValue = card.GetComponent<CardScriptReference>().value;
        //cardIsPlayer = card.GetComponent<CardScriptReference>().isplayer;
        //activating the script for the actual vfx
        actualEffectActivation(card);

    }


    private void actualEffectActivation(GameObject card)
    {
        switch (cardElement)
        {
            case "air":
                cRef.particleSystems[0].Play();
                break;
            case "earth":
                cRef.particleSystems[1].Play();
                break;
            case "fire":
                cRef.particleSystems[2].Play();
                break;
            case "water":
                cRef.visualEffects[0].Play();
                break;

        }
    }
}
