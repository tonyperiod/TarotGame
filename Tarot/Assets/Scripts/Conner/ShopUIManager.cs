using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour
{
    public GameObject gameObject;
    string element;
    string damage;
    string cardname;

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
            Debug.Log("Right Mouse Clicked");
            gameObject.SetActive(true);
            gameObject.transform.position = new Vector3(100f, 300f, 0f);

            element = gameObject.transform.GetChild(1).transform.GetComponent<Text>().text = this.GetComponent<ShopCardScriptReference>().elem;
            damage = gameObject.transform.GetChild(3).transform.GetComponent<Text>().text = this.GetComponent<ShopCardScriptReference>().value.ToString();
            cardname = gameObject.transform.GetChild(4).transform.GetComponent<Text>().text = this.GetComponent<ShopCardScriptReference>().Cardname;
            
    }

    private void OnMouseExit()
    {
        gameObject.SetActive(false);
        
    }
}
