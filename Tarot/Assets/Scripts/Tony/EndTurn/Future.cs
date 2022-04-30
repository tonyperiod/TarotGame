using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//most straightforward effect -> only responsible for moving stuff
public class Future : MonoBehaviour
{
    public EndTurn manager;

    public void future(GameObject c)
    {
        switch (c.GetComponent<CardScriptReference>().slot)
        {
            case 2:
                manager.slotsTaken.snapPointTaken[2] = false;
                c.transform.position = manager.pos[6].transform.position;
                c.transform.localScale = manager.pos[6].transform.localScale;
                c.transform.rotation = manager.pos[6].transform.rotation;
                c.GetComponent<CardScriptReference>().slot = 6;
                break;

            case 5:
                c.transform.position = manager.pos[7].transform.position;
                c.transform.localScale = manager.pos[7].transform.localScale;
                c.transform.rotation = manager.pos[7].transform.rotation;
                c.GetComponent<CardScriptReference>().slot = 7;
                break;
        }
        manager.audioManager.Play("card placed");
    }
}