using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeManager : MonoBehaviour
{
    public PlayerInGameDeck playeringamedeck;
    public EnemyInGameDeck enemyingamedeck;
    //public EndTurn endTurn;
    public EndTurnCustomAwake endturn;

    public EnemyReference enemyreference;
    public PlayerReference playerreference;

    public SlotsTaken slotstaken;

    public AudioManager aMan;
    public GameObject[] backDrops;


    private void Awake()
    {
        loadBackdrop();
        enemyreference.CustomAwake();
        playerreference.CustomAwake();


        playeringamedeck.CustomAwake();
        enemyingamedeck.CustomAwake();

        slotstaken.CustomAwake();
        aMan.CustomAwake();
        endturn.CustomAwake();        
    }

    private void loadBackdrop()
    {
        int sn = InterScene.currentSceneNumber - 3;//0 both on lvl 1 against normal enemy and as a default
        
        if (sn < 0)
            sn = 0;//for the default value of 0 in testing
        switch (sn)
        {
            case 0:
                if (InterScene.fightingMiniboss == false)
                    backDrops[0].SetActive(true);
                else
                    backDrops[1].SetActive(true);
                break;
            case 1:
                if (InterScene.fightingMiniboss == false)
                    backDrops[2].SetActive(true);
                else
                    backDrops[3].SetActive(true);
                break;
            case 2:
                if (InterScene.fightingMiniboss == false)
                    backDrops[4].SetActive(true);
                else
                    backDrops[5].SetActive(true);
                break;
            case 3:
                if (InterScene.fightingMiniboss == false)
                    backDrops[6].SetActive(true);
                else
                    backDrops[7].SetActive(true);
                break;
        }
    }
}