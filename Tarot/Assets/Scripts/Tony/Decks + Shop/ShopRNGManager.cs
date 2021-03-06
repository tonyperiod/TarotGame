using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] //so card to spawn appears

//this class is from a tutorial
public class CardToSpawn
{
    [HideInInspector]
    public int databaseNumber;
    [HideInInspector]
    public float spawnRate; //different per enemy, in defineprobs()
    [HideInInspector] public float minSpawnProb, maxSpawnProb; //for the equation
}

//most of this is custom, I will specify what parts are from random generation tutorials
//this script is responsible for choosing what cards are present in the shop
public class ShopRNGManager : MonoBehaviour
{
    [SerializeField] Shop manager;
    public CardToSpawn[] cardToSpawnArray; //same order as project panel
    public static ShopRNGManager instance; //this insctance

    //got from manager
    private string enemyElem;
    private int currentArea;
    private string enemyStre;

    //internal
    private int AreaElem; //for switch function, based on currentArea

    //enemy stre modifiers
    private int modCommon;
    private int modAverage;
    private int modRare;

    //final total probabilities per type
    private int probMinor;
    private int probCourt;
    private int probMajor;

    //these are corrisponding values for elements, so can do if =i (useful for definespawnrate)
    private int elementalChecker;

    public void CustomAwake()
    {        //getting a new instance of all things
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);//to make sure that it never gets destroyed from game start
        }
        else
        {
            Destroy(gameObject); //if there is already a playerdatabase in game
        }

        //give values to cardtospawn elements = the order for byelemdata AND project panel
        for (int i = 0; i < cardToSpawnArray.Length; i++)
        {
           cardToSpawnArray[i].databaseNumber = i;
        }


    }

    ////TESTING ONLY
    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.E))
    //    {
    //        chooseData();
    //    }
    //}
    

    //CALL ONCE PER ENEMY
    public void GetCardRNG()
    {
        //get references from manager
        enemyStre = manager.enemyStre;
        currentArea = manager.currentArea;

        //define probabilities
        defineLevelElem();//find level element based on build order
        defineProbsStre();//get additive changes based on enemy type
        defineProbs(); //put everything toghether for final probabilities 
        defineSpawnRate();//spawn rate for random generation later, moving from the script to cardToSpawn
        defineMinMaxSpawnRate(); //set the min and max spawn rate (math fase to then use the random number generator, chooseData)
    }

    //here I define what the probabilities are based on the enemy
    private void defineLevelElem()
    {
        if (currentArea < 7)
            AreaElem = 0;

        if (6 < currentArea && currentArea < 11)
            AreaElem = 1;

        if (10 < currentArea && currentArea < 15)
            AreaElem = 2;

        if (14 < currentArea)
            AreaElem = 3;
    }

    //based on the enemy strenghth, I get a value to add/remove
    private void defineProbsStre()
    {
        switch (enemyStre)
        {
            case "weak":
                modCommon = 30;
                modAverage = 0;
                modRare = -30;
                break;


            case "med":
                modCommon = -15;
                modAverage = 30;
                modRare = -15;
                break;


            case "strong":
                modCommon = -30;
                modAverage = 30;
                modRare = 0;
                break;
            case "boss":
                modCommon = -30;
                modAverage = -30;
                modRare = 60;
                break;

        }
    }


    //total value always = 360, because very divisible by 6, so cards of same elem as area get 3x probability of other parts
    //area elem also = to progression in game
    //here I also define the helper for definespawnrate, so same element have higher chance of spawning
    private void defineProbs()
    {
        switch (AreaElem)
        {
            case 0://earth
                elementalChecker = 1;
                probMinor = 300 + modCommon;
                probCourt = 60 + modRare;
                probMajor = 0;
                break;

            case 1://air
                elementalChecker = 0;
                probMinor = 180 + modCommon;
                probCourt = 180 + modRare;
                probMajor = 0;
                break;

            case 2://water
                elementalChecker = 2;
                probMinor = 90 + modCommon;
                probCourt = 210 + modAverage;
                probMajor = 60 + modRare;
                break;

            case 3://fire
                elementalChecker = 3;
                probMinor = 0;
                probCourt = 60 + modCommon;
                probMajor = 300 + modRare; //so players have a high chance for major arcana in the end game
                break;
        }
    }

    //a lot of switches based on the areaelem
    private void defineSpawnRate()
    {
        for (int i = 0; i < cardToSpawnArray.Length; i++)
        {
            if (i < 4) //court cards
            {
                if (i == elementalChecker) //here == because court are at the top of the array
                {
                    cardToSpawnArray[i].spawnRate = probCourt / 2; //same elem -> higher probability
                }
                else
                    cardToSpawnArray[i].spawnRate = probCourt / 6;
            }

            if (3 < i && i < 8) //major cards
            {
                if (i == elementalChecker + 4)
                {
                    cardToSpawnArray[i].spawnRate = probMajor / 2; //same elem -> higher probability
                }
                else
                    cardToSpawnArray[i].spawnRate = probMajor / 6;
            }

            if (7 < i) //minor cards
            {
                if (i == elementalChecker + 8)
                {
                    cardToSpawnArray[i].spawnRate = probMinor / 2; //same elem -> higher probability
                }
                else
                    cardToSpawnArray[i].spawnRate = probMinor / 6;
            }

        }
    }

    //some math, basically gives more values between minspawnprob and maxspawnprob to items that are found more often, until all 360 numbers have a corrispondence
    //this is NOT a custom script
    private void defineMinMaxSpawnRate()
    {
        for (int i = 0; i < cardToSpawnArray.Length; i++)
        {
            if (i == 0)
            {
                cardToSpawnArray[i].minSpawnProb = 0;
                cardToSpawnArray[i].maxSpawnProb = cardToSpawnArray[i].spawnRate - 1;
            }
            else
            {
                cardToSpawnArray[i].minSpawnProb = cardToSpawnArray[i - 1].maxSpawnProb + 1;
                cardToSpawnArray[i].maxSpawnProb = cardToSpawnArray[i].minSpawnProb + cardToSpawnArray[i].spawnRate - 1;
            }
        }
    }

    //here I define what database to use, CALL SEPERATELY PER CARD
    //edited script found online, NOT CUSTOM
    public static int chooseData()
    {
        int dataBaseNumber = 0;
        float randomNum = Random.Range(0, 360);
        

        for (int i = 0; i < instance.cardToSpawnArray.Length; i++)
        {
            if (randomNum >= instance.cardToSpawnArray[i].minSpawnProb && randomNum <= instance.cardToSpawnArray[i].maxSpawnProb)// if is within the range of the card to spawn
            {
                dataBaseNumber = instance.cardToSpawnArray[i].databaseNumber;
                break;
            }
        }
        return dataBaseNumber;
    }
}