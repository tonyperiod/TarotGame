using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajorArcana : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    public void major(GameObject c, bool isPlayer)
    {
        Debug.Log(c.GetComponent<CardScriptReference>().value); 
    }
}
