using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnClick : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    private void OnMouseDown()
    {
        manager.cardeffects.get(); //for card effects to play in order
        manager.cardeffects.activate();
        manager.removecardeffects.remove();
        manager.placeCardsScript.place();
        manager.cardeffects.get(); //for draggable
    }
}