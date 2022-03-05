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
    private bool isEonFirePa, isPonFirePa, isEonFirePr, isPonFirePr, isEonFireFu, isPonFireFu;
 



    //hp system managers

    GameObject[] lastTurnCards;

    public GameObject Gamehandler;
    private PlayerSystemManager PSysMng;
    private EnemySystemManager EsysMng;

    //fix bug of the two placeholder cards in slot activating
    private bool gameStart;

    public void CustomAwake()
    {
        slotsTaken = Table.GetComponent<SlotsTaken>();

        //fix bug of the two placeholder cards in slot activating
        gameStart = true;

        //get cards onto table
        PlaceCards();

        //fire stuff
        isEonFirePa = false;
        isPonFirePa = false;

        isEonFirePr = false;
        isPonFirePr = false;

        isEonFireFu = false;
        isPonFireFu = false;

        //get syst managers for hp
        PSysMng = Gamehandler.GetComponent<PlayerSystemManager>();
        EsysMng = Gamehandler.GetComponent<EnemySystemManager>();
    }

    private void OnMouseDown()
    {

        CardEffects();
        RemoveCardEffects();
        //DestroyCards();
        PlaceCards();

    }

    private void CardEffects()
    {

        GameObject[] totalcards = GameObject.FindGameObjectsWithTag("Card"); //this finds all cards
        lastTurnCards = totalcards;

        SelectionSort(lastTurnCards);

        //get in the correct order, player than enemy

        Past(lastTurnCards[0]);
        Past(lastTurnCards[3]);

        Present(lastTurnCards[1]);
        Present(lastTurnCards[4]);

        if (gameStart != true)
        {
            PastFuture(lastTurnCards[6]);
            PastFuture(lastTurnCards[7]);
        }

        else
        {
            GameObject.Destroy(lastTurnCards[6]);
            GameObject.Destroy(lastTurnCards[7]);
            gameStart = false;
        }
        Future(lastTurnCards[2]);
        Future(lastTurnCards[5]);

    }



    private void Past(GameObject c)
    {
        bool isplayer = c.GetComponent<CardScriptReference>().isplayer;
        int value = c.GetComponent<CardScriptReference>().value;


        switch (c.GetComponent<CardScriptReference>().symbol)
        {
            case "fire":
                if (isplayer == true)
                {
                    lastTurnCards[1].GetComponent<CardScriptReference>().value += value;
                    isEonFirePa = true;
                }
                else
                {
                    lastTurnCards[4].GetComponent<CardScriptReference>().value += value;
                    isPonFirePa = true;
                }

                break;


            case "air":
                if (isplayer == true)
                {//comparing
                    int futdmg = FutureDamage(lastTurnCards[7]);
                    int passingDmg = futdmg - value;

                    //dmg bigger than value, most common one. here just using value works fine
                    if (passingDmg > 0)
                    {
                        lastTurnCards[7].GetComponent<CardScriptReference>().value -= value / 2;
                        EsysMng.TakeAirDmg(value);
                    }

                    if (passingDmg == 0)
                    {
                        lastTurnCards[7].GetComponent<CardScriptReference>().value = 0;
                        EsysMng.TakeAirDmg(value);
                    }

                    if (passingDmg < 0)
                    {
                        lastTurnCards[7].GetComponent<CardScriptReference>().value = 0;
                        EsysMng.TakeAirDmg(-passingDmg);
                    }
                }

                else
                {
                    int futdmg = FutureDamage(lastTurnCards[6]);
                    int passingDmg = futdmg - value;

                    //dmg bigger than value, most common one. here just using value works fine
                    if (passingDmg > 0)
                    {
                        lastTurnCards[6].GetComponent<CardScriptReference>().value -= value / 2;
                        PSysMng.TakeAirDmg(value);
                    }

                    if (passingDmg == 0)
                    {
                        lastTurnCards[6].GetComponent<CardScriptReference>().value = 0;
                        PSysMng.TakeAirDmg(value);
                    }

                    if (passingDmg < 0)
                    {
                        lastTurnCards[6].GetComponent<CardScriptReference>().value = 0;
                        PSysMng.TakeAirDmg(-passingDmg);
                    }
                }

                break;


            case "earth":
                if (isplayer == true)
                {
                    PSysMng.HealSH(value);                    
                }
                else
                {
                    EsysMng.HealSH(value);
                }

                break;


            case "water":
                if (isplayer == true)
                {
                    int predmg = lastTurnCards[4].GetComponent<CardScriptReference>().value;
                    int passingDmg = predmg - value;
                    int finalDmg = value; // this is for the heal to happen even on passingdmg <0

                    //dmg bigger than value, most common one. here just using value works fine
                    if (passingDmg > 0)
                    {
                        lastTurnCards[4].GetComponent<CardScriptReference>().value = passingDmg;
                        EsysMng.TakeDamage(finalDmg);
                    }

                    if (passingDmg == 0)
                    {
                        lastTurnCards[7].GetComponent<CardScriptReference>().value = 0;
                        EsysMng.TakeDamage(finalDmg);
                    }

                    if (passingDmg < 0)
                    {
                        lastTurnCards[7].GetComponent<CardScriptReference>().value = 0;
                        finalDmg = value - predmg;
                        EsysMng.TakeDamage(finalDmg);
                    }

                    if (isPonFirePa == false)
                        PSysMng.HealHP(finalDmg / 2);

                }

                else
                {
                    int predmg = lastTurnCards[1].GetComponent<CardScriptReference>().value;
                    int passingDmg = predmg - value;
                    int finalDmg = value; // this is for the heal to happen even on passingdmg <0

                    //dmg bigger than value, most common one. here just using value works fine
                    if (passingDmg > 0)
                    {
                        lastTurnCards[1].GetComponent<CardScriptReference>().value = passingDmg;
                        PSysMng.TakeDamage(finalDmg);
                    }

                    if (passingDmg == 0)
                    {
                        lastTurnCards[1].GetComponent<CardScriptReference>().value = 0;
                        PSysMng.TakeDamage(finalDmg);
                    }

                    if (passingDmg < 0)
                    {
                        lastTurnCards[1].GetComponent<CardScriptReference>().value = 0;
                        finalDmg = value - predmg;
                        PSysMng.TakeDamage(finalDmg);
                    }

                    if (isEonFirePa == false)
                        EsysMng.HealHP(finalDmg/2);
                }
                break;
        }

        GameObject.Destroy(c);
    }




    private void Present(GameObject c)
    {
        bool isplayer = c.GetComponent<CardScriptReference>().isplayer;
        int value = c.GetComponent<CardScriptReference>().value;


        switch (c.GetComponent<CardScriptReference>().symbol)
        {
            case "fire":
                if (isplayer == true)
                {
                    EsysMng.TakeDamage(value);
                    isEonFirePr = true;
                }
                else
                {
                    PSysMng.TakeDamage(value);
                    isPonFirePr = true;
                }

                break;


            case "air":

                if (isplayer == true)
                    EsysMng.TakeAirDmg(value);
                else
                    PSysMng.TakeAirDmg(value);

                break;


            case "earth":
                if (isplayer == true)
                {
                    EsysMng.TakeDamage(value);
                    PSysMng.HealSH(value / 2);
                }
                else
                {
                    PSysMng.TakeDamage(value);
                    EsysMng.HealSH(value / 2);
                }

                break;


            case "water":
                if (isplayer == true)
                {
                    EsysMng.TakeDamage(value);
                    if (isPonFirePr == false)
                        PSysMng.HealHP(value / 2);

                }
                else
                {
                    PSysMng.TakeDamage(value);
                    if (isEonFirePr == false)
                        EsysMng.HealHP(value / 2);
                }
                break;

        }



        GameObject.Destroy(c);
    }


    private void PastFuture(GameObject c)
    {
        bool isplayer = c.GetComponent<CardScriptReference>().isplayer;
        int value = c.GetComponent<CardScriptReference>().value;

        //counter element

        string PElem = lastTurnCards[0].GetComponent<CardScriptReference>().symbol;
        string EElem = lastTurnCards[3].GetComponent<CardScriptReference>().symbol;

        switch (c.GetComponent<CardScriptReference>().symbol)
        {
            case "fire":

                if (isplayer == true && EElem != "water")
                {
                    EsysMng.TakeDamage(2 * value);
                    isEonFireFu = true;
                }

                if (isplayer == false && PElem != "water")
                {
                    PSysMng.TakeDamage(2 * value);
                    isEonFireFu = true;
                }

                break;


            case "air":

                if (isplayer == true && EElem != "earth")
                {
                    EsysMng.TakeAirDmg(2 * value);
                }

                if (isplayer == false && PElem != "earth")
                {
                    PSysMng.TakeAirDmg(2 * value);
                }
                break;


            case "earth":
                if (isplayer == true && EElem != "air")
                {
                    PSysMng.HealSH(2 * value);
                }

                if (isplayer == false && PElem != "air")
                {
                    EsysMng.HealSH(2 * value);
                }

                break;


            case "water":
                if (isplayer == true && isPonFireFu == false && EElem != "fire")
                {
                    PSysMng.HealHP(2 * value);
                }
                if (isplayer == false && isEonFireFu == false && PElem != "fire")
                {
                    EsysMng.HealHP(2 * value);
                }
                break;

        }


        GameObject.Destroy(c);
    }

    private int FutureDamage(GameObject c)
    {
        int damage;
        int value = c.GetComponent<CardScriptReference>().value;

        switch (c.GetComponent<CardScriptReference>().symbol)
        {
            case "fire":
                damage = 2 * value;
                break;


            case "air":
                damage = 2 * value;
                break;

            default:
                damage = 0;
                break;
        }

        return damage;
    }



    private void Future(GameObject c)
    {
        switch (c.GetComponent<CardScriptReference>().slot)
        {
            case 2:
                slotsTaken.snapPointTaken[2] = false;


                c.transform.position = pos[6].transform.position;
                c.GetComponent<CardScriptReference>().slot = 6;
                break;

            case 5:
                c.transform.position = pos[7].transform.position;
                c.GetComponent<CardScriptReference>().slot = 7;
                break;
        }


    }



    private void RemoveCardEffects()
    {
        //removing the fire from everything
        isEonFirePa = false;
        isPonFirePa = false;

        isEonFirePr = false;
        isPonFirePr = false;

        isEonFireFu = false;
        isPonFireFu = false;
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
