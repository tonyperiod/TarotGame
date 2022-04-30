using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom script
//increasing damage per turn
public class Temperance : MonoBehaviour
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
            EsysMng.TakeDamage(turnsActivatedP);
        }
        else
        {
            turnsActivatedE += 5;
            PSysMng.TakeDamage(turnsActivatedE);
        }
    }

    //resets parameters so that if played again starts over
    public void Destroyed(GameObject c, bool isPlayer)
    {
        //to make sure it works with 2 of same in scene
        if (isPlayer == true)
            turnsActivatedP = 0;
        else
            turnsActivatedE = 0;
    }
}
