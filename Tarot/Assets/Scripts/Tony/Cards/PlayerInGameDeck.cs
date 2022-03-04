using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


//this script is to create the database in game, and have only 1 of it. This is basically the Deck

public class PlayerInGameDeck : MonoBehaviour
{
    public ScriptableCardDatabase playerDatabase; //to slot in player database

    private static PlayerInGameDeck instance; //this database 

    private float cardTot;
    private float cardCur;

    public List<ScriptableCard> currentPlayerDeckList; //this Deck list

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
        cardTot = instance.playerDatabase.allCards.Count;

        NewDeck();
    }

    public void NewDeck() //this pure jank is to load in all the cards to the in game deck
    {
        instance.currentPlayerDeckList.Clear(); //empty out deck


        for (int i = 0; i < instance.playerDatabase.allCards.Count; i++) //add back in all the cards from the player owned database one by one
        {

            instance.currentPlayerDeckList.Add(GetCardByID(i));

        }
        Debug.Log(currentPlayerDeckList.Count);
        cardCur = cardTot;

        //set all cards to is player
        foreach (var Card in instance.currentPlayerDeckList)
        {
            Card.isPlayer = true;
        }
    }

    public static ScriptableCard GetCardByID(int ID) // get in all the cards
    {
        return instance.playerDatabase.allCards.FirstOrDefault(i => i.id == ID); //returns first instance that matches true, or default (null)

    }

    public static ScriptableCard PickCard() // get random card

    {

        if (instance.cardCur < 1) //draw cards then do the normal stuff
        {
            instance.NewDeck();

            ScriptableCard pickedCard = instance.currentPlayerDeckList[Random.Range(0, instance.currentPlayerDeckList.Count())];

            instance.currentPlayerDeckList.Remove(pickedCard);


            instance.cardCur -= 1;

            return pickedCard;
        }
        else //just pick card and delete from list
        {
            ScriptableCard pickedCard = instance.currentPlayerDeckList[Random.Range(0, instance.currentPlayerDeckList.Count())];

            instance.currentPlayerDeckList.Remove(pickedCard);

            instance.cardCur -= 1;

            return pickedCard;
        }
    }




}
