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


    public string currentArea;//this is for ufficial shop spawning
    public string enemyStre;//here I put shop

    [Header("script references")]

    public ShopDeckSplitter splitter;

    // Start is called before the first frame update
    void Awake()
    {
        //I set ALL parameters in this script, only have to reference

        //TESTING ONLY!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        InterScene.isFirst = true;


        //get all cards and put into deck
        if (InterScene.isFirst == true)
        {
            if (shopAllDataInGame != null)
                shopAllDataInGame.allCards.Clear();
            shopAllDataInGame.allCards = new List<ScriptableCard> (shopAllData.allCards);


            splitter.setoff(); //NEED TO DO ONLY ONCE
        }


        //enemyStre = InterScene.currentEnemy.Strength;        
        //currentArea = InterScene.currentScene;
    }





}
