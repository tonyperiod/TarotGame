using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom script
//resets necessary parameters in the main menu, so that if a player looses they won't be carried over
public class StartGame : MonoBehaviour
{
    public ScriptableCardDatabase playerStarter;
    public ScriptableCardDatabase playerInGame;
    public ScriptableCardDatabase shopAllDataInGame;
    public ScriptableCardDatabase shopAllData;
    private void Start()
    {
      
        //reset shop deck
        shopAllDataInGame.allCards.Clear();
        shopAllDataInGame.allCards = new List<ScriptableCard>(shopAllData.allCards);

        //reset player deck
        playerInGame.allCards.Clear();
        playerInGame.allCards = new List<ScriptableCard>(playerStarter.allCards);

        InterScene.defeatedLevels = 0; //reset defeated lvls
        if (InterScene.deadEnemies != null)
            InterScene.deadEnemies.Clear();//reset defeated enemies
        InterScene.isTutorial = true;
        InterScene.isNotNewGame = true;
    }
}

