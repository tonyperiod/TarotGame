using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCards : MonoBehaviour
{
    //refer to parent manager script
    [SerializeField] EndTurnManager manager;

    public void yes()
    {
        CardScriptReference cardReference = manager.cardReference;
        GameObject cardPrefab = manager.cardPrefab;
        GameObject[] pos = manager.pos;

        //setup        
        cardReference = cardPrefab.GetComponent<CardScriptReference>();

        cardPrefab.tag = "Card"; // set to card so that the instances get this tag

        //for loop to place in the 6 slots
        for (int i = 0; i < 6; i++)
        {
            // set card ref to know if it enemy or player
            if (i < 3)
                cardReference.isplayer = true;
            else
                cardReference.isplayer = false;

            //connect local change to global
            cardReference.isplayer = cardPrefab.GetComponent<CardScriptReference>().isplayer;
            cardPrefab.GetComponent<CardScriptReference>().slot = i;

            //finally instantiate
            Instantiate(cardPrefab, pos[i].transform.position, pos[i].transform.rotation);
        }
        cardPrefab.tag = "Untagged"; //reset to untagged so the script doesn't delete it
    }
}
