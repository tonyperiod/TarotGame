using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        manager.MajorDummy.Substitute(slot);
    }
}
