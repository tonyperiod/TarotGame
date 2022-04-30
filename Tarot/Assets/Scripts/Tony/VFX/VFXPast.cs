using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

//custom script
//gets triggered from vfx manager
public class VFXPast : MonoBehaviour
{
    string cardElement;
    int cardValue;
    bool cardIsPlayer;
    Transform location;

    CardScriptReference cRef;

    //card = the currently played card
    //split into two to be able to have court cards activate twice    
    public void activate(GameObject card)
    {
        //getting the references that are necessary per every card played
        cRef = card.GetComponent<CardScriptReference>();
        cardElement = cRef.elem;
        //cardValue = card.GetComponent<CardScriptReference>().value; //in case we need it

        //activating the script for the actual vfx
        actualEffectActivation(card);

    }


    private void actualEffectActivation(GameObject card)
    {
        switch (cardElement)
        {
            //all effects are already placed on the card prefab
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
            case "court":
                court(card);
                break;

        }
    }

    //both effects play at once
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
