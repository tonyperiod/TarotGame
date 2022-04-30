using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom parent script for the shop, copied over from endturn and modified
public class Shop : MonoBehaviour
{
    [Header("parameters")]
    //audio manager
    public AudioManager audioManager;
    //spawning in correct location
    public GameObject[] pos;

    public ScriptableCardDatabase[] byElemData;

    public ScriptableCardDatabase shopAllDataInGame; //to have list in game, resets every playthrough
    public ScriptableCardDatabase shopAllData; //to save permanently
    public ScriptableCardDatabase playerCurrentDatabase;

    public int currentArea;//this is for ufficial shop spawning
    public string enemyStre = "mid";//here I put shop

    public GameObject[] buyableCards;
    public List<ScriptableCard> buyableCardsScriptableCards; //LETS TRY for bug fix

    [Header("script references")]

    public ShopDeckSplitter splitter;
    public GameObject cardPrefab;
    private ShopCardScriptReference cardReference;
    public ShopBuy shopBuy;

    [Header("defaults for testing")]

    [SerializeField] ScriptableChar defChar;
    [SerializeField] int defSceneNumber;

    //called on awake by the AwakeManager
    public void CustomAwake()
    {
        //nulls for testing, def = default
        if (InterScene.currentEnemy == null)
            InterScene.currentEnemy = defChar;
        if (InterScene.currentSceneNumber == 0)
            InterScene.currentSceneNumber = defSceneNumber;

        enemyStre = InterScene.currentEnemy.Strength;
        currentArea = InterScene.currentSceneNumber;

        buyableCards = new GameObject[5];

        splitter.setoff(); //NEED TO DO ONLY ONCE
    }

    //activate shop splitter, needs to be separate from the custom awake as I call it from shopBuy as well
    public void SplitterActivate()
    {
        splitter.setoff();
    }


    public void chooseCards()
    {
        for (int i = 0; i < 5; i++)
        {
            ScriptableCard chosen;
            do
            {
                chosen = ShopDeck.PickCard();
            }
            while (buyableCardsScriptableCards.Contains(chosen));//to not get repeating cards when the shop selection starts to be smaller

            buyableCardsScriptableCards.Add(chosen);//this list is then is used to place the cards

            Debug.Log(chosen.name);
        }
    }

    ////TESTING ONLY
    //private void Update()
    //{

    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        Debug.Log("pressed e");
    //        testerPicker();
    //    }
    //}

    ////DEBUG SCRIPT
    //private void testerPicker()
    //{
    //    ScriptableCard chosen;
    //    chosen = ShopDeck.PickCard();
    //    if (chosen == null)
    //    {
    //        Debug.Log("stop early");

    //        testerPicker();

    //    }
    //    Debug.Log(ShopDeck.PickCard());
    //}
}
