using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//this script is to create the database in game, and have only 1 of it. This is basically the Deck

public class PlayerDatabase : MonoBehaviour
{
    public ScriptableCardDatabase playerDatabase; //to slot in player database
    private static PlayerDatabase instance; //this database 

    private void Awake()
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
      
    }
    public static ScriptableCard GetCardByID (int ID) // get in all the cards
    {
        return instance.playerDatabase.allCards.FirstOrDefault(i => i.id == ID); //returns first instance that matches true, or default (null)
       

    }

    public static ScriptableCard GetRandomCard() // get random card, this needs to be fixed to reduce the card pool every time
    {
        return instance.playerDatabase.allCards[Random.Range(0, instance.playerDatabase.allCards.Count())]; 
        
    }




}
