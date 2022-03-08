using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReference : MonoBehaviour
{
    //get enemy out of all of them
    public ScriptableChar[] charRef;
    private List<ScriptableChar> potentialEnemies;
    private ScriptableChar chosenEnemy;

    //for external generation
    public string wantElement;

    //references
    public string _name;
    public int maxHP;
    public int maxSH;
    public string element;
    public int iD;
    public Sprite artWork;

    private SpriteRenderer spRend;

    //for now only random opponent, here can add logic for modifying the parameters randomly, and a lot will depend on Dennis for this
    void Awake()
    {
        wantElement = "fire"; //FOR DEBUG PERPOSES ONLY---------------------
        getOpponent(wantElement);

        //get all stats
        _name = chosenEnemy.Name;
        maxHP = chosenEnemy.MaxHP;
        maxSH = chosenEnemy.MaxSH;
        element = chosenEnemy.Element;
        iD = chosenEnemy.ID;
        artWork = chosenEnemy.Artwork;

        spRend = GetComponent<SpriteRenderer>();
        spRend.sprite = artWork;
    }


    private void getOpponent(string e)
    {
        potentialEnemies = new List<ScriptableChar>();// only need it here

        foreach (var item in charRef)
        {
            if (item.Element == e)
            {
                potentialEnemies.Add(item);
            }
        }

        //random enemy out of selection

        int random = Random.Range(0, potentialEnemies.Count);

        chosenEnemy = potentialEnemies[random];
    }
}
