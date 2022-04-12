using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public ScriptableCardDatabase playerStarter;
    public ScriptableCardDatabase playerInGame;
    public ScriptableCardDatabase shopAllDataInGame;
    public ScriptableCardDatabase shopAllData;
    private void Start()
    {
        //get all cards and put into deck
        if (InterScene.isNotNewGame == false)
        {
            if (shopAllDataInGame != null)
                shopAllDataInGame.allCards.Clear();
            shopAllDataInGame.allCards = new List<ScriptableCard>(shopAllData.allCards);

            if (playerInGame != null)
                playerInGame.allCards.Clear();
            playerInGame.allCards = new List<ScriptableCard>(playerStarter.allCards);

            InterScene.isTutorial = true;

            Debug.Log(InterScene.isNotNewGame + " is notnew");
            InterScene.isNotNewGame = true;
        }
    }
}
