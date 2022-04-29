using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXManager : MonoBehaviour
{
    //from manager
    [SerializeField] EndTurn manager;

    [HideInInspector]
    public string cardElement;
    [HideInInspector]
    public int cardValue;
    [HideInInspector]
    public bool cardIsPlayer;

    int slot;

    [Header("SCRIPTS")]
    public VFXPast past;
    public VFXPresent pre;
    public VFXFuture fut;
    public VFXPastFuture pfut;

    [Header("COMPLEX VFX")]
    public GameObject[] presentVFX;
    public GameObject[] pastFutureVFX;
    public float addHeight;
    public Transform playerStTransf;
    public Transform enemyStTransf;
    public Transform playerEndTransf;
    public Transform enemyEndTransf;


  

    public void Activate(GameObject card, int time) // time is to see if past, pre, fut
    {
        switch (time)
        {
            case 0:
                past.activate(card);
                break;
            case 1:
                pre.activate(card);
                break;
            case 2:
                pfut.activate(card);
                break;
            case 3:
                fut.activate(card);
                break;
        }
    }

}
