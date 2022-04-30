using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom code to simplify buffing/debuffing code within other scripts
public class CourtBuff : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    //this is to increase value of one half of the court card if the elem is the same as the player
    public void buff(GameObject court)
    {
        //player side
        if (court.GetComponent<CardScriptReference>().isplayer == true)
        {
            if (court.GetComponent<CardScriptReference>().elem == manager.PRef.element)//compare player elem to this
            {
                court.GetComponent<CardScriptReference>().value += manager.elemBuff/2; // /2, look at court code within past pres future if in doubt
            }
        }

        //enemy side
        else
        {
            if (court.GetComponent<CardScriptReference>().elem == manager.ERef.element)
            {
                court.GetComponent<CardScriptReference>().value += manager.elemBuff/2; 
            }
        }
    }

    //this is to play after the buff so the value returns to original. If elem 1 gets buffed, elem 2 doesn't get influenced.
    public void debuff(GameObject court)
    {
        //player side
        if (court.GetComponent<CardScriptReference>().isplayer == true)
        {
            if (court.GetComponent<CardScriptReference>().elem == manager.PRef.element)
            {
                court.GetComponent<CardScriptReference>().value -= manager.elemBuff / 2; 
            }
        }

        //enemy side
        else
        {
            if (court.GetComponent<CardScriptReference>().elem == manager.ERef.element)
            {
                court.GetComponent<CardScriptReference>().value -= manager.elemBuff / 2;
            }
        }
    }
}