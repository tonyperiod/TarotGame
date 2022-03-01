using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarsEnemy : MonoBehaviour
{
    private HPSystem hpsystem;
    public GameObject hpbar;




    public void SetupHp(HPSystem hpsystem)
    {
        this.hpsystem = hpsystem;

        hpsystem.onHPChanged += hpsystem_OnHealthChanged;
    }

    private void hpsystem_OnHealthChanged(object sender, System.EventArgs e)
    {
        hpbar.transform.localScale = new Vector3(hpsystem.getHPPercent(), 1);
    }


}
