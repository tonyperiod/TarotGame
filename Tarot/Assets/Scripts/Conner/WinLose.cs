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

    GameObject playerCurrentHP;
    GameObject enemyCurrentHP;

    public GameObject winText;
    public GameObject loseText;

    // Start is called before the first frame update
    void Start()
    {
     

    }


    void Update()
    {

        if (InterScene.defeatedLevels == 0)
        {
            winText.SetActive(true);
        }

        else
        {
            loseText.SetActive(true);
        }   
    }



    // Update is called once per frame
    public void LoadShop()
    {
        SceneManager.LoadScene("TonyShop");
    }
    
}
