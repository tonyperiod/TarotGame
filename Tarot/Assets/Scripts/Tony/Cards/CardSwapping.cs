using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom script
public class CardSwapping : MonoBehaviour
{    
    public SlotsTaken slotstaken;
    public Transform[] snapPoints;

    //doing this externally so each instance doesn't run the code, and all values stay fixed
    public void moveCard(GameObject card)
    {
        for (int i = 0; i < slotstaken.snapPointTaken.Length; i++)
        {         
            if (slotstaken.snapPointTaken[i] == false)
            {
                card.transform.position = snapPoints[i].transform.position;
                card.GetComponent<CardScriptReference>().slot = i;
                slotstaken.snapPointTaken[i] = true;
            }
        }
    }
}