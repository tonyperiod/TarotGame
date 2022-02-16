using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Card Database", menuName = "Card Database")]
public class ScriptableCardDatabase : ScriptableObject
{
    public List<ScriptableCard> allCards;

}
