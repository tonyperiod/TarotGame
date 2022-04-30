using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnPlaceCards : MonoBehaviour
{
    [SerializeField] EndTurn manager;
    ScriptableCard thisCard;

    public void place()
    {
        CardScriptReference cardReference = manager.cardPrefab.GetComponent<CardScriptReference>();

        manager.cardPrefab.tag = "Card"; // set to card so that the instances get this tag
        manager.audioManager.Play("three cards placed");//playing at start, better game feel

        for (int i = 0; i < 6; i++)
        {
            //get data from here
            if (i < 3)
            {
                cardReference.isplayer = true;
                thisCard = PlayerInGameDeck.PickCard();

            }
            else
            {
                cardReference.isplayer = false;
                thisCard = EnemyInGameDeck.PickCard();
            }

            //connect local change to global, before checking to maintain data on card
            cardReference.isplayer = manager.cardPrefab.GetComponent<CardScriptReference>().isplayer;

            //checking for major arcana
            if (thisCard.court1 == "major")
            {
                ItMajor(cardReference.isplayer);
            }

            //connect local change to global
            manager.cardPrefab.GetComponent<CardScriptReference>().cardData = thisCard;
            manager.cardPrefab.GetComponent<CardScriptReference>().slot = i;

            //finally instantiate
            Instantiate(manager.cardPrefab, manager.pos[i].transform.position, manager.pos[i].transform.rotation);

            //just to make sure it doesn't carry over
            thisCard = null;
        }

        manager.cardPrefab.tag = "Untagged";

    }


    //this runs then substitutes itself for the rest
    void ItMajor(bool isPlayer)
    {

        int slot;
        CardScriptReference cardReference = manager.cardPrefab.GetComponent<CardScriptReference>();

        if (isPlayer == true)
        {
            slot = 8;
            manager.playerMajorActivation = manager.playerMajorActivationMax; //stop major arcana spam
        }
        else
        {
            slot = 10;
            manager.enemyMajorActivation = manager.playerMajorActivationMax;
        }

        //connect local change to global
        manager.cardPrefab.GetComponent<CardScriptReference>().cardData = thisCard;
        manager.cardPrefab.GetComponent<CardScriptReference>().slot = slot;
        manager.cardPrefab.GetComponent<CardScriptReference>().isplayer = isPlayer;

        //deactivate draggable
        manager.cardPrefab.GetComponent<Draggable>().enabled = false;

        //delete the dummy
        manager.MajorDummy.Delete(slot);

        //finally instantiate
        Instantiate(manager.cardPrefab, manager.pos[slot].transform.position, manager.pos[slot].transform.rotation);

        //change the card back to something else
        manager.cardPrefab.GetComponent<Draggable>().enabled = true;
        if (isPlayer == true)
        {
            thisCard = PlayerInGameDeck.PickCard();
        }
        else
        {
            thisCard = EnemyInGameDeck.PickCard();
        }

    }
}
