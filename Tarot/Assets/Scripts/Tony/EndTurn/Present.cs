using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    //refer to parent manager script
    [SerializeField] EndTurnManager manager;

    GameObject[] lastTurnCards;
    bool isEonFirePa, isPonFirePa;

    PlayerSystemManager PSysMng;
    EnemySystemManager EsysMng;

    public void present(GameObject c)
    {
        //get references here so they're updated for sure
        bool isplayer = c.GetComponent<CardScriptReference>().isplayer;
        int value = c.GetComponent<CardScriptReference>().value;


        bool isEonFirePr = manager.isEonFirePr;
        bool isPonFirePr = manager.isPonFirePr;

        PSysMng = manager.PSysMng;
        EsysMng = manager.EsysMng;

        lastTurnCards = manager.lastTurnCards;


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

        }


        GameObject.Destroy(c);
    }

}
