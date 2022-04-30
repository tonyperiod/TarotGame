using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom script
//adds a card permanently to player deck
public class WheelOfFortune : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    [SerializeField] PlayerInGameDeck pDeck;
    [SerializeField] EnemyInGameDeck eDeck;

    [SerializeField] ScriptableCardDatabase shopAllDataInGame;//using this, will be reset every playthrough
    [SerializeField] ScriptableCardDatabase shopAllDataALL;//all the shop cards, will not remove and only for enemt
    
    //for destroy
    int slot;

    public void Activate(GameObject c, bool isPlayer)
    {
        
        //add card to player scriptable database PERMANENTLY, with enemy add to current list of cards
        if (isPlayer == true)
        {
            int randomSlot = Random.Range(0, shopAllDataInGame.allCards.Count);
            pDeck.playerDatabase.allCards.Add(shopAllDataInGame.allCards[randomSlot]);//add to player database PERMANENTLY
            shopAllDataInGame.allCards.Remove(shopAllDataInGame.allCards[randomSlot]);//remove to shopalldata PERMANENTLY
            slot = 9;
        }
        //slightly different, enemy only is in session. there will have to be a reset per combat
        else
        {
            int randomSlot = Random.Range(0, shopAllDataALL.allCards.Count);
            eDeck.enemyDatabaseInGame.allCards.Add(shopAllDataALL.allCards[randomSlot]); //do not remove from shop data, it is enemy

            slot = 11;

        }
            //destroy the card
            GameObject.Destroy(c);

            //create new dummy
            manager.MajorDummy.Create(slot);        
    }
}
