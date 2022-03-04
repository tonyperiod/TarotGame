using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastFuture : MonoBehaviour
{
    //refer to parent manager script
    [SerializeField] EndTurnManager manager;
    GameObject[] lastTurnCards;
    bool isEonFireFu, isPonFireFu;

    PlayerSystemManager PSysMng;
    EnemySystemManager EsysMng;

    public void pf(GameObject c)
    {
        bool isplayer = c.GetComponent<CardScriptReference>().isplayer;
        int value = c.GetComponent<CardScriptReference>().value;

        bool isEonFireFu = manager.isEonFireFu;
        bool isPonFireFu = manager.isPonFireFu;

        PSysMng = manager.PSysMng;
        EsysMng = manager.EsysMng;

        //counter element

        string PElem = lastTurnCards[0].GetComponent<CardScriptReference>().symbol;
        string EElem = lastTurnCards[3].GetComponent<CardScriptReference>().symbol;

        switch (c.GetComponent<CardScriptReference>().symbol)
        {
            case "fire":

                if (isplayer == true && EElem != "water")
                {
                    EsysMng.TakeDamage(2 * value);
                    isEonFireFu = true;
                }

                if (isplayer == false && PElem != "water")
                {
                    PSysMng.TakeDamage(2 * value);
                    isEonFireFu = true;
                }

                break;


            case "air":

                if (isplayer == true && EElem != "earth")
                {
                    EsysMng.TakeAirDmg(2 * value);
                }

                if (isplayer == false && PElem != "earth")
                {
                    PSysMng.TakeAirDmg(2 * value);
                }
                break;


            case "earth":
                if (isplayer == true && EElem != "air")
                {
                    PSysMng.HealSH(2 * value);
                }

                if (isplayer == false && PElem != "air")
                {
                    EsysMng.HealSH(2 * value);
                }

                break;


            case "water":
                if (isplayer == true && isPonFireFu == false && EElem != "fire")
                {
                    PSysMng.HealHP(2 * value);
                }
                if (isplayer == false && isEonFireFu == false && PElem != "fire")
                {
                    EsysMng.HealHP(2 * value);
                }
                break;

        }


        GameObject.Destroy(c);
    }
}
