using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnCustomAwake : MonoBehaviour
{
    public EndTurn et;
    // Start is called before the first frame update
   public void CA()
    {
        et.slotsTaken = et.Table.GetComponent<SlotsTaken>();

        //fix bug of the two placeholder cards in slot activating
        et.gameStart = true;

        //get cards onto table
        et.placeCardsScript.place();

        //fire stuff
        et.isEonFirePa = false; et.isPonFirePa = false; et.isEonFirePr = false; et.isPonFirePr = false; et.isEonFireFu = false; et.isPonFireFu = false;

        //get syst managers for hp
        et.PSysMng = et.Gamehandler.GetComponent<PlayerSystemManager>();
        et.EsysMng = et.Gamehandler.GetComponent<EnemySystemManager>();

    }
}
