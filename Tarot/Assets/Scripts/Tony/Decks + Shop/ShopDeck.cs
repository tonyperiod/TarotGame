using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDeck : MonoBehaviour
{
    [SerializeField] Shop manager;
    private static ShopDeck instance; //this database 


    //only used here
    private int cardTot;


    public void CustomAwake()
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

    }



    //this runs per game instance
    public static ScriptableCard PickCard()
    {
        int chosenDatabase;
        chosenDatabase = ShopRNGManager.chooseData();

        //this is in case that the list runs out
        while (instance.manager.byElemData[chosenDatabase].allCards.Count == 0)
        {
            Debug.Log("iz out");
            chosenDatabase = ShopRNGManager.chooseData();            
        }

        ScriptableCard pickedCard = instance.manager.byElemData[chosenDatabase].allCards[Random.Range(0, instance.manager.byElemData[chosenDatabase].allCards.Count)];

        //this is jank to pass to cardscriptreference
        pickedCard.databaseId = chosenDatabase;
        return pickedCard;
    }

    //get what database to use, repeat until get something with a value
    //public int Checker(int db)
    //{
    //    if (db == 0)
    //    {
    //        instance.Checker();
    //        instance.Checker(instance.manager.byElemData[instance.chosenDatabase].allCards.Count);
    //    }

    //    else
    //        return db;

    //}

}