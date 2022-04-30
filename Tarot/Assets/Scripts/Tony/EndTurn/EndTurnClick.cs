using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    IEnumerator withDelays()
    {
        //this is so that the sound of the button press doesn't get confused with the card effects
        yield return new WaitForSeconds(0.5f);

        manager.cardeffects.get();//for card effects to play in order
        yield return new WaitForSeconds(0.1f);

        manager.cardeffects.delayCalculator();//to get the correct dytot, taking in account cards in game and potential counters
        yield return null;

        manager.cardeffects.activate();//actual activation of card effects
        yield return new WaitForSeconds(manager.dyTot);//delay after activation to allow for the activate coroutine to play, that is why dytot is calculated right before

        manager.removecardeffects.remove();
        manager.placeCardsScript.place();
        //if lastturncards is 13 all will work anyway, no worries it's only for draggable
        manager.cardeffects.get();//get all cards in array for draggable
        isCliccked = false;
    }
}