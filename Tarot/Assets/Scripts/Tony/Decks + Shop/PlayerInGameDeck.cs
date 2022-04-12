using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


//this script is to create the database in game, and have only 1 of it. This is basically the Deck

public class PlayerInGameDeck : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    public ScriptableCardDatabase playerDatabase; //to slot in player database
    private static PlayerInGameDeck instance; //this database 
    public List<ScriptableCard> currentDeckList; //this Deck list

    private float cardTot;
    private float cardCur;


    public void CustomAwake()
    {
        if (instance == null)
        {
            instance = this;
            //    DontDestroyOnLoad(gameObject);//to make sure that it never gets destroyed from game start
        }
        //else
        //{
        //    Destroy(gameObject); //if there is already a playerdatabase in game
        //}
        cardTot = instance.playerDatabase.allCards.Count;

        ReorderDeck();
        NewDeck();
    }

    //to make sure everything works after buying and all
    private void ReorderDeck()
    {
        for (int i = 0; i < instance.playerDatabase.allCards.Count; i++)
        {
            instance.playerDatabase.allCards[i].id = i;
        }
    }

    public void NewDeck() //this pure jank is to load in all the cards to the in game deck
    {
        instance.currentDeckList.Clear(); //empty out deck

        for (int i = 0; i < instance.playerDatabase.allCards.Count; i++) //add back in all the cards from the player owned database one by one
        {
            instance.currentDeckList.Add(GetCardByID(i));
        }

        cardCur = cardTot;
    }



    public static ScriptableCard GetCardByID(int ID) // get in all the cards
    {
        return instance.playerDatabase.allCards[ID]; //returns first instance that matches true, or default (null)
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
