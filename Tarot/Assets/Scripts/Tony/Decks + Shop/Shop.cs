using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("parameters")]

    //spawning in correct location
    public GameObject[] pos;

    public ScriptableCardDatabase[] byElemData;
    public ScriptableCardDatabase shopAllDataInGame; //to have list in game
    public ScriptableCardDatabase shopAllData; //to save permanently
    public ScriptableCardDatabase playerCurrentDatabase;

    public int currentArea;//this is for ufficial shop spawning
    public string enemyStre = "mid";//here I put shop

    public GameObject[] buyableCards;

    [Header("script references")]

    public ShopDeckSplitter splitter;
    public GameObject cardPrefab;
    private ShopCardScriptReference cardReference;
    public ShopBuy shopBuy;


    public void CustomAwake()
    {
        splitter.setoff(); //NEED TO DO EVERY TIME CARD PICKED               


        enemyStre = InterScene.currentEnemy.Strength;
        currentArea = InterScene.currentSceneNumber;

        if (InterScene.isNotNewGame == false)
        {
            if (shopAllDataInGame != null)
                shopAllDataInGame.allCards.Clear();
            shopAllDataInGame.allCards = new List<ScriptableCard>(shopAllData.allCards);

            Debug.Log(InterScene.isNotNewGame + " is notnew");
            InterScene.isNotNewGame = true;
        }




        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);//to make sure that it never gets destroyed from game start
        //}
        //else
        //{
        //    Destroy(gameObject); //if there is already a playerdatabase in game
        //}
        //I set ALL parameters in this script, only have to reference



        //TESTING ONLY!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //enemyStre = "mid";
        //currentArea = 7;
        //if (shopAllDataInGame != null)
        //    shopAllDataInGame.allCards.Clear();
        //shopAllDataInGame.allCards = new List<ScriptableCard>(shopAllData.allCards);




    }

    public void SplitterActivate()
    {
        splitter.setoff();
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
