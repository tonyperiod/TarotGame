using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public Camera camera;

    public GameObject spawnedCard;

    //getting positioning right, will put all into one with maybe a table prefab ???
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;

    private float posRef;
    private Transform posTra;


    private void Start()
    {
    //should make new list of current cards in collection

    }


    void Update()
    {
        //click deck
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

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
            SpawnCard(PlayerDatabase.GetRandomCard()); 
        }
    }

    private void SpawnCard(ScriptableCard s)
    {
        //get position of cards to spawn
        if (posRef == 0)
            posTra = pos1.transform;
        if (posRef == 1)
            posTra = pos2.transform;
        if (posRef == 2)
            posTra = pos3.transform;
        
        Instantiate(spawnedCard, posTra.position, posTra.rotation);
        
    }

}
