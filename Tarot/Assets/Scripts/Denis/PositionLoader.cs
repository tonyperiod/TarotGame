using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PositionLoader : MonoBehaviour
{

    public GameObject player;
    public bool posSaved;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public static bool en1Dead;
    public static bool en2Dead;
    public static bool en3Dead;            //these bools are to check if each enemy is already dead so they don't respawn upon killing another enemy
    public int levelIndex;
    private int currentWinNum = 0;

    public void WinLevel(int winNum)
    {
        currentWinNum = winNum;
        if (currentWinNum > PlayerPrefs.GetInt("Lv" + levelIndex))
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, winNum);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadPosition()
    {
        player.transform.position = new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), PlayerPrefs.GetFloat("Z"));
        Debug.Log("player position loaded");
    }

    // Update is called once per frame
    void Update()
    {
        if (OnWin.SceneWasLoaded)
        {
            LoadPosition();
            OnWin.SceneWasLoaded = false;
            if (PlayerPrefs.GetInt("enemyNo") == 1 || en1Dead == true)
            {
                Enemy1.SetActive(false);
                en1Dead = true;
            }
            if (PlayerPrefs.GetInt("enemyNo") == 2 || en2Dead == true)
            {
                Enemy2.SetActive(false);
                en2Dead = true;
            }
            if (PlayerPrefs.GetInt("enemyNo") == 3 || en3Dead == true)
            {
                Enemy3.SetActive(false);
                en3Dead = true;
                WinLevel(1);
               
                
               // PlayerPrefs.SetInt("enemyNo") = 4; // to save that the miniboss has been defeated 
                
            }
        }

        if (OnDeath.SceneWasLoaded)
        {
            if (en1Dead == true)
            {
                Enemy1.SetActive(false);
                en1Dead = true;
            }
            if (en2Dead == true)
            {
                Enemy2.SetActive(false);
                en2Dead = true;
            }
            if (en3Dead == true)
            {
                Enemy3.SetActive(false);
                en3Dead = true;

                WinLevel(1);
                SceneManager.LoadScene("DenisWorldMap");

            }
        }
    }
}
