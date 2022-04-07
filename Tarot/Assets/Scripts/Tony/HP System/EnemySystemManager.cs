using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystemManager : MonoBehaviour
{
    //getting all the data
    public GameObject reference;
    private int refHpMax;
    private int refShMax;

    //getting all the bars
    public BarsEnemy Bar;

    //to do GET ALL THE DATA
    public HPSystem hpsyst;
    public SHSystem shsystem;

    //trigger win
    public OnWin win;

    void Start()
    {
        //set max values
        refHpMax = reference.GetComponent<EnemyReference>().maxHP;
        hpsyst = new HPSystem(refHpMax);

        refShMax = reference.GetComponent<EnemyReference>().maxSH;
        shsystem = new SHSystem(refShMax);

        //set up bars
        Bar.SetupHp(hpsyst);
        Bar.SetupSh(shsystem);
    }

    // ALL THE DAMAGE FUNCTIONS HERE, SO I CAN HAVE NO ISSUES WITH MULTIPLE HP SYSTEMS

    public void TakeDamage(int dmg)
    {
        int remainingSh;
        remainingSh = shsystem.getSH() - dmg;
        Debug.Log("dmg" + dmg);

        if (remainingSh > 0)
        {
            shsystem.dmgSh(dmg);
        }
        //this way I get the damage pass in
        else
        {
            shsystem.dmgSh(dmg);
            hpsyst.dmghp(-remainingSh);
        }

        checkIfDead();
    }

    public void TakeAirDmg (int dmg)
    {
        hpsyst.dmghp(dmg);
        //Debug.Log("air" + dmg);
        checkIfDead();
    }

    public void HealHP(int heal)
    {
        hpsyst.healhp(heal);
        //Debug.Log("heal" + heal);
    }

    public void HealSH(int shield)
    {
        shsystem.healSh(shield);
        //Debug.Log("shield" + shield);
    }

    public void checkIfDead()
    {
        if (hpsyst.getHP() == 0)
            win.win();
    }
}
