using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnCardToCentre : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    public void centre(GameObject c)
    {
        c.transform.position = manager.centrePos[1].transform.position;
        c.transform.rotation = manager.centrePos[1].transform.rotation;
        c.transform.localScale = manager.centrePos[1].transform.localScale;
    }
    public void left(GameObject c)
    {
        c.transform.position = manager.centrePos[0].transform.position;
        c.transform.rotation = manager.centrePos[0].transform.rotation;
        c.transform.localScale = manager.centrePos[0].transform.localScale;
    }
    public void right(GameObject c)
    {
        c.transform.position = manager.centrePos[2].transform.position;
        c.transform.rotation = manager.centrePos[2].transform.rotation;
        c.transform.localScale = manager.centrePos[2].transform.localScale;
    }
}