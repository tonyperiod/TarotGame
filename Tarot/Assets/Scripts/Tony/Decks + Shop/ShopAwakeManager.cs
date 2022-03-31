using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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