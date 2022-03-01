using System;

public class HPSystem
{
    private int hp;
    private int hpMax;

    public event EventHandler onHPChanged;
             
    public HPSystem(int hpMax)
    {
        this.hpMax = hpMax;
        hp = hpMax;
    }

    public int getHP()
    {
        return hp;
    }

    public float getHPPercent()
    {
        return (float) hp / hpMax;        
    }

    public void dmghp(int dAmount)
    {
        hp -= dAmount;
        if (hp < 0)
            hp = 0;


        //event handler activate
        if (onHPChanged != null)
            onHPChanged(this, EventArgs.Empty);
    }

    public void healhp(int hAmount)
    {
        hp += hAmount;
        if (hp > hpMax)
            hp = hpMax;


        //event handler activate
        if (onHPChanged != null)
            onHPChanged(this, EventArgs.Empty);
    }

}
