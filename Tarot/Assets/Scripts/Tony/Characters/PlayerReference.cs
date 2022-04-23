using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReference : MonoBehaviour
{
    public ScriptableChar[] charList;
    public string playerSelectedElem;
    private ScriptableChar charRef;

    public string _name;
    public int maxHP;
    public int maxSH;
    public string element;
    public int iD;
    public Sprite artWork;

    private SpriteRenderer spRend;

    public Sprite newSpriteFire;
    public Sprite newSpriteEarth;
    public Sprite newSpriteAir;
    public Sprite newSpriteWater;

    public void Start()
    {

        //The selected character from the character selection scene will be displayed here
        // Cant reference it in character selection screen as that comes BEFORE and characterSelectedElem isn't run till TonyCard scene is run 
        // This is the best way I can think of doing it that would still work fine. 
        
        PlayerPrefs.GetInt("selectedCharacter");

        if (PlayerPrefs.GetInt("selectedCharacter") == 0)
        {
            playerSelectedElem = "fire";
            spRend.sprite = newSpriteFire; 
            
        }

        if (PlayerPrefs.GetInt("selectedCharacter") == 1)
        {
            playerSelectedElem = "earth";
            spRend.sprite = newSpriteEarth;
        }

        if (PlayerPrefs.GetInt("selectedCharacter") == 2)
        {
            playerSelectedElem = "air";
            spRend.sprite = newSpriteAir;
        }

        if (PlayerPrefs.GetInt("selectedCharacter") == 3)
        {
            playerSelectedElem = "water";
            spRend.sprite = newSpriteWater;
        }
    }

    public void CustomAwake()
    {
        playerSelectedElem = InterScene.currentPlayer.Element;

        if (playerSelectedElem != null)
        {
            //select character using what we got
            for (int i = 0; i < charList.Length; i++)
            {
                if (charList[i].Element == playerSelectedElem)
                {
                    charRef = charList[i];
                    break;
                }
            }
        }

        //this is if testing
        else
            charRef = charList[4];

        //set all references
        _name = charRef.Name;
        maxHP = charRef.MaxHP;
        maxSH = charRef.MaxSH;
        element = charRef.Element;
        iD = charRef.ID;

        //implement the correct artwork
        if (InterScene.currentScene == "TonyCardTesting")
        {
            artWork = charRef.ArtworkPortrait;
        }
        else
        {
            artWork = charRef.ArtworkChibi;
        }


        spRend = GetComponent<SpriteRenderer>();
        spRend.sprite = artWork;
    }
}
