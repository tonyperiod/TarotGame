using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom from general knowledge from youtube videos on the subject
[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class ScriptableCard : ScriptableObject
{
    public string Cardname;
    public Sprite artWork;

    //variables
    public int id;
    public int databaseId;
    public string elem;
    public int value;

    public string court1;
    public string court2;

    public int slot;

    public bool isPlayer;

    public int goldVal;
}