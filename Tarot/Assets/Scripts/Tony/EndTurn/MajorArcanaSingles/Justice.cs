using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Justice : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    int hpP, hpE, shP, shE;


    public void Activate(GameObject c, bool isPlayer)
    {
        PlayerSystemManager PSysMng = manager.PSysMng;
        EnemySystemManager ESysMng = manager.EsysMng;

        //get all the ints
        hpP = PSysMng.hpsyst.getHP();
        hpE = ESysMng.hpsyst.getHP();
        shP = PSysMng.shsystem.getSH();
        shE = ESysMng.shsystem.getSH();

        //get the lower value between the two, and set the lower = to it
        if (hpP > hpE)
            PSysMng.TakeAirDmg(hpP - hpE);//make it's hp = to enemies
        else
            ESysMng.TakeAirDmg(hpE - hpP);//if difference 0, nothing happens
        if (shP > shE)
            PSysMng.TakeDamage(shP - shE);
        else
            ESysMng.TakeDamage(shE - shP);


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