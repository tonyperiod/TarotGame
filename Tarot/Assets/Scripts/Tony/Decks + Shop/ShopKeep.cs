using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeep : MonoBehaviour
{
    public Sprite[] shopKeeps;

    //just to spawn a random shopkeep every time
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = shopKeeps[Random.Range(0, 3)];
    }
    
}
