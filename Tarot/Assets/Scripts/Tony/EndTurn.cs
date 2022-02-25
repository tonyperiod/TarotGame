using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour
{
    public Camera _camera;
    public GameObject cardPrefab;

    //getting positioning right
    public GameObject[] pos;
    private int posRef;

    // card parameter work
    private CardScriptReference cardReference;

    // slots taken work
    public GameObject Table;
    private SlotsTaken slotsTaken;


    private void Start()
    {
        slotsTaken = Table.GetComponent<SlotsTaken>();
    }

    private void OnMouseDown()
    {
        DestroyCards();
        PlaceCards();
        CardEffects();
    }


    private void DestroyCards()
    {
        //TODO: destroy all cards in scene____________________________________________________________
    }


    private void PlaceCards()// had to combine all scripts so don't have to call getcomponent too many times
    {
        //setup        
        cardReference = cardPrefab.GetComponent<CardScriptReference>();
        

        //for loop to place in the 6 slots
        for (int i = 0; i < 6; i++)
        {
            //get pos ref
            posRef = i;


            // get card ref to know if it enemy or player
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
    }

    //TODO all the card effect logic___________________________
    private void CardEffects()
    {
        Past();
        Present();
        Future();
    }

    private void Past()
    {

    }

    private void Present()
    {

    }

    private void Future()
    {

    }
}
