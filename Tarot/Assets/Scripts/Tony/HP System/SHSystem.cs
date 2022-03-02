using System;

public class SHSystem
{
    private int sh;
    private int shMax;

    public event EventHandler onSHChanged;


    public SHSystem(int shMax)
    {
        this.shMax = shMax;
        sh = 0;
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
    

}
