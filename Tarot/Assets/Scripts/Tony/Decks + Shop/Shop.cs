using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    


    //spawning in correct location
    public GameObject[] pos;

    public ScriptableCardDatabase[] byElemData;

    public ScriptableCardDatabase shopAllDataInGame; //to have list in game
    public ScriptableCardDatabase shopAllData; //to save permanently


    public int currentArea;//this is for ufficial shop spawning
    public string enemyStre = "mid";//here I put shop

    [Header("script references")]

    public ShopDeckSplitter splitter;

    // Start is called before the first frame update
    void Awake()
    {
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

        //TESTING ONLY!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //InterScene.isFirst = true;
        //InterScene.currentEnemy.Strength = "mid";
        //InterScene.currentSceneNumber = 10;
        enemyStre = "mid";
        currentArea = 7;
        if (shopAllDataInGame != null)
            shopAllDataInGame.allCards.Clear();
        shopAllDataInGame.allCards = new List<ScriptableCard>(shopAllData.allCards);




        splitter.setoff(); //NEED TO DO EVERY TIME CARD PICKED


        //get all cards and put into deck
        //if (InterScene.isFirst == true)
        //{
        //    if (shopAllDataInGame != null)
        //        shopAllDataInGame.allCards.Clear();
        //    shopAllDataInGame.allCards = new List<ScriptableCard> (shopAllData.allCards);


        //    splitter.setoff(); //NEED TO DO ONLY ONCE
        //}


        //enemyStre = InterScene.currentEnemy.Strength;
        //currentArea = InterScene.currentSceneNumber;
    }

    public void SplitterActivate()
    {
        splitter.setoff();
    }

    //TESTING ONLY
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("pressed e");
            testerPicker();
        }
    }

    private void testerPicker()
    {
        ScriptableCard chosen;
        chosen = ShopDeck.PickCard();
        if (chosen == null)
        {
            Debug.Log("stop early");

            testerPicker();

        }
        Debug.Log(ShopDeck.PickCard());
    }

}
