using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighPriestess : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    public void Activate(GameObject c, bool isPlayer)
    {

    }

    public void Destroyed(GameObject c, bool isPlayer)
    {
        //remove bool of player
    }
}
