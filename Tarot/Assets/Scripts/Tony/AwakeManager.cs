using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeManager : MonoBehaviour
{
    //getting reference to ALL scripts with an awake
    public EndTurnManager endTurnManager;


    private void Awake()
    {
        endTurnManager.CustomAwake();
    }


}
