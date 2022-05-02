using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class WinLose : MonoBehaviour
{
    HPSystem hpSystem;
    GameObject player;
    GameObject enemy;

    GameObject curr_hp;
    GameObject enemy_curr_hp;

    public GameObject winText;
    public GameObject loseText;

    public GameObject winLoseScreen;

    // Start is called before the first frame update
    void Start()
    {
        // Set win text automatically if the scene loads
        winText.SetActive(true);
    }


    void Update()
    {
        // If the current hp = 0 then the enemy wins the game and the players loses.
        if (curr_hp.Equals("0"))
        {
            loseText.SetActive(true);
            Debug.Log("if runs");
        }
        else
        {
            winText.SetActive(true);
            Debug.Log("else runs");
        }
    }



    // Update is called once per frame
    public void LoadShop()
    {
        // If the "To The Shop" button is selected, the shop scene will be loaded.
        SceneManager.LoadScene("TonyShop");
    }
    
}
