using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastFuture : MonoBehaviour
{
    public EndTurn manager;

    public void pastfuture(GameObject c)
    {
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
        string PElem = manager.PElem;
        string EElem = manager.EElem;
        string PElemC = manager.PElemC;
        string EElemC = manager.EElemC;


        //string PElem = manager.lastTurnCards[0].GetComponent<CardScriptReference>().wlwm;
        //string EElem = manager.lastTurnCards[3].GetComponent<CardScriptReference>().wlwm;

        ////court second element for countering elements
        //string PElemC = "null";
        //string EElemC = "null";

        ////court card double elemental
        //if (PElem == "court")
        //{
        //    PElem = manager.lastTurnCards[0].GetComponent<CardScriptReference>().court1;
        //    PElemC = manager.lastTurnCards[0].GetComponent<CardScriptReference>().court2;
        //}

        //if (EElem == "court")
        //{
        //    EElem = manager.lastTurnCards[3].GetComponent<CardScriptReference>().court1;
        //    EElemC = manager.lastTurnCards[3].GetComponent<CardScriptReference>().court2;
        //}


        switch (c.GetComponent<CardScriptReference>().elem)
        {
            case "fire":

                if (isplayer == true && EElem != "water" && EElemC != "water")
                {
                    EsysMng.TakeDamage(2 * value);
                    isEonFireFu = true;
                }

                if (isplayer == false && PElem != "water" && PElemC != "water")
                {
                    PSysMng.TakeDamage(2 * value);
                    isEonFireFu = true;
                }

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
                    Debug.Log("court");
                    court(c);
                    break;
                }
        }
        GameObject.Destroy(c);
    }

    //they activate seperately, for now one of the two will always pass.
    private void court(GameObject court)
    {
        int originalValue = court.GetComponent<CardScriptReference>().value;
        court.GetComponent<CardScriptReference>().value = court.GetComponent<CardScriptReference>().value / 2; //only need to change once
        
        //element 1
        court.GetComponent<CardScriptReference>().elem = court.GetComponent<CardScriptReference>().court1;//temp edit to wlwm
        manager.courtbuff.buff(court);//check for elemental buffing
        pastfuture(court);//activate script as usual
        manager.courtbuff.debuff(court);//remove elemental buff if it happened

        //element 2
        court.GetComponent<CardScriptReference>().elem = court.GetComponent<CardScriptReference>().court2;
        manager.courtbuff.buff(court);
        pastfuture(court);
        //here no need to run debuff, returning the val to original is more than enough

        //return stuff to original
        court.GetComponent<CardScriptReference>().value = originalValue;
        court.GetComponent<CardScriptReference>().elem = "court";
    }
}