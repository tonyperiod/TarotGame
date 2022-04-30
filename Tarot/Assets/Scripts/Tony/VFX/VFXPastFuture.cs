using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom script
//gets triggered from vfx manager
public class VFXPastFuture : MonoBehaviour
{
    string cardElement;
    int cardValue;
    bool cardIsPlayer;

    [SerializeField] VFXManager manager;

    public Transform airP;
    public Transform airE;

    //card = the currently played card
    //split into two to be able to have court cards activate twice
    public void activate(GameObject card)
    {
        //getting the references that are necessary per every card played
        cardElement = card.GetComponent<CardScriptReference>().elem;
        //cardValue = card.GetComponent<CardScriptReference>().value;
        //cardIsPlayer = card.GetComponent<CardScriptReference>().isplayer;

        //activating the script for the actual vfx
        actualEffectActivation(card);

    }


    private void actualEffectActivation(GameObject card)
    {
        Vector3 spawnLoc;
        GameObject objVFX;
        switch (cardElement)
        {
           
            case "air":
                //shoot to and from correct spot. custom spots for air different from meteors
                if (card.GetComponent<CardScriptReference>().isplayer == true)
                {
                    spawnLoc = airE.position;
                }
                else
                {
                    spawnLoc = airP.position;
                }
                objVFX = Instantiate(manager.pastFutureVFX[0], spawnLoc, Quaternion.identity) as GameObject;

                break;

            case "earth":
                //effect on the prefab
                card.transform.GetChild(6).gameObject.SetActive(true);
                break;

            case "fire":
                if (card.GetComponent<CardScriptReference>().isplayer == true)
                {
                    spawnLoc = manager.enemyEndTransf.position;
                }
                else
                {
                    spawnLoc = manager.playerEndTransf.position;
                }
                //effect prefab on the script
                objVFX = Instantiate(manager.pastFutureVFX[1], spawnLoc, Quaternion.identity) as GameObject;
                break;

            case "water":
                //effect on the card prefab
                card.transform.GetChild(7).gameObject.SetActive(true);
                break;    

            case "court":
                court(card);
                break;
        }
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