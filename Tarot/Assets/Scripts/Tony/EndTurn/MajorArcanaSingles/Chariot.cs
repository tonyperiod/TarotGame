using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chariot : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    public ScriptableCard waterSpawned; //water 10 card
    [SerializeField] GameObject[] chariotCard;//the one card that it spawns
    [SerializeField] int positionP;//what position it currently is in
    int positionE;



    public void Activate(GameObject c, bool isPlayer)
    {
        chariotCard = new GameObject[1];
        int posInstance = 0;

        if (isPlayer)
        {
            //card elemental buff
            if (manager.PRef.element == "water")
                manager.cardPrefab.GetComponent<CardScriptReference>().value += manager.elemBuff;

            //counter enemy elem -> only if past
            if (manager.lastTurnCards[7].GetComponent<CardScriptReference>().elem == "fire" && positionP == 0)
                manager.MajorDummy.Substitute(7);//put dummy instead

            //set posinstance for the current activation
            posInstance = positionP;
            if (positionP <=1)
                positionP += 1; //it moves 1 slot per activation
            else
                positionP = 0; //returns to past

            //set dyMajP
            manager.dyMajP = manager.dySingle;
        }

        else
        {
            //card elemental buff
            if (manager.ERef.element == "water")
                manager.cardPrefab.GetComponent<CardScriptReference>().value += manager.elemBuff;

            //counter player elem -> only if past
            if (manager.lastTurnCards[6].GetComponent<CardScriptReference>().elem == "fire" && positionE == 0)
                manager.MajorDummy.Substitute(6);//put dummy instead

            //set posinstance for the current activation
            posInstance = positionE;
            if (positionE <= 1)
                positionE += 1; //it moves 1 slot per activation
            else
                positionE = 0; //returns to past

            //set dyMajE
            manager.dyMajE = manager.dySingle;
        }

        //set chariotCard[0]
        manager.cardPrefab.GetComponent<CardScriptReference>().cardData = waterSpawned;
        manager.cardPrefab.GetComponent<CardScriptReference>().isplayer = isPlayer;

        ////move card into position, spawning was bugging        
        //chariotCard[0] = manager.cardPrefab;
        //chariotCard[0].transform.position = manager.centrePos[posInstance].transform.position;
        //chariotCard[0].transform.rotation = manager.centrePos[posInstance].transform.rotation;
        //chariotCard[0].transform.localScale = manager.centrePos[0].transform.localScale; //centre pos is scaled differently

        manager.cardPrefab.transform.localScale = manager.centrePos[0].transform.localScale; //centre pos is scaled differently

        chariotCard[0] = Instantiate(manager.cardPrefab, manager.centrePos[posInstance].transform.position, manager.centrePos[posInstance].transform.rotation);
        manager.cardPrefab.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);//reset to normal scale

        switch (posInstance)
        {
            case 0:
                StartCoroutine("past");
                break;
            case 1:
                StartCoroutine("present");
                break;
            case 2:
                StartCoroutine("pastfuture");
                break;
        }


        //switch (posInstance)//logic only
        //{
        //    case 0:
        //        manager.Past.past(chariotCard[0]);
        //        break;
        //    case 1:
        //        manager.Present.present(chariotCard[0]);
        //        break;
        //    case 2:
        //        manager.PastFuture.pastfuture(chariotCard[0]);
        //        break;

        //}

    }

    IEnumerator past()
    {
        manager.vfxManager.Activate(chariotCard[0], 0);
        yield return new WaitForSeconds(manager.dySingle);
        manager.Past.past(chariotCard[0]);
    }
    IEnumerator present()
    {
        manager.vfxManager.Activate(chariotCard[0], 1);
        yield return new WaitForSeconds(manager.dySingle);
        manager.Present.present(chariotCard[0]);
    }
    IEnumerator pastfuture()
    {
        manager.vfxManager.Activate(chariotCard[0], 2);
        yield return new WaitForSeconds(manager.dySingle);
        manager.PastFuture.pastfuture(chariotCard[0]);
    }

    public void Destroyed()
    {
        //reset position
        positionP = 0;
        positionE = 0;
    }
}
