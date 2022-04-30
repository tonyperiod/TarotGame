using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom simple scriptable object that allows me to edit decks freely within the editor and the code
[CreateAssetMenu(fileName ="New Card Database", menuName = "Card Database")]
public class ScriptableCardDatabase : ScriptableObject
{
    public List<ScriptableCard> allCards;
}