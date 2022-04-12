using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hierophant : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    public void Activate(GameObject c, bool isPlayer)
    {
        List<int> listPos = new List<int>();
        int highVal = 0;

        if (isPlayer == true)
        {
            //set array of pos of playercards
            int[] posTemp = { 0, 1, 2 };//only future, not pastfuture
            listPos.AddRange(posTemp);


        }
        else
        {
            int[] posTemp = { 3, 4, 5 };
            listPos.AddRange(posTemp);

        }

        //get the highest value
        for (int i = 0; i < listPos.Count; i++)
        {
            if (manager.lastTurnCards[listPos[i]].GetComponent<CardScriptReference>().value > highVal)
                highVal = manager.lastTurnCards[listPos[i]].GetComponent<CardScriptReference>().value;
        }

        //set the values (wip)
        for (int i = 0; i < listPos.Count; i++)
        {
            manager.lastTurnCards[listPos[i]].GetComponent<CardScriptReference>().value = highVal;
        }
    }
}
