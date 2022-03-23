using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToSpawn
{
    public string databaseName;
    public float spawnRate;
    [HideInInspector] public float minSpawnProb, maxSpawnProb;
}


public class ShopRNGManager : MonoBehaviour
{
    [SerializeField] Shop manager;
    public CardToSpawn[] cardToSpawn;


    //got from manager
    private string enemyElem;
    private string currentArea;
    private string enemyStre;

    // Start is called before the first frame update
    void Start()
    {
        //get references from manager
        enemyStre = manager.enemyStre;
        currentArea = manager.currentArea;

        //define probabilities
        defineProbs();
    }

    private void defineProbs()
    {

    }

}
