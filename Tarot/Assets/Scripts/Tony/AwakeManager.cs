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

    private void Awake()
    {
        enemyreference.CustomAwake();
        playerreference.CustomAwake();


        playeringamedeck.CustomAwake();
        enemyingamedeck.CustomAwake();

        endturn.CA();        
    }
}