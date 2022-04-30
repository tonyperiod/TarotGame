using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//custom script

public class Tower : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    public void Activate(GameObject c, bool isPlayer)
    {
        PlayerSystemManager PSysMng = manager.PSysMng;
        EnemySystemManager ESysMng = manager.EsysMng;

        //get to 10hp 0 shields, take air damage deals damage only to hp
        PSysMng.TakeAirDmg(PSysMng.hpsyst.getHP() - 10);
        ESysMng.TakeAirDmg(ESysMng.hpsyst.getHP() - 10);
        PSysMng.TakeDamage(PSysMng.shsystem.getSH());
        ESysMng.TakeDamage(ESysMng.shsystem.getSH());

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
