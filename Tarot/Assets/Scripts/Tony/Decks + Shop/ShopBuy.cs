using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBuy : MonoBehaviour
{
    [SerializeField] Shop manager;

    private GameObject buyedCard;
    //called by ShopOnClick, pretty straightforward add to list
    public void Buy()
    {
        getAllCardsInGame();
        //get the card in the "buy" slot
        for (int i = 0; i < manager.buyableCards.Length; i++)
        {
            if (manager.buyableCards[i].GetComponent<ShopCardScriptReference>().slot == 5)
            {
                buyedCard = manager.buyableCards[i];
                break;
            }
        }

        manager.playerCurrentDatabase.allCards.Add(buyedCard.GetComponent<ShopCardScriptReference>().cardData);//add the scriptable card to it
        //remove from alldataingame
        manager.shopAllDataInGame.allCards.Remove(buyedCard.GetComponent<ShopCardScriptReference>().cardData);//remove from the shop database 
        manager.SplitterActivate();//for the next round of shop
    }

    //these are the cards that are currently on the shop table
    public void getAllCardsInGame()
    {
        GameObject[] inGame = GameObject.FindGameObjectsWithTag("Card");
        manager.buyableCards = inGame;
    }
}
