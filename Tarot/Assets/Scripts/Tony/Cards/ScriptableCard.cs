using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class ScriptableCard : ScriptableObject
{
    public string Cardname;

    public Sprite artWork;

    //variables
    public int id;
    public string symbol;
    public int value;

    public string court1;
    public string court2;

    public int slot;

    public bool isPlayer;
}