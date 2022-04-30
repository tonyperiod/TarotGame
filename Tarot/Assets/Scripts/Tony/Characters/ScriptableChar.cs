using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom scriptable object for all characters.
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

    // implemented this when we were thinking of adding gold to the game. Left in case we went back to the idea
    public int goldVal;

    public ScriptableCardDatabase deck;
}
