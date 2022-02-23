using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public Camera _camera;

    public GameObject cardPrefab;


    //getting positioning right
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;

    private int posRef;
    private Transform posTra;

    // card parameter work
    private CardScriptReference cardReference;

    //private GameObject spawnedCard;

    // slots taken work
    public GameObject Table;
    private SlotsTaken slotsTaken;

    private void Start()
    {
        slotsTaken = Table.GetComponent<SlotsTaken>();
        //cardReference = cardPrefab.GetComponent<CardScriptReference>();
    }

    void Update()
    {
        //click deck
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray,out RaycastHit hitInfo))
            {
                if (hitInfo.collider.CompareTag("Deck") )
                {
                    ClickDeck();
                  
                }
            }
        }
        

    }


    void ClickDeck()
    {
        //for loop with value 3, changing spawn location
        for (int i = 0; i < 3; i++)
        {
            posRef = i;
            SpawnCard();
        }
    }

    private void SpawnCard()
    {
        //get position of cards to spawn
        if (posRef == 0)
            posTra = pos1.transform;

        if (posRef == 1)
            posTra = pos2.transform;
        if (posRef == 2)
            posTra = pos3.transform;

        //set slots

        cardReference = cardPrefab.GetComponent<CardScriptReference>();
        cardReference.slot = posRef;
        
        Instantiate(cardPrefab, posTra.position, posTra.rotation);
        
    }

}
