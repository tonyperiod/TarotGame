using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class TurnCounter : MonoBehaviour
{
    // Start is called before the first frame update

    public int currentTurn;
    GameObject gameObject; 

    void Start()
    {
        currentTurn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        currentTurn += 1;

        gameObject = GameObject.Find("TurnCounter");
        gameObject.transform.GetComponent<Text>().text = currentTurn.ToString();
        gameObject.SetActive(true);

    }

    void ResetTurn()
    {
        currentTurn = 0;
    }
}




