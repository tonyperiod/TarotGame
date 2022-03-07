using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnRemoveCardEffects : MonoBehaviour
{
    public EndTurn manager;
public void remove()
    {
        manager.isEonFirePa = false;
        manager.isPonFirePa = false;

        manager.isEonFirePr = false;
        manager.isPonFirePr = false;

        manager.isEonFireFu = false;
        manager.isPonFireFu = false;
    }
}
