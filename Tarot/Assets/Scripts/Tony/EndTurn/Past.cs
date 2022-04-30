using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom code for past card activation
public class Past : MonoBehaviour
{
    public EndTurn manager;    

    public void past(GameObject c)
    {
        bool isplayer = c.GetComponent<CardScriptReference>().isplayer;
        int value = c.GetComponent<CardScriptReference>().value;

        //from endTurn:
        GameObject[] lastTurnCards = manager.lastTurnCards;
        PlayerSystemManager PSysMng = manager.PSysMng;
        EnemySystemManager EsysMng = manager.EsysMng;

        bool isEonFirePa = manager.isEonFirePa;
        bool isPonFirePa = manager.isPonFirePa;

        //switch statement for the different effects based off element
        switch (c.GetComponent<CardScriptReference>().elem)
        {
            //increases value of present card
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

                //audio
                manager.audioManager.Play("fire");
                break;

                //reduces value of future card for enemy and deals damage = to the reduced amount. most of the code is on FutureDamage to not over-crowd the switch statement
            case "air":
                if (isplayer == true)
                {
                    int futdmg = FutureDamage(lastTurnCards[7]);
                    int passingVal = futdmg - value;

                    //passingVal bigger than value, most common one.
                    if (passingVal > 0)
                    {
                        lastTurnCards[7].GetComponent<CardScriptReference>().value -= value / 2;//all future cards are value*2
                        EsysMng.TakeAirDmg(value);
                    }

                    //the two values are =, for example air 6 in the past against a fire 3
                    if (passingVal == 0)
                    {
                        lastTurnCards[7].GetComponent<CardScriptReference>().value = 0;
                        EsysMng.TakeAirDmg(value);
                    }

                    //the air value is > that 2x the enemies future value. for example an air 10 against a fire 2. The damage it will deal will be 4
                    if (passingVal < 0)
                    {
                        lastTurnCards[7].GetComponent<CardScriptReference>().value = 0;
                        EsysMng.TakeAirDmg(-passingVal);
                    }
                }

                else
                {
                    int futdmg = FutureDamage(lastTurnCards[6]);
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
                manager.audioManager.Play("wind");
                break;

                //gives shields = to the value
            case "earth":
                if (isplayer == true)
                {
                    PSysMng.HealSH(value);
                }
                else
                {
                    EsysMng.HealSH(value);
                }
                manager.audioManager.Play("shielding");
                break;

                //same as air, but for the enemy present card instead of future, simplifying the code
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

                    if (isPonFirePa == false)//fire prevents heals in the same moment (fire in past prevents water from healing in the past)
                        PSysMng.HealHP(finalDmg / 2);//all water cards heal for half the damage they deal

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
                manager.audioManager.Play("water");
                break;
                //plays a court card
            case "court":
                {
                    court(c);
                    break;
                }
        }
    }

    //this gets used by air cards 
    public int FutureDamage(GameObject c)
    {
        int damage;
        int value = c.GetComponent<CardScriptReference>().value;

        if (c.GetComponent<CardScriptReference>().elem == "earth")
            damage = 0;//if it's earth it will get countered, and the full damage of the air card will pass through
        else
            damage = 2 * value;

        return damage;
    }

    //if court card play this, runs through past function twice.
    private void court(GameObject court)
    {
        int originalValue = court.GetComponent<CardScriptReference>().value;
        court.GetComponent<CardScriptReference>().value = court.GetComponent<CardScriptReference>().value / 2; //only need to change once

        //element 1
        court.GetComponent<CardScriptReference>().elem = court.GetComponent<CardScriptReference>().court1;//temp edit to wlwm
        manager.courtbuff.buff(court);//check for elemental buffing
        past(court);//activate script as usual
        manager.courtbuff.debuff(court);//remove elemental buff if it happened
        
        //element 2
        court.GetComponent<CardScriptReference>().elem = court.GetComponent<CardScriptReference>().court2;
        manager.courtbuff.buff(court);
        past(court);
        //here no need to run debuff, returning the val to original is more than enough

        //return stuff to original
        court.GetComponent<CardScriptReference>().value = originalValue;
        court.GetComponent<CardScriptReference>().elem = "court";
    }
}