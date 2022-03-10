using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    private void OnMouseEnter()
    {
        gameObject.SetActive(true);
        gameObject.transform.position = this.transform.position + new Vector3(1, 0.7f, 2);

        text.SetActive(true);
        
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
