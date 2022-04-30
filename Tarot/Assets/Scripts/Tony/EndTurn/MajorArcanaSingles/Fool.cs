using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom script
//shuffles activated cards
public class Fool : MonoBehaviour
{
    [SerializeField] EndTurn manager;

public void Activate(GameObject c, bool isPlayer)
    {
        GameObject c1 = manager.lastTurnCards[0];//default assigned value
        GameObject c2 = manager.lastTurnCards[0];
        GameObject c3 = manager.lastTurnCards[0];
        List<int> listPos = new List<int>();

        int slot = 0;//default, slot for creating dummy

        if (isPlayer == true)
        {
            c1 = manager.lastTurnCards[3];
            c2 = manager.lastTurnCards[4];
            c3 = manager.lastTurnCards[5];
            //set array of pos
            int[] posTemp = { 3, 4, 5 };
            listPos.AddRange(posTemp);

            slot = 9;//for destroy
        }
        else
        {
            c1 = manager.lastTurnCards[0];
            c2 = manager.lastTurnCards[1];
            c3 = manager.lastTurnCards[2];

            int[] posTemp = { 0, 1, 2 };
            listPos.AddRange(posTemp);

            slot = 11;
        }

        GameObject[] cards = { c1, c2, c3 };//array of cards

        //giving random locations
        for (int i = 0; i < 3; i++)
        {
            int randomVal = Random.Range(0, listPos.Count);
            int chosenSlot = listPos[randomVal];

            //move to the position with changed slot
            cards[i].GetComponent<CardScriptReference>().slot = chosenSlot;
            cards[i].transform.position = manager.pos[chosenSlot].transform.position;

            //remove chosen slot
            listPos.Remove(chosenSlot);
        }
        //redifine the order, bugfix
        manager.cardeffects.get();

        //destroy the card
        GameObject.Destroy(c);

        //create new dummy
        manager.MajorDummy.Create(slot);
    }
}
