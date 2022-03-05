using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnGetAndSort : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    

    public void get()
    {
        GameObject[] lastTurnCards = manager.lastTurnCards;

        GameObject[] totalCards = GameObject.FindGameObjectsWithTag("Card"); //all cards

        lastTurnCards = totalCards;

        SelectionSort(lastTurnCards);

        manager.lastTurnCards = lastTurnCards;
        
        manager.Past(lastTurnCards[0]);
        manager.Past(lastTurnCards[3]);

        manager.Present(lastTurnCards[1]);
        manager.Present(lastTurnCards[4]);

        if (manager.gameStart == false)
        {
            manager.PastFuture(lastTurnCards[6]);
            manager.PastFuture(lastTurnCards[7]);
        }

        else
        {
            GameObject.Destroy(lastTurnCards[6]);
            GameObject.Destroy(lastTurnCards[7]);
            manager.gameStart = false;
        }
        manager.Future(lastTurnCards[2]);
        manager.Future(lastTurnCards[5]);

    }


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

        printArray(unsortedList);
    }

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
