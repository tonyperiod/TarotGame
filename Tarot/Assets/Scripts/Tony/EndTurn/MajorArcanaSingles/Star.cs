using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    public ScriptableCard waterSpawned;//they're all water 8s
    GameObject[] starCards; //the cards this script generates

    bool isBuffed;


    public void Activate(GameObject c, bool isPlayer)
    {
        starCards = new GameObject[3];//set starcards as a 3 element array, clearing old one
        isBuffed = false;

        if (isPlayer)
        {
            //card elemental buff
            if (manager.PRef.element == "water")
                isBuffed = true;

            //counter enemy elem
            if (manager.lastTurnCards[7].GetComponent<CardScriptReference>().elem == "fire")
                manager.MajorDummy.Substitute(7);//put dummy instead

            manager.dyMajP = manager.dySingle * 3;
        }
        else
        {
            //card elemental buff
            if (manager.ERef.element == "water")
                isBuffed = true;

            //counter player elem
            if (manager.lastTurnCards[6].GetComponent<CardScriptReference>().elem == "fire")
                manager.MajorDummy.Substitute(6);//put dummy instead

            manager.dyMajE = manager.dySingle * 3;

        }
        //changes on all cards
        manager.cardPrefab.GetComponent<CardScriptReference>().cardData = waterSpawned;
        manager.cardPrefab.GetComponent<CardScriptReference>().isplayer = isPlayer;//this gets changed per activation, no need to split

        //place cards (for aesthethics)
        manager.cardPrefab.transform.localScale = manager.centrePos[0].transform.localScale; //centre pos is scaled differently

        for (int i = 0; i < 3; i++)
        {
            starCards[i] = Instantiate(manager.cardPrefab, manager.centrePos[i].transform.position, manager.centrePos[i].transform.rotation);

            //elem buff
            if (isBuffed == true)
                manager.cardPrefab.GetComponent<CardScriptReference>().value += manager.elemBuff;
        }




        //reset scale
        manager.cardPrefab.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);//reset to normal scale

        //activate cards with dysing/3
        StartCoroutine("fauxPlay");
    }

    IEnumerator fauxPlay()
    {
        manager.vfxManager.Activate(starCards[0], 0);        
        yield return new WaitForSeconds(manager.dySingle); // /6 because gave myself /2 after activation
        manager.Past.past(starCards[0]);

        manager.vfxManager.Activate(starCards[1], 1);
        yield return new WaitForSeconds(manager.dySingle);
        manager.Present.present(starCards[1]);

        manager.vfxManager.Activate(starCards[2], 2);
        yield return new WaitForSeconds(manager.dySingle);
        manager.PastFuture.pastfuture(starCards[2], false);
    }
}
