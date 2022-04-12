using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnCustomAwake : MonoBehaviour
{
    public EndTurn manager;
    // Start is called before the first frame update
   public void CustomAwake()
    {
        manager.slotsTaken = manager.Table.GetComponent<SlotsTaken>();
        //fix bug of the two placeholder cards in slot activating
        manager.gameStart = true;
        //prevent major arcana in first turn
        manager.enemyMajorActivation = 1;
        manager.playerMajorActivation = 1;
        //get cards onto table
        manager.placeCardsScript.place();
        //fire stuff
        manager.isEonFirePa = false; manager.isPonFirePa = false; manager.isEonFirePr = false; manager.isPonFirePr = false; manager.isEonFireFu = false; manager.isPonFireFu = false;
        //get syst managers for hp
        manager.PSysMng = manager.Gamehandler.GetComponent<PlayerSystemManager>();
        manager.EsysMng = manager.Gamehandler.GetComponent<EnemySystemManager>();
        //set the lastturncards database, for draggable
        manager.cardeffects.get();

        //EDIT HERE AFTER TAROT CARDS
        manager.dyTot = manager.dySingle*12;//all delays play twice

    }
}