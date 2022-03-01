using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystemManager : MonoBehaviour
{
    //getting all the data
    public GameObject reference;
    private int refHpMax;

    //getting all the bars
    public BarsEnemy barContainer;

    //to do GET ALL THE DATA


    void Start()
    {
        //set max hp
        refHpMax = reference.GetComponent<EnemyReference>().maxHP;
        HPSystem hpsyst = new HPSystem(refHpMax);

        //set up bars
        barContainer.SetupHp(hpsyst);

        Debug.Log(hpsyst.getHP());
        hpsyst.dmghp(30);

    }


}
