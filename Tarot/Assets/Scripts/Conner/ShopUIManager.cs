using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour
{
    // Declare Public and Private variables to be used within the shopUI.
    public GameObject gameObject;
    string element;
    string damage;
    string cardname;
    string effect;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // OnMouseOver function is called so that the function will run when the player hovers over any of the cards in the shop scene.
    // This is a default unity function that can be called anytime.
    private void OnMouseOver()
    {
            // Set the Tooltip GameObject to true so that when the player hovers over the card it will show the tooltip.
            gameObject.SetActive(true);
            // Set the tooltip to a position so that it can be easily seen from the camera position.
            gameObject.transform.position = new Vector3(100f, 300f, 0f);

            // Get a reference to the element from CardScriptReference script and set the 1st text child to show the element.
            element = gameObject.transform.GetChild(1).transform.GetComponent<Text>().text = this.GetComponent<ShopCardScriptReference>().elem;
            // Get a reference to the damage value from CardScriptReference script and set the 3rd text child to show the damage value.
            damage = gameObject.transform.GetChild(3).transform.GetComponent<Text>().text = this.GetComponent<ShopCardScriptReference>().value.ToString();
            // Get a reference to the name of the card which is set through Scriptable objects on the Unity Editor.
            cardname = gameObject.transform.GetChild(4).transform.GetComponent<Text>().text = this.GetComponent<ShopCardScriptReference>().Cardname;
            effect = gameObject.transform.GetChild(5).transform.GetComponent<Text>().text; 

    }

    private void OnMouseExit()
    {
        // When the player moves there mouse away from any of the cards - it will hide the tooltip from the screen.
        gameObject.SetActive(false);
        
    }
}
