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
    public EndTurnCardToCentre cardToCentre;
    public Past Past;
    public Present Present;
    public Future Future;
    public MajorArcana Major;//PUT ALL THE SINGLE MAJOR ARCANA SCRIPT REFERENCES IN THIS
    public MajorSwitch MajorSwitch;
    public MajorDummy MajorDummy;
    public MajorDestroyedSwitch MajorDestroy;
    public PastFuture PastFuture;
    public Draggable draggable;
    public VFXManager vfxManager;
    public VFXCounter vfxCounter;
 
    [Header ("card functioning")]

    //getting positioning right
    public GameObject[] pos;
    public GameObject[] dummySlots;
    private int posRef;
    public GameObject[] centrePos;

    // card spawning
    public GameObject cardPrefab;
    private CardScriptReference cardReference;

    // slots taken
    public GameObject Table;
    [HideInInspector]
    public SlotsTaken slotsTaken;

    //card effects
    //[HideInInspector]
    public GameObject[] lastTurnCards;
    [HideInInspector]
    public bool isEonFirePa, isPonFirePa, isEonFirePr, isPonFirePr, isEonFireFu, isPonFireFu;

    //fix bug of the two placeholder cards in slot activating
    [HideInInspector]
    public bool gameStart;

    //MAJOR ARCANA STUFF--------------------------------------------------------------------------------------------------
    //major arcana min turns between activations
   /*[HideInInspector]*/ public int playerMajorActivation;
    /*[HideInInspector]*/ public int enemyMajorActivation;
    public int playerMajorActivationMax;
    public int enemyMajorActivationMax;

    //dummy card
    public ScriptableCard dummy;
    [HideInInspector] public bool isHighP;
    [HideInInspector] public bool isHighE;
    [HideInInspector] public bool isWorldP;//in cardeffects
    [HideInInspector] public bool isWorldE;


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
    public string PElem, EElem, PElemC, EElemC, PElemMaj, EElemMaj, PElemMajC, EElemMajC;

    [Header("delays")]

    //everything to control the delays (delays done in endturnclick and endturncard effects

    public float dySingle;
    public float dyTot;
    public float dyMajP;
    public float dyMajE;

  
}
