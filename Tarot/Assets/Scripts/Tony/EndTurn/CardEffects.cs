using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffects : MonoBehaviour
{
    [SerializeField] EndTurnManager manager;

    public Past Past;
    public Present Present;
    public Future Future;
    public PastFuture PFuture;

    bool gamestart;

    public void Start()
    {
        gamestart = true;
        
    }

    public void SwitchBoard(GameObject[] lastTurnCards)
    {
       

        Past.past(lastTurnCards[0]);
        Past.past(lastTurnCards[3]);

        Present.present(lastTurnCards[1]);
        Present.present(lastTurnCards[4]);

        if (gamestart == false)
        {
            PFuture.pf(lastTurnCards[6]);
            PFuture.pf(lastTurnCards[7]);
        }

        else
        {
            GameObject.Destroy(lastTurnCards[6]);
            GameObject.Destroy(lastTurnCards[7]);
            gamestart = false;
        }
        Future.future(lastTurnCards[2]);
        Future.future(lastTurnCards[5]);

    }
}
