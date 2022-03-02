using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarsPlayer : MonoBehaviour
{
    private HPSystem hpsystem;
    public GameObject hpbar;

    private SHSystem shsystem;
    public GameObject shbar;


    public void SetupHp(HPSystem hpsystem)
    {
        this.hpsystem = hpsystem;

        hpsystem.onHPChanged += hpsystem_OnHealthChanged;
    }

    private void hpsystem_OnHealthChanged(object sender, System.EventArgs e)
    {
        hpbar.transform.localScale = new Vector3(hpsystem.getHPPercent(), 1);
    }

    //same thing with shields ------------------------------------------
    public void SetupSh(SHSystem shsystem)
    {
        this.shsystem = shsystem;
        shbar.transform.localScale = new Vector3(shsystem.getSHPercent(), 1); //so it displays correctly at start of game
        shsystem.onSHChanged += shsystem_OnShieldChanged;
    }

    private void shsystem_OnShieldChanged(object sender, System.EventArgs e)
    {
        shbar.transform.localScale = new Vector3(shsystem.getSHPercent(), 1);
    }


}
