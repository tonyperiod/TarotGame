using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSlotsTaken : MonoBehaviour
{
    public bool[] snapPointTaken;

    void Awake()
    {
        // create array of true values of the taken snap values
        snapPointTaken = new bool[6];
        for (int i = 0; i < 6; i++)
        {
            snapPointTaken[i] = true;            
        }       
    }
}