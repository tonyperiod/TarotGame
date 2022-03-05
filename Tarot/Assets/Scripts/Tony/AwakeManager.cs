using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeManager : MonoBehaviour
{
    public PlayerInGameDeck playeringamedeck;
    public EnemyInGameDeck enemyingamedeck;
    public EndTurn endTurn;

    private void Awake()
    {
        playeringamedeck.CustomAwake();
        enemyingamedeck.CustomAwake();

        endTurn.CustomAwake();

    }

}
