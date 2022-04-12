using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    public void Activate(GameObject c, bool isPlayer)
    {
        //bool activates in cardEffects
        if (isPlayer == true)
            manager.isWorldP = true;
        else
            manager.isWorldE = true;
        
    }

    public void Destroyed(GameObject c, bool isPlayer)
    {
        if (isPlayer == true)
        {
            manager.isWorldP = false;

            //destroy dummy
            manager.MajorDummy.Delete(6);
        }
        else
        {
            manager.isWorldE = false;
            manager.MajorDummy.Delete(7);

        }
    }
}
