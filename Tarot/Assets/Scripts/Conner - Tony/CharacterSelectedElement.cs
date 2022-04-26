using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectedElement : MonoBehaviour
{
    PlayerReference playerRef;
    public string playerSelectedElem;
    GameObject text;
    GameObject gameObject;

    void Start()
    {

        playerSelectedElem = this.GetComponent<PlayerReference>().playerSelectedElem;

        PlayerPrefs.GetInt("selectedCharacter");

        if (PlayerPrefs.GetInt("selectedCharacter") == 0)
        {
            playerSelectedElem = "fire";
        }

        if (PlayerPrefs.GetInt("selectedCharacter") == 1)
        {
            playerSelectedElem = "earth";
        }

        if (PlayerPrefs.GetInt("selectedCharacter") == 2)
        {
            playerSelectedElem = "air";
        }

        if (PlayerPrefs.GetInt("selectedCharacter") == 3)
        {
            playerSelectedElem = "water";
        }

    }

    void Update()
    {
        //gameObject.SetActive(true);
        //gameObject.transform.position = this.transform.position + new Vector3(0f, 0f, 0f);
        //gameObject.transform.GetChild(3).transform.GetComponent<TextMesh>().text = this.GetComponent<CardScriptReference>().elem;
    }
     

    //in player reference, there is public static string called playerSelectedElem.
    //Based on that, the element for the player is chosen

    //if you need to edit that one parameter (playerselected elem) you can, as long as it stays a string in playerreference.
}
