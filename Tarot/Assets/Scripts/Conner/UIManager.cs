using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    GameObject gameObject;
    public GameObject text;

    int cardDamage;
    int cardShield;


    // Start is called before the first frame update
    void Start()
    {
        gameObject = GameObject.Find("Tooltip");
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
            gameObject.transform.position = this.transform.position + new Vector3(-1, 1f, 2);
            text.SetActive(true);
        }


    }

    public void UpdateCard(int damage, int shield)
    {
        cardDamage = damage;
        cardShield = shield;
    }

    private void OnMouseExit()
    {
        gameObject.SetActive(false);
        text.SetActive(false);
    }

}
