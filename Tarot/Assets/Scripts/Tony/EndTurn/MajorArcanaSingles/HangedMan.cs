using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom script
//removes pastfuture for other player
public class HangedMan : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    public void Activate(GameObject c, bool isPlayer)
    {
        int slot = 0;//pastfuture slot
        if (isPlayer == true)
        {
            slot = 7;
        }
        else
        {
            slot = 6;
        }
        manager.MajorDummy.Substitute(slot);//substitute past future for dummy EVERY TURN
    }
    //no deactivate needed, as it plays every turn with no saved parameters
}
