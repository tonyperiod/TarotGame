using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom script
// This is necessary to see what cards are on the board. It interfaces with draggable.
public class SlotsTaken : MonoBehaviour
{
    public bool[] snapPointTaken;
    // create array of true values of the taken snap values.
    public void CustomAwake()
    { 
        snapPointTaken = new bool[4];
        for (int i = 0; i < 4; i++)
        {
            snapPointTaken[i] = true;            
        }       
    }
}