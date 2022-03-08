using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnPlaceCards : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    public void place()
    {
        CardScriptReference cardReference = manager.cardPrefab.GetComponent<CardScriptReference>();

        manager.cardPrefab.tag = "Card"; // set to card so that the instances get this tag

        for (int i = 0; i < 6; i++)
        {
            // get card ref to know if it enemy or player
            if (i < 3)
                cardReference.isplayer = true;
            else
                cardReference.isplayer = false;

            //connect local change to global
            cardReference.isplayer = manager.cardPrefab.GetComponent<CardScriptReference>().isplayer;
            manager.cardPrefab.GetComponent<CardScriptReference>().slot = i;

            //finally instantiate
            Instantiate(manager.cardPrefab, manager.pos[i].transform.position, manager.pos[i].transform.rotation);
        }

        manager.cardPrefab.tag = "Untagged";
    }
}
