using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnCardEffects : MonoBehaviour
{
    [SerializeField] EndTurn manager;
    GameObject[] lastTurnCards;

    public void delayCalculator()
    {
        lastTurnCards = manager.lastTurnCards;
        int cardsInGame = 0;

        for (int i = 0; i < manager.lastTurnCards.Length; i++)
        {
            if (lastTurnCards[i].GetComponent<CardScriptReference>().elem != "dummy")
                cardsInGame += 1;                
        }
        manager.dyTot = cardsInGame * manager.dySingle;
    }


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
        StartCoroutine("playEffects");
    }

    IEnumerator playEffects()//to give delays between things
    {

        BuffElement(lastTurnCards);
        CounterElement(lastTurnCards);

        //MAJOR ARCANA--------------- ///DO IN FUTURE THE COUNTER
        if (manager.lastTurnCards[9].GetComponent<CardScriptReference>().court1 == "major") //check if there is a major arcana in play
        {
            //manager.vfxManager.Activate(lastTurnCards[9], 9);
            yield return new WaitForSeconds(manager.dySingle);
            manager.Major.major(lastTurnCards[9], true);
            yield return new WaitForSeconds(manager.dyMajP);
            //split in two to make sure spawners have time...?
        }

        if (manager.lastTurnCards[8].GetComponent<CardScriptReference>().court1 == "major") //activate the card switch after to get a last activation in
        {
            //manager.vfxManager.Activate(lastTurnCards[8], 8);
            yield return new WaitForSeconds(manager.dySingle);
            manager.MajorSwitch.majorSwitch(lastTurnCards[8], true);
        }

        //repeat for enemy
        if (manager.lastTurnCards[11].GetComponent<CardScriptReference>().court1 == "major")
        {
            manager.cardToCentre.centre(manager.lastTurnCards[11]);
            //manager.vfxManager.Activate(lastTurnCards[11], 11);
            yield return new WaitForSeconds(manager.dySingle);
            manager.Major.major(lastTurnCards[11], false);
            yield return new WaitForSeconds(manager.dyMajE);
        }

        if (manager.lastTurnCards[10].GetComponent<CardScriptReference>().court1 == "major")
        {
            manager.cardToCentre.centre(manager.lastTurnCards[10]);
            //manager.vfxManager.Activate(lastTurnCards[10], 10);
            yield return new WaitForSeconds(manager.dySingle);
            manager.MajorSwitch.majorSwitch(lastTurnCards[10], false);
        }


        //MINOR ARCANA----------------------- added in dummmy check for deactivations
        if (lastTurnCards[0].GetComponent<CardScriptReference>().elem != "dummy")
        {
            manager.vfxManager.Activate(lastTurnCards[0], 0);
            yield return new WaitForSeconds(manager.dySingle);
            manager.Past.past(lastTurnCards[0]);
        }
        else
            GameObject.Destroy(lastTurnCards[0]);//if there are dummies they can't stay
        if (lastTurnCards[3].GetComponent<CardScriptReference>().elem != "dummy")
        {
            manager.cardToCentre.centre(manager.lastTurnCards[3]);
            manager.vfxManager.Activate(lastTurnCards[3], 0);
            yield return new WaitForSeconds(manager.dySingle);
            manager.Past.past(lastTurnCards[3]);
        }
        else
            GameObject.Destroy(lastTurnCards[3]);


        if (lastTurnCards[1].GetComponent<CardScriptReference>().elem != "dummy")
        {
            manager.vfxManager.Activate(lastTurnCards[1], 1);
            yield return new WaitForSeconds(manager.dySingle);
            manager.Present.present(lastTurnCards[1]);
        }
        else
            GameObject.Destroy(lastTurnCards[1]);

        if (lastTurnCards[4].GetComponent<CardScriptReference>().elem != "dummy")
        {
            manager.cardToCentre.centre(manager.lastTurnCards[4]);
            manager.vfxManager.Activate(lastTurnCards[4], 1);
            yield return new WaitForSeconds(manager.dySingle);
            manager.Present.present(lastTurnCards[4]);
        }
        else
            GameObject.Destroy(lastTurnCards[4]);


        if (lastTurnCards[6].GetComponent<CardScriptReference>().elem != "dummy")
        {
            if (manager.gameStart == false)
            {
                manager.vfxManager.Activate(lastTurnCards[6], 2);
                yield return new WaitForSeconds(manager.dySingle);
                manager.PastFuture.pastfuture(lastTurnCards[6]);
            }
            //destroy placeholders if turn one
            else
            {
                GameObject.Destroy(lastTurnCards[6]);
            }
        }
        else
            GameObject.Destroy(lastTurnCards[6]);


        if (lastTurnCards[7].GetComponent<CardScriptReference>().elem != "dummy")
        {
            
            if (manager.gameStart == false)
            {
                manager.cardToCentre.centre(manager.lastTurnCards[7]);
                manager.vfxManager.Activate(lastTurnCards[7], 2);
                yield return new WaitForSeconds(manager.dySingle);
                manager.PastFuture.pastfuture(lastTurnCards[7]);
            }
            else
            {
                GameObject.Destroy(lastTurnCards[7]);
                manager.gameStart = false;
            }
        }
        else
            GameObject.Destroy(lastTurnCards[7]);


        if (lastTurnCards[2].GetComponent<CardScriptReference>().elem != "dummy")
        {
            if (manager.isWorldP == false)
            {
                manager.vfxManager.Activate(lastTurnCards[2], 3);
                yield return new WaitForSeconds(manager.dySingle / 2);
                manager.Future.future(lastTurnCards[2]);
                yield return new WaitForSeconds(manager.dySingle / 2);
            }
            //world activation
            else
            {


                manager.vfxManager.Activate(lastTurnCards[2], 2);
                yield return new WaitForSeconds(manager.dySingle);
                manager.PastFuture.pastfuture(lastTurnCards[2]);

                //need to create dummy to not have less cards in game
                manager.MajorDummy.Create(6);
            }
        }
        else
            GameObject.Destroy(lastTurnCards[2]);

        if (lastTurnCards[5].GetComponent<CardScriptReference>().elem != "dummy")
        {
            manager.cardToCentre.centre(manager.lastTurnCards[5]);
            
            if (manager.isWorldE == false)
            {
                manager.vfxManager.Activate(lastTurnCards[5], 3);
                yield return new WaitForSeconds(manager.dySingle / 2);
                manager.Future.future(lastTurnCards[5]);
                yield return new WaitForSeconds(manager.dySingle / 2);
            }
            else
            {
                manager.vfxManager.Activate(lastTurnCards[5], 2);
                yield return new WaitForSeconds(manager.dySingle);
                manager.PastFuture.pastfuture(lastTurnCards[5]);

                manager.MajorDummy.Create(7);
            }

        }
        else
            GameObject.Destroy(lastTurnCards[5]);



        //reset dyMaj to prevent issues
        manager.dyMajP = 0;
        manager.dyMajE = 0;
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

            //always run this to make sure it works
            temp = unsortedList[i];
            unsortedList[i] = unsortedList[min];
            unsortedList[min] = temp;
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
            if (list[i].gameObject.GetComponent<CardScriptReference>().elem == element)
            {
                list[i].gameObject.GetComponent<CardScriptReference>().value += manager.elemBuff;
            }
        }

        //slot 6 for past future
        if (list[6].gameObject.GetComponent<CardScriptReference>().elem == element)
        {
            list[6].gameObject.GetComponent<CardScriptReference>().value += manager.elemBuff;
        }

        //enemy part
        element = manager.ERef.element;

        //slots 3-5
        for (int i = 3; i < 6; i++)
        {
            if (list[i].gameObject.GetComponent<CardScriptReference>().elem == element)
            {
                list[i].gameObject.GetComponent<CardScriptReference>().value += manager.elemBuff;
            }
        }

        //slot 7 for past future
        if (list[7].gameObject.GetComponent<CardScriptReference>().elem == element)
        {
            list[7].gameObject.GetComponent<CardScriptReference>().value += manager.elemBuff;
        }
    }

    private void CounterElement(GameObject[] list)
    {
        //set the normal counter
        manager.PElem = list[0].GetComponent<CardScriptReference>().elem;
        manager.EElem = list[3].GetComponent<CardScriptReference>().elem;

        //check for court
        if (manager.PElem == "court")
        {
            manager.PElem = manager.lastTurnCards[0].GetComponent<CardScriptReference>().court1;
            manager.PElemC = manager.lastTurnCards[0].GetComponent<CardScriptReference>().court2;
        }

        if (manager.EElem == "court")
        {
            manager.EElem = manager.lastTurnCards[3].GetComponent<CardScriptReference>().court1;
            manager.EElemC = manager.lastTurnCards[3].GetComponent<CardScriptReference>().court2;
        }

        //set major counter
        manager.PElemMaj = list[1].GetComponent<CardScriptReference>().elem;
        manager.EElemMaj = list[4].GetComponent<CardScriptReference>().elem;

        if (manager.PElemMaj == "court")
        {
            manager.PElemMaj = manager.lastTurnCards[1].GetComponent<CardScriptReference>().court1;
            manager.PElemMajC = manager.lastTurnCards[1].GetComponent<CardScriptReference>().court2;
        }

        if (manager.PElemMaj == "court")
        {
            manager.EElem = manager.lastTurnCards[4].GetComponent<CardScriptReference>().court1;
            manager.EElemC = manager.lastTurnCards[4].GetComponent<CardScriptReference>().court2;
        }
    }

    //this is for testing purposes
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
