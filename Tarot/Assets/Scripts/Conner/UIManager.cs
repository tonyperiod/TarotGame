using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIManager : MonoBehaviour
{
    // Declare public and private variables.
    public GameObject gameObject;
    public GameObject text;
    string element;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            // Added a Debug.Log to check if right click is selected.
            Debug.Log("Right Mouse Clicked");
            // Set the tooltip to true if right click button has been clicked.
            gameObject.SetActive(true);
            // Move the tooltip to a position that is easy to see from the main camera view.
            gameObject.transform.position = this.transform.position + new Vector3(-2f, 2f, 0f);

            // Get a reference to the element the card is from the CardScriptReference script.
            element = gameObject.transform.GetChild(4).transform.GetComponent<TextMesh>().text = this.GetComponent<CardScriptReference>().elem;
            // Get a reference to the damage value of the card from the CardScriptReference script.
            gameObject.transform.GetChild(5).transform.GetComponent<TextMesh>().text = this.GetComponent<CardScriptReference>().value.ToString();

            // Get a reference to the slot the card is in from CardScriptReference scripts.
            int slot = this.GetComponent<CardScriptReference>().slot;

            // IF Statement to determine what text to show when each card is right clicked.
            // This IF Statement will tell the game whether to show Past, Present, Future or Past-Future text.

            if (slot == 0)
            { gameObject.transform.GetChild(0).transform.GetComponent<TextMesh>().text = "Past Card";   }
            else if (slot == 1)
            { gameObject.transform.GetChild(0).transform.GetComponent<TextMesh>().text = "Present Card"; }
            else if (slot == 2)
            { gameObject.transform.GetChild(0).transform.GetComponent<TextMesh>().text = "Future Card"; }
            // If no other stataments are true, then set tooltip title text to Past-Future Card
            else 
            { gameObject.transform.GetChild(0).transform.GetComponent<TextMesh>().text = "Past-Future Card"; }

            // After IF statement has run, set the text to active to appear on the screen.
            text.SetActive(true);


            // IF Statement will tell the game what text to show through right clicking each card.
            // These are element the card is and the slot that the card is currently in. 

            // element effects in past slot
            if (element.Equals("fire") && slot == 0)
            {
                gameObject.transform.GetChild(6).transform.GetComponent<TextMesh>().text = "Buff Present (value of card)";
            }
            if (element.Equals("earth") && slot == 0)
            {
            gameObject.transform.GetChild(6).transform.GetComponent<TextMesh>().text = "Shield (value of card)";
            }
            if (element.Equals("air") && slot == 0)
            {
            gameObject.transform.GetChild(6).transform.GetComponent<TextMesh>().text = "Send back Damage from Future";
            }
            if (element.Equals("water") && slot == 0)
            {
            gameObject.transform.GetChild(6).transform.GetComponent<TextMesh>().text = "Send back Damage to Present";
            }

            // element effects in present slot
            
            if (element.Equals("fire") && slot == 1)
            {
                gameObject.transform.GetChild(6).transform.GetComponent<TextMesh>().text = "Damage (Value of Card)";
            }
            if (element.Equals("earth") && slot == 1)
            {
                gameObject.transform.GetChild(6).transform.GetComponent<TextMesh>().text = "Damage (Value of Card)";
            }
            if (element.Equals("air") && slot == 1)
            {
                gameObject.transform.GetChild(6).transform.GetComponent<TextMesh>().text = "Damage (Value of Card)";
            }
            if (element.Equals("water") && slot == 1)
            {
                gameObject.transform.GetChild(6).transform.GetComponent<TextMesh>().text = "Damage (Value of Card)";
            }

            // element effects in future/past-future slot
            if (element.Equals("fire") && slot == 2)
            {
                gameObject.transform.GetChild(6).transform.GetComponent<TextMesh>().text = "Damage 2x Next Turn";
            }
            if (element.Equals("earth") && slot == 2)
            {
                gameObject.transform.GetChild(6).transform.GetComponent<TextMesh>().text = "2x Shield Next Turn";
            }
            if (element.Equals("air") && slot == 2)
            {
                gameObject.transform.GetChild(6).transform.GetComponent<TextMesh>().text = "Damage 2x Next Turn";
            }
            if (element.Equals("water") && slot == 2)
            {
                gameObject.transform.GetChild(6).transform.GetComponent<TextMesh>().text = "2x Heal Next Turn";
            }

            if (element.Equals("court"))
            {
                gameObject.transform.GetChild(6).transform.GetComponent<TextMesh>().text = "";
            }
        }

    }
    private void OnMouseExit()
    {
        // Set both the tooltip and the texts to false if the player moves the mouse of/away from the card. 
        gameObject.SetActive(false);
        text.SetActive(false);
    }

}
