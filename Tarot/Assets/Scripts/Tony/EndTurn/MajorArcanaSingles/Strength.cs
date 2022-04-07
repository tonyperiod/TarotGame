using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strength : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    public void Activate(GameObject c, bool isPlayer)
    {
        List<int> listPos = new List<int>();
        int slot = 0;//default, slot for creating dummy

        if (isPlayer == true)
        {
            //set array of pos of playercards
            int[] posTemp = { 0, 1, 6 };//no future only pastfuture as the player would not understand
            listPos.AddRange(posTemp);

            slot = 9;//for destroy

        }
        else
        {
            int[] posTemp = { 3, 4, 7 };
            listPos.AddRange(posTemp);

            slot = 11;
        }

        //double the values
        for (int i = 0; i < listPos.Count; i++)
        {
            manager.lastTurnCards[listPos[i]].GetComponent<CardScriptReference>().value *= 2;
        }


        //destroy the card
        GameObject.Destroy(c);

        //create new dummy
        manager.MajorDummy.Create(slot);
    }
}
