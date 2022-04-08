using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judgement : MonoBehaviour
{
    [SerializeField] EndTurn manager;
    [SerializeField] GameObject[] judgementCards;

    GameObject card;
    int slot;


    public void Activate(GameObject c, bool isPlayer)
    {
        card = c;
        judgementCards = new GameObject[3];
        if (isPlayer == true)
        {
            //have to do them separately for lasturncards, instantiate new copies of player cards
            judgementCards[0] = Instantiate(manager.lastTurnCards[0], manager.centrePos[0].transform.position, manager.centrePos[0].transform.rotation);
            judgementCards[1] = Instantiate(manager.lastTurnCards[1], manager.centrePos[1].transform.position, manager.centrePos[1].transform.rotation);
            judgementCards[2] = Instantiate(manager.lastTurnCards[6], manager.centrePos[2].transform.position, manager.centrePos[2].transform.rotation);

            //scale fix
            for (int i = 0; i < 3; i++)
            {
                judgementCards[i].transform.localScale = manager.centrePos[0].transform.localScale;
            }

            //elemental buffs
            for (int i = 0; i < 3; i++)
            {
                if (judgementCards[i].GetComponent<CardScriptReference>().elem == manager.PRef.element)
                    judgementCards[i].GetComponent<CardScriptReference>().value += manager.elemBuff;
            }

            //set delay
            manager.dyMajP = manager.dySingle * 3;

            //for destroy
            slot = 9;

        }
        else
        {
            //have to do them separately for lasturncards, instantiate new copies of player cards
            judgementCards[0] = Instantiate(manager.lastTurnCards[3], manager.centrePos[0].transform.position, manager.centrePos[0].transform.rotation);
            judgementCards[1] = Instantiate(manager.lastTurnCards[4], manager.centrePos[1].transform.position, manager.centrePos[1].transform.rotation);
            judgementCards[2] = Instantiate(manager.lastTurnCards[7], manager.centrePos[2].transform.position, manager.centrePos[2].transform.rotation);


            //elemental buffs
            for (int i = 0; i < 3; i++)
            {
                if (judgementCards[i].GetComponent<CardScriptReference>().elem == manager.ERef.element)
                    judgementCards[i].GetComponent<CardScriptReference>().value += manager.elemBuff;
            }

            //set delay
            manager.dyMajE = manager.dySingle * 3;

            slot = 11;
        }

        //set is player
        for (int i = 0; i < 3; i++)
        {
            judgementCards[i].GetComponent<CardScriptReference>().isplayer = isPlayer;
        }

        StartCoroutine("fauxPlay");
        destroyCard();
    }

    IEnumerator fauxPlay()
    {
        manager.vfxManager.Activate(judgementCards[0], 0);
        yield return new WaitForSeconds(manager.dySingle); // /6 because gave myself /2 after activation
        manager.Past.past(judgementCards[0]);

        manager.vfxManager.Activate(judgementCards[1], 1);
        yield return new WaitForSeconds(manager.dySingle);
        manager.Present.present(judgementCards[1]);

        manager.vfxManager.Activate(judgementCards[2], 2);
        yield return new WaitForSeconds(manager.dySingle);
        manager.PastFuture.pastfuture(judgementCards[2]);
        destroyCard();

    }

    void destroyCard()
    {
        //destroy the card
        GameObject.Destroy(card);

        //create new dummy
        manager.MajorDummy.Create(slot);
    }
}