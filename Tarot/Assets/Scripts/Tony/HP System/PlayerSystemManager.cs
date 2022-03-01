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


    void Start()
    {
        
        //set max values
        refHpMax = reference.GetComponent<PlayerReference>().maxHP;        
        HPSystem hpsyst = new HPSystem(refHpMax);

        refShMax = reference.GetComponent<PlayerReference>().maxSH;
        SHSystem shsyst = new SHSystem(refShMax);
 
        //set up bars
        Bar.SetupHp(hpsyst);
        hpsyst.dmghp(10);//TESTING

        Bar.SetupSh(shsyst);
        shsyst.dmgSh(5);        
    }


}
