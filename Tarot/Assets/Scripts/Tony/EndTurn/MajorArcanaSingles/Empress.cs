using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom script
//increasing shield heals turn by turn
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

    //resets it's values so that next time it's played it'll start over (in case of a longer game)
    public void Destroyed(GameObject c, bool isPlayer)
    {
        //to make sure it works with 2 of same in scene
        if (isPlayer == true)
            turnsActivatedP = 0;
        else
            turnsActivatedE = 0;
    }
}