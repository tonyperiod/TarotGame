using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBuy : MonoBehaviour
{
    [SerializeField] Shop manager;

    private GameObject buyedCard;
    public void Buy()
    {
        for (int i = 0; i < manager.buyableCards.Length; i++)
        {
            if (manager.buyableCards[i].GetComponent<ShopCardScriptReference>().slot == 5)
            {
                buyedCard = manager.buyableCards[i];
                break;
            }
        }

        manager.playerCurrentDatabase.allCards.Add(buyedCard.GetComponent<ShopCardScriptReference>().cardData);//ad the scriptable card to it
        //remove from alldataingame
        manager.shopAllDataInGame.allCards.Remove(buyedCard.GetComponent<ShopCardScriptReference>().cardData);
        manager.SplitterActivate();
    }
}
