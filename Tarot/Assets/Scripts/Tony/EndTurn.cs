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

    //getting the effects to act in order
    //public List<GameObject> pastCards;
    //public List<GameObject> presentCards;
    //public List<GameObject> futureCards;
    //public List<GameObject> pastFutureCards;

    public GameObject[] lastTurnCards;

    //public List<GameObject> lastTurnCards;


    private void Start()
    {
        slotsTaken = Table.GetComponent<SlotsTaken>();

        //get cards onto table
        PlaceCards();

    }

    private void OnMouseDown()
    {

        CardEffects();
        DestroyCards();
        PlaceCards();
    }

    private void CardEffects()//HERE IS WIP ---------------------------------------
    {

        GameObject[] lastTurnCards = GameObject.FindGameObjectsWithTag("Card");

        foreach (GameObject target in lastTurnCards)
        {
            CardScriptReference targetReference = target.GetComponent<CardScriptReference>();
            


        }


        Past();
        Present();
        Future();
        PastFuture();
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

    private void PastFuture()
    {

    }


    private void DestroyCards()
    {
        GameObject[] lastTurnCards = GameObject.FindGameObjectsWithTag("Card");

        foreach (GameObject target in lastTurnCards)
            GameObject.Destroy(target);

    }


    private void PlaceCards()// had to combine all scripts so don't have to call getcomponent too many times
    {
        //setup        
        cardReference = cardPrefab.GetComponent<CardScriptReference>();

        cardPrefab.tag = "Card"; // set to card so that the instances get this tag

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
        cardPrefab.tag = "Untagged"; //reset to untagged so the script doesn't delete it



    }


}
