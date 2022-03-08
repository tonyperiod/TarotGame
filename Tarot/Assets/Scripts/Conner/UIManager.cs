using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    GameObject gameObject;

    int cardDamage;
    int cardShield;


    // Start is called before the first frame update
    void Start()
    {
       gameObject = GameObject.Find("Tooltip");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        gameObject.SetActive(true);
        gameObject.transform.position = this.transform.position + new Vector3(0, 0.2f, 0);
        gameObject.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = "Shield: 5";

  
    }
    
    public void UpdateCard(int damage, int shield)
    {
        cardDamage = damage;
        cardShield = shield;
    }

    private void OnMouseExit()
    {
        gameObject.SetActive(false);

    }

}
