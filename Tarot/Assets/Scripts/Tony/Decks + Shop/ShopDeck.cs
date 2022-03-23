using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDeck : MonoBehaviour
{
    [SerializeField] Shop manager;
    private static ShopDeck instance; //this database 

    //only used here
    private int cardTot;
    [HideInInspector] public string chosenDatabase;


    private void Start()
    {
        //getting a new instance of all things
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);//to make sure that it never gets destroyed from game start
        }
        else
        {
            Destroy(gameObject); //if there is already a playerdatabase in game
        }

        //get total amount of cards
        cardTot = manager.shopAllDataInGame.allCards.Count; //only ones in game are necessary, no remixing deck
    }


    //public static ScriptableCard PickCard()
    //{


    //    return;
    //}

}
