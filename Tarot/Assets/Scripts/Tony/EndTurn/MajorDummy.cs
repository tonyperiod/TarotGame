using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//custom script
//I created this script mainly to prevent the lastturncards from breaking, and maintaining always 12 cards in game at all times. 
//Using the "dummy" word I'm also able to disable cards at will
public class MajorDummy : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    public void Create(int slot)
    {
        manager.cardPrefab.tag = "Card";

        //set to dummy so that it won't trigger the card effects
        manager.cardPrefab.GetComponent<CardScriptReference>().cardData = manager.dummy;
        manager.cardPrefab.GetComponent<CardScriptReference>().slot = slot;

        //to fix bugs when creating for non major cards
        int instanceSlot = slot - 8;
        if (instanceSlot < 0)
            instanceSlot = 0;

        //instantiate in position slot, slot - 8 to use dummySlots effectivly
        Instantiate(manager.cardPrefab, manager.dummySlots[instanceSlot].transform.position, manager.dummySlots[instanceSlot].transform.rotation);

        manager.cardPrefab.tag = "Untagged";
    }

    //there was a lot of deleting dummies, so I created this to simplify other scripts
    public void Delete(int slot)
    {
        GameObject.Destroy(manager.lastTurnCards[slot]);
    }

    //to deactivate a certain card
    public void Substitute (int slot)
    {
        manager.lastTurnCards[slot].GetComponent<CardScriptReference>().elem = "dummy";
        manager.lastTurnCards[slot].GetComponent<CardScriptReference>().spRend.sprite = manager.dummy.artWork;
        manager.lastTurnCards[slot].GetComponent<CardScriptReference>().court1 = "dummy";
    }
}