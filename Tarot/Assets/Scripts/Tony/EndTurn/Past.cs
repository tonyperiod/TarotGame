using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Past : MonoBehaviour
{
    public EndTurn manager;
    
    //court part
    bool isCourt;

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

        switch (c.GetComponent<CardScriptReference>().elem)
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

                //audio
                manager.audioManager.Play("fire");
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
                manager.audioManager.Play("water");
                break;

            case "court":
                {
                    isCourt = true;
                    court(c);
                    break;
                }
        }

        //court cards not destroyed first round
        //destroy in endturneffects instead
        //if (isCourt == false)
        //    GameObject.Destroy(c);
    }

    //this gets used by air cards 
    public int FutureDamage(GameObject c)
    {
        int damage;
        int value = c.GetComponent<CardScriptReference>().value;

        switch (c.GetComponent<CardScriptReference>().elem)
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

    //if court card play this, runs through past function twice. Will call double counter later.
    private void court(GameObject court)
    {
        int originalValue = court.GetComponent<CardScriptReference>().value;
        court.GetComponent<CardScriptReference>().value = court.GetComponent<CardScriptReference>().value / 2; //only need to change once

        //element 1
        court.GetComponent<CardScriptReference>().elem = court.GetComponent<CardScriptReference>().court1;//temp edit to wlwm
        manager.courtbuff.buff(court);//check for elemental buffing
        past(court);//activate script as usual
        manager.courtbuff.debuff(court);//remove elemental buff if it happened
        
        //set isCourt so it will be destroyed
        isCourt = false;

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