using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnClick : MonoBehaviour
{
    [SerializeField] EndTurn manager;
    private float totalWait;

    private void OnMouseDown()
    {
        StartCoroutine("withDelays");

        //do this again for major arcana probs
        if (manager.gameStart == true)
            totalWait = manager.dyTot - (manager.dySingle * 2);
        else
            totalWait = manager.dyTot;
    }

    IEnumerator withDelays()
    {
        manager.cardeffects.get();//for card effects to play in order
        yield return null;

        manager.cardeffects.activate();//actual activation of card effects
        yield return new WaitForSeconds(totalWait);

        manager.removecardeffects.remove();
        manager.placeCardsScript.place();
        //if lastturncards is 13 all will work anyway, no worries it's only for draggable
        manager.cardeffects.get();//get all cards in array for draggable
    }
}