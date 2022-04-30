using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom script
//prevents health damage
public class Hermit : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    public void Activate(GameObject c, bool isPlayer)
    {
        PlayerSystemManager PSysMng = manager.PSysMng;
        EnemySystemManager ESysMng = manager.EsysMng;

        if (isPlayer == true)        
            PSysMng.isHermit = true;
        
        else
            ESysMng.isHermit = true;
    }

    public void Destroyed(GameObject c, bool isPlayer)
    {
        PlayerSystemManager PSysMng = manager.PSysMng;
        EnemySystemManager ESysMng = manager.EsysMng;

        if (isPlayer == true)
            PSysMng.isHermit = false;
        else
            ESysMng.isHermit = false;
    }
}
