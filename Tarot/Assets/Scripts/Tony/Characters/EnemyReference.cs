using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom script
//with more time, I was planning on randomizing the enemy. I left the code commented out here
public class EnemyReference : MonoBehaviour
{
    //these only for random enemies
    //get enemy out of all of them
    //public ScriptableChar[] charRef;
    //private List<ScriptableChar> potentialEnemies;

    ////for external generation
    //public static string wantEnemyElement;

    public ScriptableChar chosenEnemy;     

    //references
    public string _name;
    public int maxHP;
    public int maxSH;
    public string element;
    public int iD;
    public Sprite artWork;
    public Sprite artWorkChibi;

    //component on gameobject
    private SpriteRenderer spRend;

    //for now only random opponent, here can add logic for modifying the parameters randomly, and a lot will depend on Dennis for this
    public void CustomAwake()
    {
        //wantEnemyElement = "fire"; //FOR DEBUG PERPOSES ONLY---------------------
        //getOpponent(wantEnemyElement);

        //get from interscript, IF NOT USE EDITOR (for testing)
        if (InterScene.currentEnemy != null)
            chosenEnemy = InterScene.currentEnemy;


        //get all stats
        _name = chosenEnemy.Name;
        maxHP = chosenEnemy.MaxHP;
        maxSH = chosenEnemy.MaxSH;
        element = chosenEnemy.Element;
        iD = chosenEnemy.ID;

        artWork = chosenEnemy.ArtworkPortrait;

        spRend = GetComponent<SpriteRenderer>();
        spRend.sprite = artWork;
    }

    //this was for random enemies of type, no longer needed
    //private void getOpponent(string e)
    //{
    //    potentialEnemies = new List<ScriptableChar>();// only need it here

    //    foreach (var item in charRef)
    //    {
    //        if (item.Element == e)
    //        {
    //            potentialEnemies.Add(item);
    //        }
    //    }

    //    //random enemy out of selection

    //    int random = Random.Range(0, potentialEnemies.Count);

    //    chosenEnemy = potentialEnemies[random];
    //}
}

