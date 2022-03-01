using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystemManager : MonoBehaviour
{
    //getting all the data
    public GameObject reference;
    private int refHpMax;
    private int refShMax;

    //getting all the bars
    public BarsPlayer Bar;

    //to do GET ALL THE DATA

    public HPSystem hpsyst;
    public SHSystem shsystem;

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

    }

    public void TakeDamage(int dmg)
    {
        int remainingSh;
        remainingSh = shsystem.getSH() - dmg;

        if (remainingSh>0)
        {
            shsystem.dmgSh(dmg);
        }
        //this way I get the damage pass in
        else
        {
            shsystem.dmgSh(dmg);
            hpsyst.dmghp(-remainingSh);
        }

    }
}
