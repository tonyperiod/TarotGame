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
                card.transform.GetChild(0).gameObject.SetActive(true);
                cRef.particleSystems[0].Play();
                break;
            case "earth":
                card.transform.GetChild(1).gameObject.SetActive(true);
                cRef.particleSystems[1].Play();
                break;
            case "fire":
                card.transform.GetChild(2).gameObject.SetActive(true);
                cRef.particleSystems[2].Play();
                break;
            case "water":
                card.transform.GetChild(3).gameObject.SetActive(true);
                cRef.visualEffects[0].Play();
                break;

        }
    }
}