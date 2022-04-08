using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician : MonoBehaviour
{
    [SerializeField] EndTurn manager;
    public ScriptableCard[] choice;//the possible cards that can be played
    int chosenCardPa;
    int chosenCardPr;
    GameObject[] magicianCards;

    public void Activate(GameObject c, bool isPlayer)
    {
        string vsElemPast;//the others past card element
        string vsElemPre = null; //the others present card element (only for majors)
        string ElemChar; //the element of 

        magicianCards = new GameObject[2];
        
        //set the vs elements, and delays
        if(isPlayer == true)
        {
            vsElemPast = manager.lastTurnCards[3].GetComponent<CardScriptReference>().elem;
            if (manager.lastTurnCards[11].GetComponent<CardScriptReference>().court1 == "major")
                vsElemPre = manager.lastTurnCards[11].GetComponent<CardScriptReference>().elem;
            ElemChar = manager.PRef.element;

            manager.dyMajP = manager.dySingle * 2;
        }
        else
        {
            vsElemPast = manager.lastTurnCards[0].GetComponent<CardScriptReference>().elem;
            if (manager.lastTurnCards[9].GetComponent<CardScriptReference>().court1 == "major")
                vsElemPre = manager.lastTurnCards[9].GetComponent<CardScriptReference>().elem;
            ElemChar = manager.PRef.element;

            manager.dyMajE = manager.dySingle * 2;
        }

        //choose the past card, by defining slot vaue
        switch (vsElemPast)
        {
            case "air":
                chosenCardPa = 1;
                break;
            case "earth":
                chosenCardPa = 0;
                break;
            case "fire":
                chosenCardPa = 3;
                break;
            case "water":
                chosenCardPa = 2;
                break;
        }
        
        //chose present card
        if (vsElemPre != null)//only for majors
        {
            switch (vsElemPre)
            {
                case "air":
                    chosenCardPr = 1;
                    break;
                case "earth":
                    chosenCardPr = 0;
                    break;
                case "fire":
                    chosenCardPr = 3;
                    break;
                case "water":
                    chosenCardPr = 2;
                    break;
            }
        }
        else//takes activator elem
        {
            switch (ElemChar)
            {
                case "air":
                    chosenCardPr = 0;
                    break;
                case "earth":
                    chosenCardPr = 1;
                    break;
                case "fire":
                    chosenCardPr = 2;
                    break;
                case "water":
                    chosenCardPr = 3;
                    break;
            }
        }

        //set scale
        manager.cardPrefab.transform.localScale = manager.centrePos[0].transform.localScale;

        //card prefab editing past
        manager.cardPrefab.GetComponent<CardScriptReference>().cardData = choice[chosenCardPa];
        manager.cardPrefab.GetComponent<CardScriptReference>().isplayer = isPlayer;

        //instantiate past
        magicianCards[0] = Instantiate(manager.cardPrefab, manager.centrePos[0].transform.position, manager.centrePos[0].transform.rotation);

        //elem buff (after the instantiation)
        switch (chosenCardPa)
        {
            case 0:
                if (ElemChar == "air")
                    manager.cardPrefab.GetComponent<CardScriptReference>().value += manager.elemBuff;
                break;

            case 1:
                if (ElemChar == "earth")
                    manager.cardPrefab.GetComponent<CardScriptReference>().value += manager.elemBuff;
                break;

            case 2:
                if (ElemChar == "fire")
                    manager.cardPrefab.GetComponent<CardScriptReference>().value += manager.elemBuff;
                break;

            case 3:
                if (ElemChar == "water")
                    manager.cardPrefab.GetComponent<CardScriptReference>().value += manager.elemBuff;
                break;
        }



        //card prefab edit present
        manager.cardPrefab.GetComponent<CardScriptReference>().cardData = choice[chosenCardPr];

        //instantiate present
        magicianCards[1] = Instantiate(manager.cardPrefab, manager.centrePos[1].transform.position, manager.centrePos[1].transform.rotation);

        //elem buff
        switch (chosenCardPr)
        {
            case 0:
                if (ElemChar == "air")
                    manager.cardPrefab.GetComponent<CardScriptReference>().value += manager.elemBuff;
                break;

            case 1:
                if (ElemChar == "earth")
                    manager.cardPrefab.GetComponent<CardScriptReference>().value += manager.elemBuff;
                break;

            case 2:
                if (ElemChar == "fire")
                    manager.cardPrefab.GetComponent<CardScriptReference>().value += manager.elemBuff;
                break;

            case 3:
                if (ElemChar == "water")
                    manager.cardPrefab.GetComponent<CardScriptReference>().value += manager.elemBuff;
                break;
        }

        //return scale to normal
        manager.cardPrefab.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

        //play cards
        StartCoroutine("fauxPlay");
    }

    IEnumerator fauxPlay()
    {
        manager.vfxManager.Activate(magicianCards[0], 0);
        yield return new WaitForSeconds(manager.dySingle);
        manager.Past.past(magicianCards[0]);

        manager.vfxManager.Activate(magicianCards[1], 1);
        yield return new WaitForSeconds(manager.dySingle);
        manager.Present.present(magicianCards[1]);

    }
}
