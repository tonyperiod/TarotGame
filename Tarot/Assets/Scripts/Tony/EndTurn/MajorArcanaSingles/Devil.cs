using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devil : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    [SerializeField] PlayerInGameDeck pDeck;
    [SerializeField] EnemyInGameDeck eDeck;

    List<ScriptableCard> possibleCards;
    List<ScriptableCard> maxValCards;

    List<ScriptableCard> pCards;
    List<ScriptableCard> eCards;

    //for delete
    int slot;

    public void Activate(GameObject c, bool isPlayer)
    {
        pCards = pDeck.playerDatabase.allCards;
        eCards = eDeck.enemyDatabaseInGame.allCards;
        possibleCards = new List<ScriptableCard>();
        maxValCards = new List<ScriptableCard>();

        if (isPlayer == true)
        {
            //get all cards that aren't in player deck
            for (int i = 0; i < eCards.Count; i++)
            {
                if (pCards.Contains(eCards[i]) != false)
                {
                    possibleCards.Add(eCards[i]);
                }
               
            }

            //finding max value
            int maxValTemp = 0;
            for (int i = 0; i < possibleCards.Count; i++)
            {
                if (possibleCards[i].goldVal > maxValTemp)
                    possibleCards[i].goldVal = maxValTemp;
            }

            //remove low value cards
            for (int i = 0; i < possibleCards.Count; i++)
            {
                if (possibleCards[i].goldVal == maxValTemp)
                    maxValCards.Add(possibleCards[i]);
            }

            //get a random card of the list, and add-remove from decks
            int chosenCardInt = Random.Range(0, maxValCards.Count);
            pDeck.playerDatabase.allCards.Add(maxValCards[chosenCardInt]);
            eDeck.enemyDatabaseInGame.allCards.Remove(maxValCards[chosenCardInt]);

            //delete
            slot = 9;
        }
        else
        {
            //enemy version of code

            //get all cards that aren't in player deck
            for (int i = 0; i < pCards.Count; i++)
            {
                if (eCards.Contains(pCards[i]) != false)
                {
                    possibleCards.Add(pCards[i]);
                }
            }

            //finding max value
            int maxValTemp = 0;
            for (int i = 0; i < possibleCards.Count; i++)
            {
                if (possibleCards[i].goldVal > maxValTemp)
                    possibleCards[i].goldVal = maxValTemp;
            }

            //remove low value cards
            for (int i = 0; i < possibleCards.Count; i++)
            {
                if (possibleCards[i].goldVal == maxValTemp)
                    maxValCards.Add(possibleCards[i]);
            }

            //get a random card of the list, and add without removing from decks
            int chosenCardInt = Random.Range(0, maxValCards.Count);
            eDeck.enemyDatabaseInGame.allCards.Add(maxValCards[chosenCardInt]);

            //delete
            slot = 11;
        }

        //destroy the card
        GameObject.Destroy(c);

        //create new dummy
        manager.MajorDummy.Create(slot);
    }
}

