using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour
{
    //ref to secondary scripts
    public EndTurnPlaceCards placeCardsScript;
    public EndTurnCardEffects cardeffects;
    public EndTurnRemoveCardEffects removecardeffects;
    public Past Past;
    public Present Present;
    public Future Future;
    public PastFuture PastFuture;

    //getting positioning right
    public GameObject[] pos;
    private int posRef;

    // card spawning
    public GameObject cardPrefab;
    private CardScriptReference cardReference;

    // slots taken
    public GameObject Table;
    public SlotsTaken slotsTaken;

    //card effects
    public GameObject[] lastTurnCards;
    public bool isEonFirePa, isPonFirePa, isEonFirePr, isPonFirePr, isEonFireFu, isPonFireFu;

    //hp system managers


    public GameObject Gamehandler;
    public PlayerSystemManager PSysMng;
    public EnemySystemManager EsysMng;

    //fix bug of the two placeholder cards in slot activating
    public bool gameStart;
}
