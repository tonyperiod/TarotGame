using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSorter : MonoBehaviour
{
    [SerializeField] EndTurnManager manager;

    //THE ISSUES ARE SOMEWHERE HERE I THINK ****************************************
    //********************************************************************************
    public void StartIt()
    {
        manager.lastTurnCards = SortedList();

    }

    public GameObject[] SortedList()
    {

        GameObject[] sortedCards = GameObject.FindGameObjectsWithTag("Card"); //this finds all cards        

        SelectionSort(sortedCards);       

        return sortedCards;
    }

    public void SelectionSort(GameObject[] unsortedList)
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
}
