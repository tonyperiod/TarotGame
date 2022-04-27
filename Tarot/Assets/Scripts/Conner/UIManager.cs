using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIManager : MonoBehaviour
{

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
            Debug.Log("Right Mouse Clicked");
            gameObject.SetActive(true);
            gameObject.transform.position = this.transform.position + new Vector3(-2f, 2f, 0f);

            element = gameObject.transform.GetChild(4).transform.GetComponent<TextMesh>().text = this.GetComponent<CardScriptReference>().elem;
            gameObject.transform.GetChild(5).transform.GetComponent<TextMesh>().text = this.GetComponent<CardScriptReference>().value.ToString();

            int slot = this.GetComponent<CardScriptReference>().slot;


            if (slot == 0)
            { gameObject.transform.GetChild(0).transform.GetComponent<TextMesh>().text = "Past Card";   }
            else if (slot == 1)
            { gameObject.transform.GetChild(0).transform.GetComponent<TextMesh>().text = "Present Card"; }
            else if (slot == 2)
            { gameObject.transform.GetChild(0).transform.GetComponent<TextMesh>().text = "Future Card"; }
            else 
            { gameObject.transform.GetChild(0).transform.GetComponent<TextMesh>().text = "Past-Future Card"; }

            text.SetActive(true);



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
            if (element.Equals("fire") && slot > 2)
            {
                gameObject.transform.GetChild(6).transform.GetComponent<TextMesh>().text = "Damage 2x Next Turn";
            }
            if (element.Equals("earth") && slot > 2)
            {
                gameObject.transform.GetChild(6).transform.GetComponent<TextMesh>().text = "Damage 2x Next Turn";
            }
            if (element.Equals("air") && slot > 2)
            {
                gameObject.transform.GetChild(6).transform.GetComponent<TextMesh>().text = "Double Shield Next Turn";
            }
            if (element.Equals("water") && slot > 2)
            {
                gameObject.transform.GetChild(6).transform.GetComponent<TextMesh>().text = "Double Heal Next Turn";
            }

        }

    }
    private void OnMouseExit()
    {
        gameObject.SetActive(false);
        text.SetActive(false);
    }

}
