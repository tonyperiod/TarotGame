using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom script
//prevents counters to pastfuture
public class HighPriestess : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    public void Activate(GameObject c, bool isPlayer)
    {
        //this  bool influences pastFuture
        if (isPlayer == true)
            manager.isHighP = true;
        else
            manager.isHighE = true;
    }

    //allows counters to happen again
    public void Destroyed(GameObject c, bool isPlayer)
    {
        //remove bool of player
        if (isPlayer == true)
            manager.isHighP = false;
        else
            manager.isHighE = false;
    }
}