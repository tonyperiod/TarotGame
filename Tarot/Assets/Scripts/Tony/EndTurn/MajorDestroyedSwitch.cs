using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//custom script
//some major arcana have effects that play when they are destroyed (mainly terminating their effects), so this script exists to activate them
// I left all the cases, to have more flexibility with development also in the future
public class MajorDestroyedSwitch : MonoBehaviour
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


    public void Destroy(GameObject c, bool isPlayer)
    {
        //activate subscripts, ONLY WHEN NECESSARY
        switch (c.GetComponent<CardScriptReference>().value)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                highPriestess.Destroyed(c, isPlayer);
                break;
            case 3:
                empress.Destroyed(c, isPlayer);
                break;
            case 4:
                break;
            case 5://no saved vals on hiero
                break;
            case 6://lovers
                lovers.Destroyed(c, isPlayer);
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                hermit.Destroyed(c, isPlayer);
                break;
            case 10:
                break;
            case 11:
                break;
            case 12://no saved vals on hanged
                break;
            case 13:
                break;
            case 14:
                temperance.Destroyed(c, isPlayer);
                break;
            case 15:
                break;
            case 16:
                break;
            case 17:
                break;
            case 18:
                moon.Destroyed(c, isPlayer);
                break;
            case 19:
                break;
            case 20:
                break;
            case 21:
                world.Destroyed(c, isPlayer);
                break;
        }
    }
}