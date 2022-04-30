using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystemManager : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    //getting all the data
    public GameObject reference;
    public int refHpMax;
    public int refShMax;

    //getting all the bars
    public BarsPlayer Bar;

    //to do GET ALL THE DATA

    public HPSystem hpsyst;
    public SHSystem shsystem;

    public OnDeath dead;

    //major arcana trickery
    public bool isLovers;
    public bool isHermit;

    void Start()
    {
        //set max values
        refHpMax = reference.GetComponent<PlayerReference>().maxHP;
        hpsyst = new HPSystem(refHpMax);

        refShMax = reference.GetComponent<PlayerReference>().maxSH;
        shsystem = new SHSystem(refShMax);

        //set up bars
        Bar.SetupHp(hpsyst);
        Bar.SetupSh(shsystem);

        //null out major arcana stuff (to make sure)
        isLovers = false;
        isHermit = false;
    }

    public void TakeDamage(int dmg)
    {
        int remainingSh;
        remainingSh = shsystem.getSH() - dmg;
        //Debug.Log("dmg" + dmg);

        if (remainingSh > 0)
        {
            shsystem.dmgSh(dmg);
        }

        //this way I get the damage pass in
        else
        {
            shsystem.dmgSh(dmg);
            if (isHermit == false)//hermit blocks hp dmg
                hpsyst.dmghp(-remainingSh);
        }

        checkIfDead();
    }

    public void TakeAirDmg(int dmg)
    {
        if (isHermit == false)//hermit blocks hp dmg
            hpsyst.dmghp(dmg);
        //Debug.Log("air" + dmg);
        checkIfDead();
    }

    public void HealHP(int heal)
    {
        hpsyst.healhp(heal);
        //Debug.Log("heal" + heal);
    }

    public void HealSH (int shield)
    {
        if (isLovers == false)
            shsystem.healSh(shield);
        //Debug.Log("healshield" + shield);
    }

    public void checkIfDead()
    {
        if (hpsyst.getHP() == 0)
        {
            manager.audioManager.Play("lose");
            dead.dead();
        }
    }
}
