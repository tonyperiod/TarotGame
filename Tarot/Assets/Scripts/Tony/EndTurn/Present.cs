using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    public EndTurn manager;

    //court part
    bool isCourtElem;
    bool doNotDestroy;

    public void present(GameObject c)
    {
        //do not destroy court first time
        doNotDestroy = false;
        isCourtElem = false;

        bool isplayer = c.GetComponent<CardScriptReference>().isplayer;
        int value = c.GetComponent<CardScriptReference>().value;

        //from endTurn:
        PlayerSystemManager PSysMng = manager.PSysMng;
        EnemySystemManager EsysMng = manager.EsysMng;

        bool isEonFirePr = manager.isEonFirePr;
        bool isPonFirePr = manager.isPonFirePr;


        switch (c.GetComponent<CardScriptReference>().elem)
        {
            case "fire":
                if (isplayer == true)
                {
                    EsysMng.TakeDamage(value);
                    isEonFirePr = true;
                }
                else
                {
                    PSysMng.TakeDamage(value);
                    isPonFirePr = true;
                }

                break;


            case "air":

                if (isplayer == true)
                    EsysMng.TakeAirDmg(value);
                else
                    PSysMng.TakeAirDmg(value);

                break;


            case "earth":
                if (isplayer == true)
                {
                    EsysMng.TakeDamage(value);
                    PSysMng.HealSH(value / 2);
                }
                else
                {
                    PSysMng.TakeDamage(value);
                    EsysMng.HealSH(value / 2);
                }

                break;


            case "water":
                if (isplayer == true)
                {
                    EsysMng.TakeDamage(value);
                    if (isPonFirePr == false)
                        PSysMng.HealHP(value / 2);

                }
                else
                {
                    PSysMng.TakeDamage(value);
                    if (isEonFirePr == false)
                        EsysMng.HealHP(value / 2);
                }
                break;
            case "court":
                {
                    doNotDestroy = true;
                    court(c);
                    break;
                }
        }
        if (doNotDestroy == false)
            GameObject.Destroy(c);
    }


    private void court(GameObject court)
    {

        int originalValue = court.GetComponent<CardScriptReference>().value;
        court.GetComponent<CardScriptReference>().value = court.GetComponent<CardScriptReference>().value / 2; //only need to change once

        //element 1
        court.GetComponent<CardScriptReference>().elem = court.GetComponent<CardScriptReference>().court1;//temp edit to wlwm
        manager.courtbuff.buff(court);//check for elemental buffing
        present(court);//activate script as usual
        manager.courtbuff.debuff(court);//remove elemental buff if it happened

        //set is court so that it won't be deactivated by counter, and will get destroyed at end
        isCourtElem = true;
        doNotDestroy = false;

        //element 2
        court.GetComponent<CardScriptReference>().elem = court.GetComponent<CardScriptReference>().court2;
        manager.courtbuff.buff(court);
        present(court);
        //here no need to run debuff, returning the val to original is more than enough

        //return stuff to original
        court.GetComponent<CardScriptReference>().value = originalValue;
        court.GetComponent<CardScriptReference>().elem = "court";
    }
}