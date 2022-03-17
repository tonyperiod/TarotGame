using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Char", menuName = "Character")]
public class ScriptableChar : ScriptableObject
{
    [Header ("for all")]
    public string Name;
    public Sprite Artwork;
    public int MaxHP;
    public int MaxSH;
    public string Element;
    public int ID;


    [Header ("for enemy")]
    public int level;
    public string type;
}
