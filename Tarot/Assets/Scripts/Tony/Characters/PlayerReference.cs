using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReference : MonoBehaviour
{
    public ScriptableChar[] charList;
    public static string playerSelectedElem;
    private ScriptableChar charRef;

    public string _name;
    public int maxHP;
    public int maxSH;
    public string element;
    public int iD;
    public Sprite artWork;

    private SpriteRenderer spRend;



    public void CustomAwake()
    {
     

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
