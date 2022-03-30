using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    GameObject gameObject;
    public GameObject text;
    public string text2;


    // Start is called before the first frame update
    void Start()
    {
        gameObject = GameObject.Find("Tooltip (Battle Board)");

        text.SetActive(false);

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
            gameObject.transform.position = this.transform.position + new Vector3(-1, 1f, 1.5f);
            text.SetActive(true);
            
        }

    }
    private void OnMouseExit()
    {
        gameObject.SetActive(false);
        text.SetActive(false);
    }

    public void ShowValue()
    {
        
    }

}
