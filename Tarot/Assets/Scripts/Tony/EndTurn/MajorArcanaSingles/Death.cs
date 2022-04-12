using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    public void Activate(GameObject c, bool isPlayer)
    {
        PlayerSystemManager PSysMng = manager.PSysMng;
        EnemySystemManager ESysMng = manager.EsysMng;

        if (isPlayer == true)
            ESysMng.TakeAirDmg(ESysMng.hpsyst.getHP() - 1);
        else
            PSysMng.TakeAirDmg(PSysMng.hpsyst.getHP() - 1);

        //destroy the card
        GameObject.Destroy(c);

        //create new dummy
        int slot = 0;
        if (isPlayer == true)
            slot = 9;
        else
            slot = 11;
        manager.MajorDummy.Create(slot);
    }
}