using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom script
//this script is just to move the major arcana from inactive to active
public class MajorSwitch : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    public void majorSwitch(GameObject c, bool isPlayer)
    {
        int slot;//slot to move to

        if (isPlayer == true)
            slot = 9;
        else
            slot = 11;


        //destroy dummy/major arcana in that location, and trigger majordestroy if it is
        if (manager.lastTurnCards[slot].GetComponent<CardScriptReference>().court1 == "major")
            manager.MajorDestroy.Destroy(c, isPlayer);
        GameObject.Destroy(manager.lastTurnCards[slot]);

        //move into position
        c.transform.position = manager.pos[slot].transform.position;
        c.GetComponent<CardScriptReference>().slot = slot;

        //create new dummy in the slot this was in
        manager.MajorDummy.Create(slot - 1);
    }
}