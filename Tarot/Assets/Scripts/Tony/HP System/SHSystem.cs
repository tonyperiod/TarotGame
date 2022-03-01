using System;

public class SHSystem
{
    private int sh;
    private int shMax;

    public event EventHandler onSHChanged;

    public SHSystem(int shMax)
    {
        this.shMax = shMax;
        sh = shMax;
    }

    public int getSH()
    {
        return sh;
    }

    public float getSHPercent()
    {
        return (float)sh / shMax;
    }

    public void dmgSh(int dAmount)
    {

        sh -= dAmount;
        if (sh < 0)
        {
            damageSpillOver(-sh); //damage spills over to hp
            sh = 0;
        }

        //event handler activate
        if (onSHChanged != null)
            onSHChanged(this, EventArgs.Empty);
    }

    public void healSh(int hAmount)
    {
        sh += hAmount;
        if (sh > shMax)
            sh = shMax;

        //event handler activate
        if (onSHChanged != null)
            onSHChanged(this, EventArgs.Empty);
    }

    public void damageSpillOver(int dmg)
    {

    }

}


