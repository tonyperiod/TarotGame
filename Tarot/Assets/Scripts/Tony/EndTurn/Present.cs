using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    public EndTurn manager;


    public void present(GameObject c)
    {
        bool isplayer = c.GetComponent<CardScriptReference>().isplayer;
        int value = c.GetComponent<CardScriptReference>().value;

        //from endTurn:

        GameObject[] lastTurnCards = manager.lastTurnCards;
        PlayerSystemManager PSysMng = manager.PSysMng;
        EnemySystemManager EsysMng = manager.EsysMng;

        bool isEonFirePr = manager.isEonFirePr;
        bool isPonFirePr = manager.isPonFirePr;


        switch (c.GetComponent<CardScriptReference>().symbol)
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
                    Debug.Log("court");
                    court(c);
                    break;
                }
        }
        GameObject.Destroy(c);
    }


    private void court(GameObject court)
    {

        int originalValue = court.GetComponent<CardScriptReference>().value;
        court.GetComponent<CardScriptReference>().value = court.GetComponent<CardScriptReference>().value / 2; //only need to change once

        //element 1
        court.GetComponent<CardScriptReference>().symbol = court.GetComponent<CardScriptReference>().court1;//temp edit to symbol
        manager.courtbuff.buff(court);//check for elemental buffing
        present(court);//activate script as usual
        manager.courtbuff.debuff(court);//remove elemental buff if it happened

        //element 2
        court.GetComponent<CardScriptReference>().symbol = court.GetComponent<CardScriptReference>().court2;
        manager.courtbuff.buff(court);
        present(court);
        //here no need to run debuff, returning the val to original is more than enough

        //return stuff to original
        court.GetComponent<CardScriptReference>().value = originalValue;
        court.GetComponent<CardScriptReference>().symbol = "court";
    }
}