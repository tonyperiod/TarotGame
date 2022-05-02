using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom script on the endturn button
public class EndTurnClick : MonoBehaviour
{
    [SerializeField] EndTurn manager;
    private bool isCliccked; //to not allow players to double click, as that would break the game

    private void Start()
    {
        isCliccked = false;
    }

    private void OnMouseDown()
    {
        //no double clicks
        if (isCliccked == false)
        {
            isCliccked = true;
            //audio
            manager.audioManager.Play("end turn");

            StartCoroutine("withDelays");
        }
    }

    //used delays mainly so that cardeffects has time to activate before everything after
    IEnumerator withDelays()
    {      
        
        manager.cardeffects.get();//for card effects to play in order
        manager.cardeffects.delayCalculator();//edits dytot so that there isn't a pause between activation and the end of the turn
        yield return new WaitForSeconds(0.5f); //this delay is so that the sound of the button press doesn't get confused with the card effects

        manager.cardeffects.activate();//actual activation of card effects
        yield return new WaitForSeconds(manager.dyTot);//delay after activation to allow for the activate coroutine to play, that is why dytot is calculated right before

        manager.removecardeffects.remove();
        manager.placeCardsScript.place();
        //Occasionally there is a bug where lastturncards is 13, all will work anyway
        manager.cardeffects.get();//get all cards in array for draggable
        isCliccked = false;
    }
}