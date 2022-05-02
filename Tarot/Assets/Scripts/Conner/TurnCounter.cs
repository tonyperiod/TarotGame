using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class TurnCounter : MonoBehaviour
{
    // Start is called before the first frame update

    // Declare Public and Private variables
    public int currentTurn;
    GameObject gameObject; 

    void Start()
    {
        // By default the Turn Counter will be set to 0.
        currentTurn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        // Add a value of 1 to the turn counter UI element (as added in the Unity Project window)
        currentTurn += 1;

        // Find the turn counter from the Unity Project window.
        gameObject = GameObject.Find("TurnCounter");
        // Set the turn counter to a string so that it can be shown on a text element.
        gameObject.transform.GetComponent<Text>().text = currentTurn.ToString();
        // Set the text to be visible on screen.
        gameObject.SetActive(true);

    }

    void ResetTurn()
    {
        // When the game finishes, the turn counter will revert back to 0.
        currentTurn = 0;
    }
}




