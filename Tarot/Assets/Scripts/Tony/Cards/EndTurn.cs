using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour
{
    //don't know if this is needed
    //public Camera _camera;


    //getting positioning right
    public GameObject[] pos;
    private int posRef;

    // card spawning
    public GameObject cardPrefab;
    private CardScriptReference cardReference;

    // slots taken
    public GameObject Table;
    private SlotsTaken slotsTaken;

    //card effects
    //GameObject[] lastTurnCards;


    private void Start()
    {
        slotsTaken = Table.GetComponent<SlotsTaken>();

        //get cards onto table
        PlaceCards();

    }

    private void OnMouseDown()
    {

        CardEffects();
        //DestroyCards();
        PlaceCards();

    }

    private void CardEffects()
    {

        GameObject[] lastTurnCards = GameObject.FindGameObjectsWithTag("Card"); //this finds all cards


        SelectionSort(lastTurnCards);

        //get in the correct order, player than enemy

        Past(lastTurnCards[0]);
        Past(lastTurnCards[3]);

        Present(lastTurnCards[1]);
        Present(lastTurnCards[4]);

        Future(lastTurnCards[2]);
        Future(lastTurnCards[5]);

        PastFuture(lastTurnCards[6]);
        PastFuture(lastTurnCards[7]);

    }


    private void Past(GameObject c)
    {
        GameObject.Destroy(c);
    }

    private void Present(GameObject c)
    {
        GameObject.Destroy(c);
    }

    private void Future(GameObject c)
    {
        switch (c.GetComponent<CardScriptReference>().slot)
        {
            case 2:
                slotsTaken.snapPointTaken[2] = false;
                c.GetComponent<Draggable>().enabled = false;

                c.transform.position = pos[6].transform.position;
                c.GetComponent<CardScriptReference>().slot = 6;
                break;

            case 5:
                c.transform.position = pos[7].transform.position;
                c.GetComponent<CardScriptReference>().slot = 7;
                break;
        }
        c.GetComponent<Draggable>().enabled = false;


    }

    private void PastFuture(GameObject c)
    {
        GameObject.Destroy(c);
    }


    //private void DestroyCards()
    //{
    //    GameObject[] destroy = GameObject.FindGameObjectsWithTag("Card");

    //    foreach (GameObject target in destroy)
    //        GameObject.Destroy(target);

    //}


    private void PlaceCards()// had to combine all scripts so don't have to call getcomponent too many times
    {
        //setup        
        cardReference = cardPrefab.GetComponent<CardScriptReference>();

        cardPrefab.tag = "Card"; // set to card so that the instances get this tag

        //for loop to place in the 6 slots
        for (int i = 0; i < 6; i++)
        {
            ////get pos ref
            //posRef = i;


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



    //with this the array sorts itself ----------------------------------------------------------------------------------------------------------------
    void SelectionSort(GameObject[] unsortedList)
    {
        int min;
        GameObject temp; //temporary swapping place

        for (int i = 0; i < unsortedList.Length; i++)
        {
            min = i;

            for (int j = i + 1; j < unsortedList.Length; j++)
            {
                if (unsortedList[j].gameObject.GetComponent<CardScriptReference>().slot < unsortedList[min].gameObject.GetComponent<CardScriptReference>().slot)
                {
                    min = j;
                }
            }
            if (min != i)
            {
                temp = unsortedList[i];
                unsortedList[i] = unsortedList[min];
                unsortedList[min] = temp;
            }
        }
    }

    //this is literally only for testing out arrays
    void printArray(GameObject[] a)
    {
        string resultString = "";
        for (int i = 0; i < a.Length; i++)
        {
            resultString = resultString + a[i].GetComponent<CardScriptReference>().Cardname + ",";
        }
        print(resultString);
    }
}
