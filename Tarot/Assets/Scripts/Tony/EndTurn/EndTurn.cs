using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour
{
    //ref to secondary scripts
    [Header ("Ref To Scripts")]
    public EndTurnPlaceCards placeCardsScript;
    public EndTurnCardEffects cardeffects;
    public EndTurnRemoveCardEffects removecardeffects;
    public Past Past;
    public Present Present;
    public Future Future;
    public PastFuture PastFuture;

    [Space]

    //getting positioning right
    public GameObject[] pos;
    private int posRef;

    // card spawning
    public GameObject cardPrefab;
    private CardScriptReference cardReference;

    // slots taken
    public GameObject Table;
    [HideInInspector]
    public SlotsTaken slotsTaken;

    //card effects
    [HideInInspector]
    public GameObject[] lastTurnCards;
    [HideInInspector]
    public bool isEonFirePa, isPonFirePa, isEonFirePr, isPonFirePr, isEonFireFu, isPonFireFu;

    //hp system managers
    public GameObject Gamehandler;
    [HideInInspector]
    public PlayerSystemManager PSysMng;
    [HideInInspector]
    public EnemySystemManager EsysMng;

    //fix bug of the two placeholder cards in slot activating
    [HideInInspector]
    public bool gameStart;
}
