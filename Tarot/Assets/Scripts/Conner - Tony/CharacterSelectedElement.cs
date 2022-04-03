using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectedElement : MonoBehaviour
{
    PlayerReference playerRef;
    public GameObject gameObject;
    public GameObject text;

    void Start()
    {
        gameObject.SetActive(true);
        
    }

    void Update()
    {
        gameObject.transform.position = this.transform.position + new Vector3(0f, 0f, 0f);
        gameObject.transform.GetChild(4).transform.GetComponent<TextMesh>().text = this.GetComponent<PlayerReference>().element;
    }
     

    //in player reference, there is public static string called playerSelectedElem.
    //Based on that, the element for the enemy is chosen

    //if you need to edit that one parameter (playerselected elem) you can, as long as it stays a string in playerreference.
}
