using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnManager : MonoBehaviour
{
    //getting reference to awake manager



    //connecting to all the child scripts
    public PlaceCards placeCards;
    public EndTurnClick endTurnClick;
    public CardEffects cardEffects;
    public CardSorter cardsorter;

    //------------------------------------------------------------------------------------
    //getting positioning right
    public GameObject[] pos;
    private int posRef;

    // card spawning
    public GameObject cardPrefab;
    public CardScriptReference cardReference;

    // slots taken
    public GameObject Table;
    private SlotsTaken slotsTaken;

    //card effects

    public bool isEonFirePa, isPonFirePa, isEonFirePr, isPonFirePr, isEonFireFu, isPonFireFu;
    
    //hp system managers

    public GameObject[] lastTurnCards;

    public GameObject HPSHSystemManager;
    public PlayerSystemManager PSysMng;
    public EnemySystemManager EsysMng;

    //************************************************************
    public void CustomAwake()
    {
        slotsTaken = Table.GetComponent<SlotsTaken>();

        //get cards onto table
        placeCards.yes();

        //fire stuff
        isEonFirePa = false;
        isPonFirePa = false;

        isEonFirePr = false;
        isPonFirePr = false;

        isEonFireFu = false;
        isPonFireFu = false;

        //get syst managers for hp
        PSysMng = HPSHSystemManager.GetComponent<PlayerSystemManager>();
        EsysMng = HPSHSystemManager.GetComponent<EnemySystemManager>();
    }

    //************************************************************

    //other script only triggers this
    public void turnClick()
    {
        placeCards.yes();
        cardsorter.StartIt();
        cardEffects.SwitchBoard(lastTurnCards);
    }


    public void RemoveCardEffects()
    {
        isEonFirePa = false;
        isPonFirePa = false;

        isEonFirePr = false;
        isPonFirePr = false;

        isEonFireFu = false;
        isPonFireFu = false;

    }
}
