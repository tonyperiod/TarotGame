using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour
{
    public GameObject gameObject;

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
            gameObject.transform.position = new Vector3(950f, 500f, 0f);

            gameObject.transform.GetChild(0).transform.GetComponent<Text>().text = this.GetComponent<ShopCardScriptReference>().elem + " Card";
            gameObject.transform.GetChild(1).transform.GetComponent<Text>().text = this.GetComponent<ShopCardScriptReference>().value.ToString();

        }

    }

    private void OnMouseExit()
    {
        gameObject.SetActive(false);
        
    }
}
