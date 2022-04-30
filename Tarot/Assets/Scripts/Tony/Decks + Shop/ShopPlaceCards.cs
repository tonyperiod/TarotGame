using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//straightforward custom script, copied in from the end turn scripts and modified
public class ShopPlaceCards : MonoBehaviour
{
    [SerializeField] Shop manager;

    public void CustomStart()
    {
        ShopCardScriptReference cardReference = manager.cardPrefab.GetComponent<ShopCardScriptReference>();

        manager.cardPrefab.tag = "Card";

        for (int i = 0; i <5; i++)
        {
            manager.cardPrefab.GetComponent<ShopCardScriptReference>().cardData = manager.buyableCardsScriptableCards[i];
            manager.cardPrefab.GetComponent<ShopCardScriptReference>().slot = i;

            ////finally instantiate
            Instantiate(manager.cardPrefab, manager.pos[i].transform.position, manager.pos[i].transform.rotation);
        }
             
        manager.cardPrefab.tag = "Untagged";

        //set manager deck 
        manager.buyableCards = GameObject.FindGameObjectsWithTag("Card");
    }
}