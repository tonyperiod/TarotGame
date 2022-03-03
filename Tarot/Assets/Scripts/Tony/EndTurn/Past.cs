using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Past : MonoBehaviour
{
    //refer to parent manager script
    [SerializeField] EndTurnManager manager;
    GameObject[] lastTurnCards;
    bool isEonFirePa, isPonFirePa;

    PlayerSystemManager PSysMng;
    EnemySystemManager EsysMng;

    public void past(GameObject c)
    {
        //get references here so they're updated for sure
        bool isplayer = c.GetComponent<CardScriptReference>().isplayer;
        int value = c.GetComponent<CardScriptReference>().value;


        bool isEonFirePa = manager.isEonFirePa;
        bool isPonFirePa = manager.isPonFirePa;

        PSysMng = manager.PSysMng;
        EsysMng = manager.EsysMng;

        lastTurnCards = manager.lastTurnCards;
        


        switch (c.GetComponent<CardScriptReference>().symbol)
        {
            case "fire":
                if (isplayer == true)
                {
                    lastTurnCards[1].GetComponent<CardScriptReference>().value += value;
                    isEonFirePa = true;
                }
                else
                {
                    lastTurnCards[4].GetComponent<CardScriptReference>().value += value;
                    isPonFirePa = true;
                }

                break;


            case "air":
                if (isplayer == true)
                {//comparing
                    int futdmg = FutureDamage(lastTurnCards[7]);
                    int passingDmg = futdmg - value;

                    //dmg bigger than value, most common one. here just using value works fine
                    if (passingDmg > 0)
                    {
                        lastTurnCards[7].GetComponent<CardScriptReference>().value -= value / 2;
                        EsysMng.TakeAirDmg(value);
                    }

                    if (passingDmg == 0)
                    {
                        lastTurnCards[7].GetComponent<CardScriptReference>().value = 0;
                        EsysMng.TakeAirDmg(value);
                    }

                    if (passingDmg < 0)
                    {
                        lastTurnCards[7].GetComponent<CardScriptReference>().value = 0;
                        EsysMng.TakeAirDmg(-passingDmg);
                    }
                }

                else
                {
                    int futdmg = FutureDamage(manager.lastTurnCards[6]);
                    int passingDmg = futdmg - value;

                    //dmg bigger than value, most common one. here just using value works fine
                    if (passingDmg > 0)
                    {
                        lastTurnCards[6].GetComponent<CardScriptReference>().value -= value / 2;
                        PSysMng.TakeAirDmg(value);
                    }

                    if (passingDmg == 0)
                    {
                        lastTurnCards[6].GetComponent<CardScriptReference>().value = 0;
                        PSysMng.TakeAirDmg(value);
                    }

                    if (passingDmg < 0)
                    {
                        lastTurnCards[6].GetComponent<CardScriptReference>().value = 0;
                        PSysMng.TakeAirDmg(-passingDmg);
                    }
                }

                break;


            case "earth":
                if (isplayer == true)
                {
                    PSysMng.HealSH(value);
                }
                else
                {
                    EsysMng.HealSH(value);
                }

                break;


            case "water":
                if (isplayer == true)
                {
                    int predmg = lastTurnCards[4].GetComponent<CardScriptReference>().value;
                    int passingDmg = predmg - value;
                    int finalDmg = value; // this is for the heal to happen even on passingdmg <0

                    //dmg bigger than value, most common one. here just using value works fine
                    if (passingDmg > 0)
                    {
                        lastTurnCards[4].GetComponent<CardScriptReference>().value = passingDmg;
                        EsysMng.TakeDamage(finalDmg);
                    }

                    if (passingDmg == 0)
                    {
                        lastTurnCards[7].GetComponent<CardScriptReference>().value = 0;
                        EsysMng.TakeDamage(finalDmg);
                    }

                    if (passingDmg < 0)
                    {
                        lastTurnCards[7].GetComponent<CardScriptReference>().value = 0;
                        finalDmg = value - predmg;
                        EsysMng.TakeDamage(finalDmg);
                    }

                    if (isPonFirePa == false)
                        PSysMng.HealHP(finalDmg / 2);

                }

                else
                {
                    int predmg = lastTurnCards[1].GetComponent<CardScriptReference>().value;
                    int passingDmg = predmg - value;
                    int finalDmg = value; // this is for the heal to happen even on passingdmg <0

                    //dmg bigger than value, most common one. here just using value works fine
                    if (passingDmg > 0)
                    {
                        lastTurnCards[1].GetComponent<CardScriptReference>().value = passingDmg;
                        PSysMng.TakeDamage(finalDmg);
                    }

                    if (passingDmg == 0)
                    {
                        lastTurnCards[1].GetComponent<CardScriptReference>().value = 0;
                        PSysMng.TakeDamage(finalDmg);
                    }

                    if (passingDmg < 0)
                    {
                        lastTurnCards[1].GetComponent<CardScriptReference>().value = 0;
                        finalDmg = value - predmg;
                        PSysMng.TakeDamage(finalDmg);
                    }

                    if (isEonFirePa == false)
                        EsysMng.HealHP(finalDmg / 2);
                }
                break;
        }

        GameObject.Destroy(c);
    }

    private int FutureDamage(GameObject c)
    {
        int damage;
        int value = c.GetComponent<CardScriptReference>().value;

        switch (c.GetComponent<CardScriptReference>().symbol)
        {
            case "fire":
                damage = 2 * value;
                break;


            case "air":
                damage = 2 * value;
                break;

            default:
                damage = 0;
                break;
        }

        return damage;
    }
}
