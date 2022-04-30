using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom script copied over and edited from the battle scene
public class ShopCardSwapping : MonoBehaviour
{    
    public ShopSlotsTaken slotstaken;
    public Transform[] snapPoints;
    

    //doing this externally so each instance doesn't run the code randomly, and all values stay fixed
    public void moveCard(GameObject card)
    {
        for (int i = 0; i < slotstaken.snapPointTaken.Length; i++)
        {         
            if (slotstaken.snapPointTaken[i] == false)
            {
                card.transform.position = snapPoints[i].transform.position;
                card.GetComponent<ShopCardScriptReference>().slot = i;
                slotstaken.snapPointTaken[i] = true;
            }
        }
    }
}