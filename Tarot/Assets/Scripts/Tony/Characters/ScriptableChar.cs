using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Char", menuName = "Character")]
public class ScriptableChar : ScriptableObject
{
    public string Name;
    public string Strength;

    public int MaxHP;
    public int MaxSH;
    public string Element;

    public int ID;

    public Sprite ArtworkPortrait;
    public Sprite ArtworkChibi;

    public int goldVal;

    public ScriptableCardDatabase deck;
}
