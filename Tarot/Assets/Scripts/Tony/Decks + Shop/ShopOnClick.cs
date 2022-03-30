using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopOnClick : MonoBehaviour
{
    [SerializeField] Shop manager;

    private void OnMouseDown()
    {
        manager.shopBuy.Buy();
        //load level back
        SceneManager.LoadScene(InterScene.currentScene);
    }
}
