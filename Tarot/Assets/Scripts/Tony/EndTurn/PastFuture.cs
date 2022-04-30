using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom script
//similar to past and present. The effects here are all straightforward, in past I have more comments explaining everything
//one major difference is the presence of more conditions in the switch statement, to make sure that the counter goes through. With more time I could optimize this script, but it would be unnessessary seeing that it runs very little
public class PastFuture : MonoBehaviour
{
    public EndTurn manager;

    public void pastfuture(GameObject c, bool isCourt)
    {
        Debug.Log("playing past future");
        //from card
        bool isplayer = c.GetComponent<CardScriptReference>().isplayer;
        int value = c.GetComponent<CardScriptReference>().value;

        //from manager
        PlayerSystemManager PSysMng = manager.PSysMng;
        EnemySystemManager EsysMng = manager.EsysMng;

        //remove heal
        bool isEonFireFu = manager.isEonFireFu;
        bool isPonFireFu = manager.isPonFireFu;

        //counter element
        string PElem, EElem, PElemC, EElemC;


        //high priestess countering past future removal
        if (manager.isHighP == false)
        {
            EElem = manager.EElem;
            EElemC = manager.EElemC;
        }
        else
        {
            EElem = "nope";
            EElemC = "nope";
        }

        if (manager.isHighE == false)
        {
            PElem = manager.PElem;
            PElemC = manager.PElemC;
        }
        else
        {
            PElem = "nope";
            PElemC = "nope";
        }

        switch (c.GetComponent<CardScriptReference>().elem)
        {
            case "fire":

                if (isplayer == true && EElem != "water" && EElemC != "water")//check for counters
                {
                    EsysMng.TakeDamage(2 * value);
                    isEonFireFu = true;
                }

                if (isplayer == false && PElem != "water" && PElemC != "water")
                {
                    PSysMng.TakeDamage(2 * value);
                    isEonFireFu = true;
                }

                manager.audioManager.Play("fire");
                break;


            case "air":

                if (isplayer == true && EElem != "earth" && EElemC != "earth")
                {
                    EsysMng.TakeAirDmg(2 * value);
                }

                if (isplayer == false && EElem != "earth" && EElemC != "earth")
                {
                    PSysMng.TakeAirDmg(2 * value);
                }

                manager.audioManager.Play("wind");
                manager.audioManager.Play("sword");
                break;


            case "earth":
                if (isplayer == true && EElem != "air" && EElemC != "air")
                {
                    PSysMng.HealSH(2 * value);
                }

                if (isplayer == false && PElem != "air" && PElemC != "air")
                {
                    EsysMng.HealSH(2 * value);
                }

                manager.audioManager.Play("shielding");
                manager.audioManager.Play("water two");
                break;


            case "water":
                if (isplayer == true && isPonFireFu == false && EElem != "fire" && EElemC != "fire")
                {
                    PSysMng.HealHP(2 * value);
                }
                if (isplayer == false && isEonFireFu == false && PElem != "fire" && PElemC != "fire")
                {
                    EsysMng.HealHP(2 * value);
                }
                break;

            case "court":
                {
                    court(c);
                    break;
                }
        }
    }

    //they activate seperately, for now one of the two will always pass.
    private void court(GameObject court)
    {
        int originalValue = court.GetComponent<CardScriptReference>().value;
        court.GetComponent<CardScriptReference>().value = court.GetComponent<CardScriptReference>().value / 2; //only need to change once

        //element 1
        court.GetComponent<CardScriptReference>().elem = court.GetComponent<CardScriptReference>().court1;//temp edit to wlwm
        manager.courtbuff.buff(court);//check for elemental buffing
        pastfuture(court, true);//activate script as usual
        manager.courtbuff.debuff(court);//remove buff


        //element 2
        court.GetComponent<CardScriptReference>().elem = court.GetComponent<CardScriptReference>().court2;
        manager.courtbuff.buff(court);//check for elemental buffing
        pastfuture(court, true);//activate script as usual
        //remove elemental buff if it happened


        //return stuff to original
        court.GetComponent<CardScriptReference>().value = originalValue;
        court.GetComponent<CardScriptReference>().elem = "court";
        GameObject.Destroy(court);
    }
}