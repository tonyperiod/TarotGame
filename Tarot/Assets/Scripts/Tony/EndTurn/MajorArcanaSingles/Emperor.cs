using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//custom script
//substitutes all other players cards with dummies
public class Emperor : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    public void Activate(GameObject c, bool isPlayer)
    {
        List<int> listPos = new List<int>();
        int slot = 0;//default, slot for creating dummy

        if (isPlayer == true)
        {
            //set array of pos
            int[] posTemp = { 3, 4, 5, 7 };//different between player and enemy activations, so that the for loop is lighter
            listPos.AddRange(posTemp);

            slot = 9;//for destroy

        }
        else
        {
            int[] posTemp = { 0, 1, 2, 6 };
            listPos.AddRange(posTemp);

            slot = 11;
        }

        //substitute cards with dummies
        for (int i = 0; i < listPos.Count; i++)
        {
            manager.MajorDummy.Substitute(listPos[i]);
        }

        //destroy the card
        GameObject.Destroy(c);

        //create new dummy
        manager.MajorDummy.Create(slot);
    }
}
