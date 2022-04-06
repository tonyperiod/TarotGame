using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajorDummy : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    public void Create(int slot)
    {
        manager.cardPrefab.tag = "Card";

        //set to fire so that it won't trigger the card effects
        manager.cardPrefab.GetComponent<CardScriptReference>().court1 = "dummy";
        manager.cardPrefab.GetComponent<CardScriptReference>().elem = "dummy";
        manager.cardPrefab.GetComponent<CardScriptReference>().slot = slot;

        //instantiate in position slot, slot - 8 to use dummySlots effectivly
        Instantiate(manager.cardPrefab, manager.dummySlots[slot-8].transform.position, manager.dummySlots[slot-8].transform.rotation);

        manager.cardPrefab.tag = "Untagged";
    }

    public void Delete(int slot)
    {
        GameObject.Destroy(manager.lastTurnCards[slot]);
    }
}