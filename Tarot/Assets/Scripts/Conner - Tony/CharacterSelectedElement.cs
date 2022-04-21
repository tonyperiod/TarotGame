using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectedElement : MonoBehaviour
{
    PlayerReference playerRef;
    GameObject gameObject;
    GameObject text;

    void Start()
    {
        
        
    }

    void Update()
    {
        

        gameObject.transform.GetComponent<TextMesh>().text = this.GetComponent<PlayerReference>().playerSelectedElem;
    }


    //in player reference, there is public static string called playerSelectedElem.
    //Based on that, the element for the player is chosen

    //if you need to edit that one parameter (playerselected elem) you can, as long as it stays a string in playerreference.
}
