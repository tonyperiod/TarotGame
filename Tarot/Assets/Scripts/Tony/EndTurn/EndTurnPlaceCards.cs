using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom script for card placement
public class EndTurnPlaceCards : MonoBehaviour
{
    [SerializeField] EndTurn manager;
    ScriptableCard thisCard;

    public void place()
    {
        CardScriptReference cardReference = manager.cardPrefab.GetComponent<CardScriptReference>();//for simplicity in the code

        manager.cardPrefab.tag = "Card"; // set to card so that the instances get this tag
        manager.audioManager.Play("three cards placed");//playing at start, better game feel

        for (int i = 0; i < 6; i++)
        {
            //get data from here
            if (i < 3)//player cards
            {
                cardReference.isplayer = true;
                thisCard = PlayerInGameDeck.PickCard();
            }
            else//enemy cards
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

            //just to make sure it doesn't carry over to next for loop
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
            manager.playerMajorActivation = manager.playerMajorActivationMax; //it prevents multiple major arcanas to be placed in a row. Useful for later on in the game
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

        //deactivate draggable, to prevent bug on players trying to move the card
        manager.cardPrefab.GetComponent<Draggable>().enabled = false;

        //delete the dummy in place
        manager.MajorDummy.Delete(slot);

        //finally instantiate
        Instantiate(manager.cardPrefab, manager.pos[slot].transform.position, manager.pos[slot].transform.rotation);

        //change the card back to something else, so that all 3 slots are filled
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