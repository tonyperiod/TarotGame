using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom script to connect a character scriptable object to the game world, and render the correct sprite
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


    public void CustomAwake()
    {
        //testing
        charRef = charList[2];
        
        if (InterScene.currentPlayer != null)
        {
            //select character using what we got. This is one way to do it, within the enemyreference I used a different method.
            for (int i = 0; i < charList.Length; i++)
            {
                if (charList[i].Element == InterScene.currentPlayer.Element)//select the correct character scriptable object based off element
                {
                    charRef = charList[i];
                    break;
                }
            }
        }


        //set all references
        _name = charRef.Name;
        maxHP = charRef.MaxHP;
        maxSH = charRef.MaxSH;
        element = charRef.Element;
        iD = charRef.ID;

        //implement the correct artwork

        artWork = charRef.ArtworkPortrait;

        spRend = GetComponent<SpriteRenderer>();
        spRend.sprite = artWork;
    }
}