using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lovers : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    int removedShP;
    int removedShE;

    public void Activate(GameObject c, bool isPlayer)
    {
        PlayerSystemManager PSysMng = manager.PSysMng;
        EnemySystemManager ESysMng = manager.EsysMng;

        if (isPlayer == true)
        {
            //save shield value
            int removedShE = ESysMng.shsystem.getSH();

            //damage all the shields, and block healing
            ESysMng.shsystem.dmgSh(removedShE);
            ESysMng.isLovers = true;
        }
        else
        {
            int removedShP = PSysMng.shsystem.getSH();
            //damage all the shields, and block healing
            PSysMng.shsystem.dmgSh(removedShP);
            PSysMng.isLovers = true;
        }
    }

    public void Destroyed(GameObject c, bool isPlayer)
    {
        PlayerSystemManager PSysMng = manager.PSysMng;
        EnemySystemManager ESysMng = manager.EsysMng;

        //to remove the bool in system manager

        if (isPlayer == true)
        {
            ESysMng.isLovers = false;
            ESysMng.HealSH(removedShE);
        }
        else
        {
            PSysMng.isLovers = false;
            ESysMng.HealSH(removedShP);
        }
    }
}
