using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnClick : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    private void OnMouseDown()
    {
        //here is where all player interaction happens
        manager.cardeffects.get(); //for card effects to play in order
        manager.cardeffects.activate(); //actual activation of card effects
        manager.removecardeffects.remove();
        manager.placeCardsScript.place();
        manager.cardeffects.get(); //get all cards in array for draggable
    }
}