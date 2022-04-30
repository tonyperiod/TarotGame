using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//custom awake manager
//with the amount of interscript communication I use, this is necessary to not have bugs by playing scripts in the correct order
public class ShopAwakeManager : MonoBehaviour
{
    [SerializeField] Shop shop;
    [SerializeField] ShopDeck deck;
    [SerializeField] ShopRNGManager rNGManager;
    [SerializeField] ShopPlaceCards placeCards;

    private void Awake()
    {
        shop.CustomAwake();
        deck.CustomAwake();
        rNGManager.CustomAwake();
        rNGManager.GetCardRNG(); 
    }

    private void Start()
    {
        shop.chooseCards();
        placeCards.CustomStart();
    }
}