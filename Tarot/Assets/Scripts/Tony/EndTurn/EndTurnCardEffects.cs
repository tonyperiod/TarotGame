using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//LARGE custom script where most other game scripts are triggered. Non custom parts specified
public class EndTurnCardEffects : MonoBehaviour
{
    [SerializeField] EndTurn manager;
    GameObject[] lastTurnCards;//main array, this defines all the cards on the board in the moment that the player clicks the "endturn" button

    //to have dyTot be based off how many cards are in game/not countered. This is for the gameplay to proceed seamlessly with the least unwanted delay possible
    public void delayCalculator()
    {
        lastTurnCards = manager.lastTurnCards;
        int cardsInGame = 0;

        for (int i = 0; i < manager.lastTurnCards.Length; i++)
        {
            if (lastTurnCards[i].GetComponent<CardScriptReference>().elem != "dummy")
                cardsInGame += 1;                
        }

        //reduce dytot if the pastFuture cards won't activate
        if (manager.vfxCounter.check(lastTurnCards[6]) == true)
            cardsInGame -= 1;
        if (manager.vfxCounter.check(lastTurnCards[7]) == true)
            cardsInGame -= 1;

        manager.dyTot = cardsInGame * manager.dySingle;
    }


    public void get() //get the cards in game-> used in draggable as well
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

    //each type (past, present, future, pastfuture and all the majors have player activation first and enemy later. Most comments will be on player as the enemy is only a copy-pasted version with a different card activating
    IEnumerator playEffects()//to give delays between functions
    {
        BuffElement(lastTurnCards);
        CounterElement(lastTurnCards);

        //MAJOR ARCANA--------------- //checks court 1 to see if there is a dummy in place. Also deactivated the vfx manager as there are currently no vfx. Will update in future when the game is finalized
        if (manager.lastTurnCards[9].GetComponent<CardScriptReference>().court1 == "major") //check if there is a major arcana in play
        {
            //manager.vfxManager.Activate(lastTurnCards[9], 9);
            yield return new WaitForSeconds(manager.dySingle);
            manager.Major.major(lastTurnCards[9], true);//the bool is "isplaer"
            yield return new WaitForSeconds(manager.dyMajP);//using a different value. usually this value is 0, unless the specific major arcana needs a delay afterwards
            //split in two to make sure spawn type major arcanas have time to be read by the player
        }

        //this doesn't play the major arcana, it only moves it to activate next turn
        if (manager.lastTurnCards[8].GetComponent<CardScriptReference>().court1 == "major") //activate the card switch after to get a last activation in
        {
            //manager.vfxManager.Activate(lastTurnCards[8], 8);
            yield return new WaitForSeconds(manager.dySingle);
            manager.MajorSwitch.majorSwitch(lastTurnCards[8], true);
        }

        //repeat for enemy
        if (manager.lastTurnCards[11].GetComponent<CardScriptReference>().court1 == "major")
        {
            //manager.vfxManager.Activate(lastTurnCards[11], 11);
            yield return new WaitForSeconds(manager.dySingle);
            manager.Major.major(lastTurnCards[11], false);
            yield return new WaitForSeconds(manager.dyMajE);
        }

        if (manager.lastTurnCards[10].GetComponent<CardScriptReference>().court1 == "major")
        {
            //manager.vfxManager.Activate(lastTurnCards[10], 10);
            yield return new WaitForSeconds(manager.dySingle);
            manager.MajorSwitch.majorSwitch(lastTurnCards[10], false);
        }



        //MINOR ARCANA----------------------- added in dummmy check for deactivations from major arcana/counters

        //player past
        if (lastTurnCards[0].GetComponent<CardScriptReference>().elem != "dummy")
        {
            manager.vfxManager.Activate(lastTurnCards[0], 0);
            //check if it counters the past-future, to have the effect read better to the player
            if (manager.vfxCounter.check(lastTurnCards[7]) == true)
                manager.vfxCounter.counter(lastTurnCards[7]);
            
            manager.Past.past(lastTurnCards[0]);//activates the effect
            yield return new WaitForSeconds(manager.dySingle); //wait at the end so the audio syncs
            GameObject.Destroy(lastTurnCards[0]); //destroy here to simplify the code with court cards.
        }
        else
            GameObject.Destroy(lastTurnCards[0]);//if there are dummies they can't stay


        //enemy past
        if (lastTurnCards[3].GetComponent<CardScriptReference>().elem != "dummy")
        {
            manager.cardToCentre.right(manager.lastTurnCards[3]);
            manager.vfxManager.Activate(lastTurnCards[3], 0);
            //check if counter
            if (manager.vfxCounter.check(lastTurnCards[6]) == true)
                manager.vfxCounter.counter(lastTurnCards[6]);
            manager.Past.past(lastTurnCards[3]);
            yield return new WaitForSeconds(manager.dySingle);
            GameObject.Destroy(lastTurnCards[3]);
        }
        else
            GameObject.Destroy(lastTurnCards[3]);//destroy the dummy 


        //player present
        if (lastTurnCards[1].GetComponent<CardScriptReference>().elem != "dummy")
        {
            manager.vfxManager.Activate(lastTurnCards[1], 1);            
            manager.Present.present(lastTurnCards[1]);
            yield return new WaitForSeconds(manager.dySingle);
            GameObject.Destroy(lastTurnCards[1]);
        }
        else
            GameObject.Destroy(lastTurnCards[1]);

        //enemy present
        if (lastTurnCards[4].GetComponent<CardScriptReference>().elem != "dummy")
        {
            manager.cardToCentre.centre(manager.lastTurnCards[4]);
            manager.vfxManager.Activate(lastTurnCards[4], 1);            
            manager.Present.present(lastTurnCards[4]);
            yield return new WaitForSeconds(manager.dySingle);
            GameObject.Destroy(lastTurnCards[4]);

        }
        else
            GameObject.Destroy(lastTurnCards[4]);


        //player past future        
        if (lastTurnCards[6].GetComponent<CardScriptReference>().elem != "dummy")
        {
            if (manager.gameStart == false)//
            {
                //needs to check if countered before activating vfx
                if (manager.vfxCounter.check(lastTurnCards[6]) == false)
                {
                    manager.vfxManager.Activate(lastTurnCards[6], 2);                   
                    manager.PastFuture.pastfuture(lastTurnCards[6], false);
                    yield return new WaitForSeconds(manager.dySingle);

                    GameObject.Destroy(lastTurnCards[6]);
                }

                else
                {
                    GameObject.Destroy(lastTurnCards[6]);
                }
            }
        }
        else
        {
            manager.gameStart = false;//doesn't matter if it repeats, more stable
            GameObject.Destroy(lastTurnCards[6]);
        }


        //enemy past future
        if (lastTurnCards[7].GetComponent<CardScriptReference>().elem != "dummy")
        {            
            if (manager.gameStart == false)
            {
                //needs to check if countered before activating vfx
                if (manager.vfxCounter.check(lastTurnCards[7]) == false)
                {
                    manager.vfxManager.Activate(lastTurnCards[7], 2);                    
                    manager.PastFuture.pastfuture(lastTurnCards[7], false);
                    yield return new WaitForSeconds(manager.dySingle);

                    GameObject.Destroy(lastTurnCards[7]);
                }
                else
                {
                    GameObject.Destroy(lastTurnCards[7]);
                }
            }
        }
        else
        {
            manager.gameStart = false;//doesn't matter if it repeats
            GameObject.Destroy(lastTurnCards[7]);
        }


        //player future
        if (lastTurnCards[2].GetComponent<CardScriptReference>().elem != "dummy")
        {
            if (manager.isWorldP == false)
            {
                manager.vfxManager.Activate(lastTurnCards[2], 3);//for future vfx, when we will possibly make them
                manager.Future.future(lastTurnCards[2]);//I leave it here because there is no card to centre for player, and currently no vfx to play
                yield return new WaitForSeconds(manager.dySingle);
            }
            //world activation
            else
            {
                manager.vfxManager.Activate(lastTurnCards[2], 2);                
                manager.PastFuture.pastfuture(lastTurnCards[2], false);
                yield return new WaitForSeconds(manager.dySingle);
                GameObject.Destroy(lastTurnCards[2]);

                //need to create dummy to not have less cards in game
                manager.MajorDummy.Create(6);
            }
        }
        else
            GameObject.Destroy(lastTurnCards[2]);

        //enemy future
        if (lastTurnCards[5].GetComponent<CardScriptReference>().elem != "dummy")
        {
            manager.cardToCentre.left(manager.lastTurnCards[5]);
            yield return new WaitForSeconds(manager.dySingle / 2);//give time for player to see where the card goes
            if (manager.isWorldE == false)
            {
                manager.vfxManager.Activate(lastTurnCards[5], 3);
                manager.Future.future(lastTurnCards[5]);
                yield return new WaitForSeconds(manager.dySingle/2);
             
            }
            else
            {
                manager.vfxManager.Activate(lastTurnCards[5], 2);
                manager.PastFuture.pastfuture(lastTurnCards[5], false);
                yield return new WaitForSeconds(manager.dySingle/2);
                GameObject.Destroy(lastTurnCards[5]); //just to make sure

                manager.MajorDummy.Create(7);
            }

        }
        else
            GameObject.Destroy(lastTurnCards[5]);
        

        //reset dyMaj to prevent issues
        manager.dyMajP = 0;
        manager.dyMajE = 0;
    }

    //this function is NOT custom, took it from a sorting tutorial
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


    //sets values on the manager to allow for easier counter calculation
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


    //DEBUG
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
