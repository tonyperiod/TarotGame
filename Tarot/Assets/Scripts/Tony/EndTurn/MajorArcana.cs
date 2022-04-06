using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajorArcana : MonoBehaviour
{
    [SerializeField] EndTurn manager;
    public Fool fool;
    public Magician magician;
    public HighPriestess highPriestess;
    public Empress empress;
    public Emperor emperor;
    public Hierophant hierophant;
    public Lovers lovers;
    public Chariot chariot;
    public Strength strength;
    public Hermit hermit;
    public WheelOfFortune wheelOfFortune;
    public Justice justice;
    public HangedMan hangedMan;
    public Death death;
    public Temperance temperance;
    public Devil devil;
    public Tower tower;
    public Star star;
    public Moon moon;
    public Sun sun;
    public Judgement judgement;
    public World world;


    public void major(GameObject c, bool isPlayer)
    {
        //activate subscripts
        switch (c.GetComponent<CardScriptReference>().value)
        {
            case 0:
                fool.Activate(c, isPlayer);
                break;
            case 3:
                empress.Activate(c, isPlayer);
                break;
        }
    }
}
