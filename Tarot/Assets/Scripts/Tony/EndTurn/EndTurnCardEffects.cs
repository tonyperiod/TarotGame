using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnCardEffects : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    //vfx activation get references
    public VFXPast vfxPa;
    public VFXPresent vfxPre;
    public VFXFuture vfxFut;
    public VFXPastFuture vfxpastFut;

    GameObject[] lastTurnCards;

    public void get() //just get the cards -> used in draggable now as well
    {
        lastTurnCards = manager.lastTurnCards;
        GameObject[] totalCards = GameObject.FindGameObjectsWithTag("Card"); //all cards
        lastTurnCards = totalCards;
        SelectionSort(lastTurnCards);
        manager.lastTurnCards = lastTurnCards;
    }


    public void activate()
    {

        BuffElement(lastTurnCards);

        vfxPa.activate(lastTurnCards[0]);
        manager.Past.past(lastTurnCards[0]);
        vfxPa.activate(lastTurnCards[3]);
        manager.Past.past(lastTurnCards[3]);

        vfxPre.activate(lastTurnCards[1]);
        manager.Present.present(lastTurnCards[1]);
        vfxPre.activate(lastTurnCards[4]);
        manager.Present.present(lastTurnCards[4]);

        if (manager.gameStart == false)
        {
            vfxpastFut.activate(lastTurnCards[6]);
            manager.PastFuture.pastfuture(lastTurnCards[6]);
            vfxpastFut.activate(lastTurnCards[7]);
            manager.PastFuture.pastfuture(lastTurnCards[7]);
        }
        //destroy placeholders if turn one
        else
        {
            GameObject.Destroy(lastTurnCards[6]);
            GameObject.Destroy(lastTurnCards[7]);
            manager.gameStart = false;
        }

        vfxFut.activate(lastTurnCards[2]);
        manager.Future.future(lastTurnCards[2]);
        vfxFut.activate(lastTurnCards[5]);
        manager.Future.future(lastTurnCards[5]);
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
    }

    //increase value of cards with the same element
    //court cards will refer to their own version of the script.
    private void BuffElement(GameObject[] list)
    {

        //player part
        string element = manager.PRef.element;
        //these are slots 0-2
        for (int i = 0; i < 3; i++)
        {
            if(list[i].gameObject.GetComponent<CardScriptReference>().symbol == element)
            {
                list[i].gameObject.GetComponent<CardScriptReference>().value += manager.elemBuff;
            }
        }

        //slot 6 for past future
        if (list[6].gameObject.GetComponent<CardScriptReference>().symbol == element)
        {
            list[6].gameObject.GetComponent<CardScriptReference>().value += manager.elemBuff;
        }

        //enemy part
        element = manager.ERef.element;

        //slots 3-5
        for (int i = 3; i < 6; i++)
        {
            if (list[i].gameObject.GetComponent<CardScriptReference>().symbol == element)
            {
                list[i].gameObject.GetComponent<CardScriptReference>().value += manager.elemBuff;
            }
        }

        //slot 7 for past future
        if (list[7].gameObject.GetComponent<CardScriptReference>().symbol == element)
        {
            list[7].gameObject.GetComponent<CardScriptReference>().value += manager.elemBuff;
        }
    }

    //this is for testing purposes
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
