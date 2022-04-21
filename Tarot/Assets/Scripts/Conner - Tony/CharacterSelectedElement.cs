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
        // REFERENCE TO THE PLAYER SELECTED ELEMENT CAN BE VIEWED IN PLAYER REFERENCE SCRIPT
        // I cant run the player reference here as this scene is run before the card scene (first time PlayerReference/element is run). 
        // It changes the string with what I have done in Player Reference though so alls good.


    }

    void Update()
    {
        
    }

}
