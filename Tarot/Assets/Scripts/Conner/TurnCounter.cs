using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class TurnCounter : MonoBehaviour
{
    // Start is called before the first frame update

    public int currentTurn;

    void Start()
    {
        currentTurn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Test

        if (Input.GetKeyDown("space"))
        {
            currentTurn += 1;
            gameObject.transform.GetComponent<TextMeshPro>().text = currentTurn.ToString();

        }
    }

    void NextTurn()
    {
        currentTurn += 1;

        gameObject.transform.GetComponent<TextMeshPro>().text = currentTurn.ToString();

    }

    void ResetTurn()
    {
        currentTurn = 0;
    }
}




