using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnClick : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    private void OnMouseDown()
    {
        manager.cardeffects.get();
        manager.removecardeffects.remove();
        manager.placeCardsScript.place();
    }
}
