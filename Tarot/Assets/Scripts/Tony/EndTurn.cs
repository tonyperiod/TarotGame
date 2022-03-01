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

    public GameObject[] lastTurnCards;


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

        GameObject[] lastTurnCards = GameObject.FindGameObjectsWithTag("Card"); //this finds all cards
        
 
        SelectionSort(lastTurnCards);

        //get in the correct order

        Past(lastTurnCards[0]);
        Past(lastTurnCards[3]);

        Present(lastTurnCards[1]);
        Present(lastTurnCards[4]);

        Future(lastTurnCards[2]);
        Future(lastTurnCards[5]);

        //PastFuture(lastTurnCards[6]);
        //PastFuture(lastTurnCards[7]);
    }


    private void Past(GameObject c)
    {
        Debug.Log(c.GetComponent<CardScriptReference>().Cardname);
    }

    private void Present(GameObject c)
    {
        Debug.Log(c.GetComponent<CardScriptReference>().Cardname);
    }

    private void Future(GameObject c)
    {
        Debug.Log(c.GetComponent<CardScriptReference>().Cardname);
    }

    //private void PastFuture(GameObject c)
    //{

    //}


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

    //with this the array sorts itself basd
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
    //void printArray(GameObject[] a)
    //{
    //    string resultString = "";
    //    for (int i = 0; i < a.Length; i++)
    //    {
    //        resultString = resultString + a[i].GetComponent<CardScriptReference>().Cardname + ",";
    //    }
    //    print(resultString);
    //}
}
