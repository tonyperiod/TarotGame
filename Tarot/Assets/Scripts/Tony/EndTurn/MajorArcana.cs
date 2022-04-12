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
        //delete dummy is in switch
        //activate subscripts
        switch (c.GetComponent<CardScriptReference>().value)
        {
            case 0:
                fool.Activate(c, isPlayer);
                break;
            case 1:
                magician.Activate(c, isPlayer);
                break;
            case 2:
                highPriestess.Activate(c, isPlayer);
                break;
            case 3:
                empress.Activate(c, isPlayer);
                break;
            case 4:
                emperor.Activate(c, isPlayer);
                break;
            case 5:
                hierophant.Activate(c, isPlayer);
                break;
            case 6:
                lovers.Activate(c, isPlayer);
                break;
            case 7:
                chariot.Activate(c, isPlayer);
                break;
            case 8:
                strength.Activate(c, isPlayer);
                break;
            case 9:
                hermit.Activate(c, isPlayer);
                break;
            case 10:
                wheelOfFortune.Activate(c, isPlayer);
                break;
            case 11:
                justice.Activate(c, isPlayer);
                break;
            case 12:
                hangedMan.Activate(c, isPlayer);
                break;
            case 13:
                death.Activate(c, isPlayer);
                break;
            case 14:
                temperance.Activate(c, isPlayer);
                break;
            case 15:
                devil.Activate(c, isPlayer);
                break;
            case 16:
                tower.Activate(c, isPlayer);
                break;
            case 17:
                star.Activate(c, isPlayer);
                break;
            case 18:
                moon.Activate(c, isPlayer);
                break;
            case 19:
                sun.Activate(c, isPlayer);
                break;
            case 20:
                judgement.Activate(c, isPlayer);
                break;
            case 21:
                world.Activate(c, isPlayer);
                break;
        }
    }
}
