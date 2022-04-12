using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsTaken : MonoBehaviour
{
    public bool[] snapPointTaken;

    public void CustomAwake()
    {
        // create array of true values of the taken snap values
        snapPointTaken = new bool[4];
        for (int i = 0; i < 4; i++)
        {
            snapPointTaken[i] = true;            
        }       
    }
}