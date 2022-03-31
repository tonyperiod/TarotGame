using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIManager : MonoBehaviour
{

    public GameObject gameObject;
    public GameObject text; 


    // Start is called before the first frame update
    void Start()
    {
        //gameObject = GameObject.Find("Tooltip (Battle Board)");


        //cardPrefab = GameObject.Find("CardPrefabA");

        //cardScriptReference = cardPrefab.transform.GetComponent<CardScriptReference>();
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
            gameObject.transform.position = this.transform.position + new Vector3(-0.5f, 1f, 0f);

            gameObject.transform.GetChild(4).transform.GetComponent<TextMesh>().text = this.GetComponent<CardScriptReference>().elem;
            gameObject.transform.GetChild(5).transform.GetComponent<TextMesh>().text = this.GetComponent<CardScriptReference>().value.ToString();

            text.SetActive(true);
        }

    }
    private void OnMouseExit()
    {
        gameObject.SetActive(false);
        text.SetActive(false);
    }

}
