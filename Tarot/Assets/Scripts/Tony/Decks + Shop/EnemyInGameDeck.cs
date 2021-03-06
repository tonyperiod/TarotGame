using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//custom script
//this script is to create the database in game, and have only 1 of it. This is basically the Deck. Slight differences from player deck
//the game interfaces a lot with this script, as all card picking happens within this

public class EnemyInGameDeck : MonoBehaviour
{
    [SerializeField] EndTurn manager;
    
    public ScriptableCardDatabase enemyDatabaseInGame; //to slot in enemy database
    public EnemyReference enemyRef; //get the deck from here
    private static EnemyInGameDeck instance; //this database 
    public List<ScriptableCard> currentDeckList; //this Deck list

    private float cardTot;
    private float cardCur;


    public void CustomAwake()
    {
        if (instance == null)
        {
            instance = this;
        }
        enemyDatabaseInGame.allCards =  enemyRef.chosenEnemy.deck.allCards;//get the deck connected to the enemy encountered in world
        cardTot = instance.enemyDatabaseInGame.allCards.Count; //have to edit directly the enemydatabase
        ReorderDeck();
        NewDeck();
    }


    //this is to re-assign all id values
    private void ReorderDeck()
    {
        for (int i = 0; i < instance.enemyDatabaseInGame.allCards.Count; i++)
        {
            instance.enemyDatabaseInGame.allCards[i].id = i;
        }
    }


    //this  is to load in all the cards to the in game deck
    public void NewDeck() 
    {
        instance.currentDeckList.Clear(); //empty out deck

        for (int i = 0; i < instance.enemyDatabaseInGame.allCards.Count; i++) //add back in all the cards from the enemy owned database one by one
        {
            instance.currentDeckList.Add(GetCardByID(i));
        }

        cardCur = cardTot;
    }       
    

    public static ScriptableCard GetCardByID(int ID) // get in all the cards
    {
        return instance.enemyDatabaseInGame.allCards[ID]; //returns first instance that matches true, or default (null)
    }


    public static ScriptableCard PickCard() // get random card

    {
        if (instance.cardCur < 1) //draw cards then do the normal stuff
        {
            instance.NewDeck();

            ScriptableCard pickedCard = instance.currentDeckList[Random.Range(0, instance.currentDeckList.Count())];

            //check for major arcana when needed, and try to get another card in that case
            if (instance.manager.playerMajorActivation != 0 && pickedCard.court1 == "major")
            {
                //do while so it will play at least once, and check after
                do
                {
                    pickedCard = instance.currentDeckList[Random.Range(0, instance.currentDeckList.Count())];
                }
                while (pickedCard.court1 == "major");
            }

            instance.currentDeckList.Remove(pickedCard);
            instance.cardCur -= 1;

            return pickedCard;
        }

        else //just pick card and delete from list
        {
            ScriptableCard pickedCard = instance.currentDeckList[Random.Range(0, instance.currentDeckList.Count())];
            bool isThereNonMajor = false;

            //check for major arcana when needed, and try to get another card in that case
            if (instance.manager.playerMajorActivation != 0 && pickedCard.court1 == "major")
            {
                //check if there are cards that aren't major in the deck, to prevent do while crash
                for (int i = 0; i < instance.currentDeckList.Count; i++)
                {
                    if (instance.currentDeckList[i].court1 != "major")
                    {
                        isThereNonMajor = true;
                        break;
                    }
                }

                if (isThereNonMajor == true)
                {
                    do
                    {
                        pickedCard = instance.currentDeckList[Random.Range(0, instance.currentDeckList.Count())];
                    }
                    while (pickedCard.court1 == "major");
                }
                //basically repeat pick card with card cur <1, the script will break if not
                else
                {
                    instance.NewDeck();
                    pickedCard = instance.currentDeckList[Random.Range(0, instance.currentDeckList.Count())];

                    //check for major arcana when needed, and try to get another card in that case
                    if (instance.manager.playerMajorActivation != 0 && pickedCard.court1 == "major")
                    {
                        do
                        {
                            pickedCard = instance.currentDeckList[Random.Range(0, instance.currentDeckList.Count())];
                        }
                        while (pickedCard.court1 == "major");
                    }
                }
            }

            instance.currentDeckList.Remove(pickedCard);
            instance.cardCur -= 1;

            return pickedCard;
        }
    }
}
