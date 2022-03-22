using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


//this script is to create the database in game, and have only 1 of it. This is basically the Deck

public class EnemyInGameDeck : MonoBehaviour
{
    public ScriptableCardDatabase enemyDatabase; //to slot in player database
    private static EnemyInGameDeck instance; //this database 
    public List<ScriptableCard> currentDeckList; //this Deck list

    private float cardTot;
    private float cardCur;


    public void CustomAwake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);//to make sure that it never gets destroyed from game start
        }
        else
        {
            Destroy(gameObject); //if there is already a playerdatabase in game
        }
        cardTot = instance.enemyDatabase.allCards.Count; //have to edit directly the enemydatabase
        ReorderDeck();
        NewDeck();
    }
    //TODO add in procedural deck building-----------------

    public void NewDeck() //this pure jank is to load in all the cards to the in game deck
    {
        instance.currentDeckList.Clear(); //empty out deck

        for (int i = 0; i < instance.enemyDatabase.allCards.Count; i++) //add back in all the cards from the enemy owned database one by one
        {
            instance.currentDeckList.Add(GetCardByID(i));
        }

        cardCur = cardTot;

        //set all cards to is enemy
        foreach (var Card in instance.currentDeckList)
        {
            Card.isPlayer = false;
        }
    }

    //this is to re-assign all id values
    private void ReorderDeck()
    {
        for (int i = 0; i < instance.enemyDatabase.allCards.Count; i++)
        {
            instance.enemyDatabase.allCards[i].id = i;
        }      
    }

    

    public static ScriptableCard GetCardByID(int ID) // get in all the cards
    {
        return instance.enemyDatabase.allCards.FirstOrDefault(i => i.id == ID); //returns first instance that matches true, or default (null)
    }


    public static ScriptableCard PickCard() // get random card

    {
        if (instance.cardCur < 1) //draw cards then do the normal stuff
        {
            instance.NewDeck();
            ScriptableCard pickedCard = instance.currentDeckList[Random.Range(0, instance.currentDeckList.Count())];
            instance.currentDeckList.Remove(pickedCard);
            instance.cardCur -= 1;
            return pickedCard;
        }

        else //just pick card and delete from list
        {
            ScriptableCard pickedCard = instance.currentDeckList[Random.Range(0, instance.currentDeckList.Count())];
            instance.currentDeckList.Remove(pickedCard);
            instance.cardCur -= 1;
            return pickedCard;
        }
    }
}
