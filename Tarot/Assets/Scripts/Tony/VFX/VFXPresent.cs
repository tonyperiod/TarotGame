using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXPresent : MonoBehaviour
{
    [SerializeField] VFXManager manager;

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
        actualEffectActivation(card);

    }


    private void actualEffectActivation(GameObject card)
    {
        switch (cardElement)
        {
            case "air":

                //shoot to and from correct spot
                if (card.GetComponent<CardScriptReference>().isplayer == true)
                {
                    manager.presentVFX[0].GetComponentInChildren<SpawnMeteor>().startPoint = manager.playerStTransf;
                    manager.presentVFX[0].GetComponentInChildren<SpawnMeteor>().endPoint = manager.enemyEndTransf;
                }
                else
                {
                    manager.presentVFX[0].GetComponentInChildren<SpawnMeteor>().startPoint = manager.enemyStTransf;
                    manager.presentVFX[0].GetComponentInChildren<SpawnMeteor>().endPoint = manager.playerEndTransf;
                }

                manager.presentVFX[0].GetComponentInChildren<SpawnMeteor>().Activate();
                break;

            case "earth":

                if (card.GetComponent<CardScriptReference>().isplayer == true)
                {
                    manager.presentVFX[1].GetComponentInChildren<SpawnMeteor>().startPoint = manager.playerStTransf;
                    manager.presentVFX[1].GetComponentInChildren<SpawnMeteor>().endPoint = manager.enemyEndTransf;
                }
                else
                {
                    manager.presentVFX[1].GetComponentInChildren<SpawnMeteor>().startPoint = manager.enemyStTransf;
                    manager.presentVFX[1].GetComponentInChildren<SpawnMeteor>().endPoint = manager.playerEndTransf;
                }

                manager.presentVFX[1].GetComponentInChildren<SpawnMeteor>().Activate();
                break;

            case "fire":
                if (card.GetComponent<CardScriptReference>().isplayer == true)
                {
                    manager.presentVFX[2].GetComponentInChildren<SpawnMeteor>().startPoint = manager.playerStTransf;
                    manager.presentVFX[2].GetComponentInChildren<SpawnMeteor>().endPoint = manager.enemyEndTransf;
                }
                else
                {
                    manager.presentVFX[2].GetComponentInChildren<SpawnMeteor>().startPoint = manager.enemyStTransf;
                    manager.presentVFX[2].GetComponentInChildren<SpawnMeteor>().endPoint = manager.playerEndTransf;
                }

                manager.presentVFX[2].GetComponentInChildren<SpawnMeteor>().Activate();
                break;

            case "water":
                card.transform.GetChild(4).gameObject.SetActive(true);
                card.GetComponent<CardScriptReference>().visualEffects[1].Play();
                break;
        }
    }


}