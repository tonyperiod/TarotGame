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

        //necessary for major arcana delay between activations
        if (manager.enemyMajorActivation != 0)
            manager.enemyMajorActivation -= 1;
        if (manager.playerMajorActivation != 0)
            manager.playerMajorActivation -= 1;
    }
}
