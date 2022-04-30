using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom script that the ShopRNGManager needs to pick cards of different types based off parameters
//this just splits the cards within smaller databases that are then used by the rngManager
public class ShopDeckSplitter : MonoBehaviour
{
    [SerializeField] Shop manager;

    [HideInInspector] public int elemDataChoice;//this is so that the switch statement isn't enourmous, define what database it goes to with this

    public void setoff()
    {

        for (int i = 0; i < manager.byElemData.Length; i++)
        {
            //clear from last game
            manager.byElemData[i].allCards.Clear();
        }
        chooseElem();
    }

    //separate all cards into their scriptable databases
    private void chooseElem()
    {
        for (int i = 0; i < manager.shopAllDataInGame.allCards.Count; i++)
        {
            
            Switchboard(manager.shopAllDataInGame.allCards[i]);

            //this adds the correct card into the correct database
            
            manager.byElemData[elemDataChoice].allCards.Add(manager.shopAllDataInGame.allCards[i]);
        }
    }

    //had to separate so court and major can re-run it
    private void Switchboard(ScriptableCard c)
    {
        string cardelem = c.elem;

        switch (cardelem)
        {
            //these are separate switches with separate databases
            case "court":
                Court(c);
                break;
            case "major":
                Major(c);
                break;

            case "air":
                elemDataChoice = 8;
                break;
            case "earth":
                elemDataChoice = 9;
                break;
            case "fire":
                elemDataChoice = 10;
                break;
            case "water":
                elemDataChoice = 11;
                break;

            default:
                break;
        }
        
    }

    //they have different elemdatachoice
    public void Court(ScriptableCard c)
    {
        string cardelem = c.court2;

        switch (cardelem)
        {

            case "air":
                elemDataChoice = 0;
                break;
            case "earth":
                elemDataChoice = 1;
                break;
            case "fire":
                elemDataChoice = 2;
                break;
            case "water":
                elemDataChoice = 3;
                break;

            default:
                break;
        }
    }

    //they have different elemdatachoice
    public void Major(ScriptableCard c)
    {
        string cardelem = c.court2;

        switch (cardelem)
        {

            case "air":
                elemDataChoice = 4;
                break;
            case "earth":
                elemDataChoice = 5;
                break;
            case "fire":
                elemDataChoice = 6;
                break;
            case "water":
                elemDataChoice = 7;
                break;

            default:
                break;
        }
    }
}