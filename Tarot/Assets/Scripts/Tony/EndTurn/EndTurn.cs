using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour
{
    //ref to secondary scripts
    [Header ("ref To Scripts")]
    public EndTurnPlaceCards placeCardsScript;
    public EndTurnCardEffects cardeffects;
    public EndTurnRemoveCardEffects removecardeffects;
    public Past Past;
    public Present Present;
    public Future Future;
    public PastFuture PastFuture;
    public Draggable draggable;
    public VFXManager vfxManager;

    [Header ("card functioning")]

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

    //fix bug of the two placeholder cards in slot activating
    [HideInInspector]
    public bool gameStart;

    [Header ("game characters")]
    //hp system managers
    public GameObject Gamehandler;
    [HideInInspector]
    public PlayerSystemManager PSysMng;
    [HideInInspector]
    public EnemySystemManager EsysMng;

    [Header ("elemental stuff")]
    //player/enemy elemental reference
    public PlayerReference PRef;
    public EnemyReference ERef;
    public int elemBuff = 2;
    public CourtBuff courtbuff;

    [HideInInspector]
    public string PElem, EElem, PElemC, EElemC;

    [Header("delays")]

    //everything to control the delays (delays done in endturnclick and endturncard effects

    public float dySingle;
    public float dyTot;
}
