using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXPresent : MonoBehaviour
{
    [SerializeField] VFXManager manager;

    string cardElement;
    int cardValue;


    //card = the currently played card
    public void activate(GameObject card) //don't touch the starting line, the rest do what ya want
    {
        //getting the references that are necessary per every card played
        cardElement = card.GetComponent<CardScriptReference>().elem;
        //cardValue = card.GetComponent<CardScriptReference>().value;

       
        //activating the script for the actual vfx
        actualEffectActivation(card);

    }


    private void actualEffectActivation(GameObject card)
    {
        switch (cardElement)
        {
            case "air":

                //shoot to and from correct spot
                if (card.GetComponent<CardScriptReference>().isplayer == true)
                {
                    manager.presentVFX[0].GetComponentInChildren<SpawnMeteor>().startPoint = manager.playerStTransf;
                    manager.presentVFX[0].GetComponentInChildren<SpawnMeteor>().endPoint = manager.enemyEndTransf;
                }
                else
                {
                    manager.presentVFX[0].GetComponentInChildren<SpawnMeteor>().startPoint = manager.enemyStTransf;
                    manager.presentVFX[0].GetComponentInChildren<SpawnMeteor>().endPoint = manager.playerEndTransf;
                }

                manager.presentVFX[0].GetComponentInChildren<SpawnMeteor>().Activate();
                break;

            case "earth":

                if (card.GetComponent<CardScriptReference>().isplayer == true)
                {
                    manager.presentVFX[1].GetComponentInChildren<SpawnMeteor>().startPoint = manager.playerStTransf;
                    manager.presentVFX[1].GetComponentInChildren<SpawnMeteor>().endPoint = manager.enemyEndTransf;
                }
                else
                {
                    manager.presentVFX[1].GetComponentInChildren<SpawnMeteor>().startPoint = manager.enemyStTransf;
                    manager.presentVFX[1].GetComponentInChildren<SpawnMeteor>().endPoint = manager.playerEndTransf;
                }

                manager.presentVFX[1].GetComponentInChildren<SpawnMeteor>().Activate();
                break;

            case "fire":
                if (card.GetComponent<CardScriptReference>().isplayer == true)
                {
                    manager.presentVFX[2].GetComponentInChildren<SpawnMeteor>().startPoint = manager.playerStTransf;
                    manager.presentVFX[2].GetComponentInChildren<SpawnMeteor>().endPoint = manager.enemyEndTransf;
                }
                else
                {
                    manager.presentVFX[2].GetComponentInChildren<SpawnMeteor>().startPoint = manager.enemyStTransf;
                    manager.presentVFX[2].GetComponentInChildren<SpawnMeteor>().endPoint = manager.playerEndTransf;
                }

                manager.presentVFX[2].GetComponentInChildren<SpawnMeteor>().Activate();
                break;

            case "water":
                //old water
                //card.transform.GetChild(4).gameObject.SetActive(true);
                //card.GetComponent<CardScriptReference>().visualEffects[1].Play();

                //basically doing spawn meteor again
                Vector3 startPos = new Vector3(0,0,0);
                Vector3 endPos = new Vector3(0, 0, 0);

                if (card.GetComponent<CardScriptReference>().isplayer == true)
                {
                    startPos = manager.playerEndTransf.position;
                    endPos = manager.enemyEndTransf.position;
                }
                else
                {
                    startPos = manager.enemyEndTransf.position;
                    endPos = manager.playerEndTransf.position;
                }

                GameObject objVFX = Instantiate(manager.presentVFX[3], startPos, Quaternion.identity) as GameObject;

                var direction = endPos - objVFX.transform.position;
                var rotation = Quaternion.LookRotation(direction);
                objVFX.transform.localRotation = Quaternion.Lerp(objVFX.transform.rotation, rotation, 1);
                break;

            case "court":
                court(card);
                break;
        }
    }

    private void court(GameObject court)
    {

        //element 1
        court.GetComponent<CardScriptReference>().elem = court.GetComponent<CardScriptReference>().court1;//temp edit to elem
        activate(court);//activate script as usual


        //element 2
        court.GetComponent<CardScriptReference>().elem = court.GetComponent<CardScriptReference>().court2;
        activate(court);//activate script as usual;

        //return stuff to original     
        court.GetComponent<CardScriptReference>().elem = "court";
    }
}
