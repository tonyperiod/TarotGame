using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empress : MonoBehaviour
{
    [SerializeField] EndTurn manager;
    PlayerSystemManager PSysMng;
    EnemySystemManager EsysMng;

    //two different ones in case both players have it active at the same time
    [SerializeField] int turnsActivatedP;
    [SerializeField] int turnsActivatedE;


    public void Activate(GameObject c, bool isPlayer)
    {
        //sys managers 
        PlayerSystemManager PSysMng = manager.PSysMng;
        EnemySystemManager EsysMng = manager.EsysMng;

        if (isPlayer == true)
        {
            turnsActivatedP += 5;
            PSysMng.HealSH(turnsActivatedP);
        }
        else
        {
            turnsActivatedE += 5;
            EsysMng.HealSH(turnsActivatedE);
        }
    }

    public void Destroyed(GameObject c, bool isPlayer)
    {
        //to make sure it works with 2 of same in scene
        if (isPlayer == true)
            turnsActivatedP = 0;
        else
            turnsActivatedE = 0;
    }
}