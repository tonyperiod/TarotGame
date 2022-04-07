using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    [SerializeField] EndTurn manager;
    PlayerSystemManager PSysMng;
    EnemySystemManager ESysMng;

    //two different ones in case both players have it active at the same time
    [SerializeField] bool isHealP;
    [SerializeField] bool isHealE;
    private int val;

    private void Start()
    {
        isHealE = true;
        isHealP = true;
        val = 15;
    }

    public void Activate(GameObject c, bool isPlayer)
    {
        //sys managers 
        PlayerSystemManager PSysMng = manager.PSysMng;
        EnemySystemManager EsysMng = manager.EsysMng;

        if (isPlayer == true)
        {
            if (isHealP == true)
            {
                PSysMng.HealHP(val);
                isHealP = false;
            }
            else
            {
                EsysMng.TakeDamage(val);
                isHealP = true;
            }
        }
        else
        {
            if (isHealE == true)
            {
                ESysMng.HealHP(val);
                isHealE = false;
            }
            else
            {
                PSysMng.TakeDamage(val);
                isHealE = true;
            }
        }
    }

    public void Destroyed(GameObject c, bool isPlayer)
    {
        //to make sure it works with 2 of same in scene
        if (isPlayer == true)
            isHealP = true;
        else
            isHealE = true;
    }
}
