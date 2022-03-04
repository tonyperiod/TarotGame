using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeManager : MonoBehaviour
{
    //getting reference to ALL scripts with an awake
    public PlayerInGameDeck playeringamedeck;
    public EnemyInGameDeck enemyingamedeck;



    public EndTurnManager endTurnManager;


    private void Awake()
    {
        playeringamedeck.CustomAwake();
        enemyingamedeck.CustomAwake();



        endTurnManager.CustomAwake();
    }


}
