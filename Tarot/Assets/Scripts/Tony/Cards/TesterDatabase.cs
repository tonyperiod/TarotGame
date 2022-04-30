using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//small custom script to debug lists
public class TesterDatabase : MonoBehaviour
{
    //public void FixedUpdate()
    //{
    //    Printing(PlayerDatabase.GetRandomCard());
    //}

    public void Printing(GameObject[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            Debug.Log(list[i].GetComponent<CardScriptReference>().Cardname);
        }
    }
}