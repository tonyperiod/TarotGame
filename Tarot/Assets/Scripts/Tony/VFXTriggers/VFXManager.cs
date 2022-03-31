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

    public VFXPast past;
    public VFXPresent pre;
    public VFXFuture fut;
    public VFXPastFuture pfut;


    public void Activate(GameObject card)
    {
        slot = card.GetComponent<CardScriptReference>().slot;
        switch (slot)
        {
            case 0:
                past.activate(card);
                break;
            case 1:
                pre.activate(card);
                break;
            case 2:
                fut.activate(card);
                break;
            case 3:
                pfut.activate(card);
                break;
            case 4:
                past.activate(card);
                break;
            case 5:
                pre.activate(card);
                break;
            case 6:
                fut.activate(card);
                break;
            case 7:
                pfut.activate(card);
                break;

        }
    }

}
