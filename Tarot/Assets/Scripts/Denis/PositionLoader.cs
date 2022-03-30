using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PositionLoader : MonoBehaviour
{

    //public GameObject player;
    //public bool posSaved;
    //public GameObject Enemy1;
    //public GameObject Enemy2;
    //public GameObject Enemy3;
    //public GameObject Enemy4;
    //public GameObject Enemy5;
    //public GameObject Enemy6;
    //public static bool en1Dead;
    //public static bool en2Dead;
    //public static bool en3Dead;            //these bools are to check if each enemy is already dead so they don't respawn upon killing another enemy
    //public int levelIndex;
    //private int currentWinNum = 0;

    //public void WinLevel(int winNum)
    //{
    //    currentWinNum = winNum;
    //    if (currentWinNum > PlayerPrefs.GetInt("Lv" + levelIndex))
    //    {
    //        PlayerPrefs.SetInt("Lv" + levelIndex, winNum);
    //    }
    //}
    //// Start is called before the first frame update
    //void Start()
    //{
    //   if(PlayerPrefs.GetInt("en1Dead") == 1)
    //    {
    //        Enemy1.SetActive(false);
    //    }

    //    if (PlayerPrefs.GetInt("en2Dead") == 1)
    //    {
    //        Enemy2.SetActive(false);
    //    }

    //    if (PlayerPrefs.GetInt("en3Dead") == 1)
    //    {
    //        Enemy3.SetActive(false);
    //    }

    //    if (PlayerPrefs.GetInt("en4Dead") == 1)
    //    {
    //        Enemy4.SetActive(false);
    //    }

    //    if (PlayerPrefs.GetInt("en5Dead") == 1)
    //    {
    //        Enemy5.SetActive(false);
    //    }

    //    if (PlayerPrefs.GetInt("en6Dead") == 1)
    //    {
    //        Enemy6.SetActive(false);
    //    }
    //}

    //public void LoadPosition()
    //{
    //    player.transform.position = new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), PlayerPrefs.GetFloat("Z"));
    //    Debug.Log("player position loaded");
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (OnWin.SceneWasLoaded)
    //    {
    //        LoadPosition();
    //        OnWin.SceneWasLoaded = false;

    //        if (PlayerPrefs.GetInt("enemyNo") == 1)
    //        {
    //            PlayerPrefs.SetInt("en1Dead", 1);
    //            PlayerPrefs.SetInt("gold", (PlayerPrefs.GetInt("gold") +1));
    //        }
    //        if (PlayerPrefs.GetInt("en1Dead") == 1)
    //        {
    //            Enemy1.SetActive(false);
                
    //        }


    //        if (PlayerPrefs.GetInt("enemyNo") == 2)
    //        {
    //            PlayerPrefs.SetInt("en2Dead", 1);
    //            PlayerPrefs.SetInt("gold", (PlayerPrefs.GetInt("gold") + 1));
    //        }

    //         if   (PlayerPrefs.GetInt("en2Dead") == 1)
                    
    //        {
    //            Enemy2.SetActive(false);
                
    //        }


    //        if (PlayerPrefs.GetInt("enemyNo") == 3)
    //            {
    //            PlayerPrefs.SetInt("en3Dead", 1);
    //            PlayerPrefs.SetInt("gold", (PlayerPrefs.GetInt("gold") + 1));
    //        }

    //         if   (PlayerPrefs.GetInt("en3Dead") == 1)
    //        {
    //            Enemy3.SetActive(false);
                
    //            WinLevel(1);
    //        }
    //        //^for level 1
    //        //level 2 bellow:

    //        if (PlayerPrefs.GetInt("enemyNo") == 4)
    //        {
    //            PlayerPrefs.SetInt("en4Dead", 1);
    //            PlayerPrefs.SetInt("gold", (PlayerPrefs.GetInt("gold") + 1));
    //        }
                
    //         if   (PlayerPrefs.GetInt("en4Dead") == 1)
    //        {
    //             Enemy4.SetActive(false);
    //        }

    //        if (PlayerPrefs.GetInt("enemyNo") == 5)

    //        {
    //            PlayerPrefs.SetInt("en5Dead", 1);
    //            PlayerPrefs.SetInt("gold", (PlayerPrefs.GetInt("gold") + 1));

    //        }
    //        if (PlayerPrefs.GetInt("en5Dead") == 1)
    //        {
    //                Enemy5.SetActive(false);
                   
    //        }
    //        if (PlayerPrefs.GetInt("enemyNo") == 6)
    //        {
    //            PlayerPrefs.SetInt("en6Dead", 1);
    //            PlayerPrefs.SetInt("gold", (PlayerPrefs.GetInt("gold") + 1));
    //        }
    //        if (PlayerPrefs.GetInt("en6Dead") == 1)
    //        {
    //                Enemy6.SetActive(false);
                    
    //                WinLevel(2);

    //                // PlayerPrefs.SetInt("enemyNo") = 4; // to save that the miniboss has been defeated 

    //        }
    //    }

    //    if (OnDeath.SceneWasLoaded)
    //    {
    //        if (en1Dead == true)
    //        {
    //            Enemy1.SetActive(false);
    //            en1Dead = true;
    //        }
    //        if (en2Dead == true)
    //        {
    //            Enemy2.SetActive(false);
    //            en2Dead = true;
    //        }
    //        if (en3Dead == true)
    //        {
    //            Enemy3.SetActive(false);
    //            en3Dead = true;

    //            WinLevel(1);
    //            SceneManager.LoadScene("DenisWorldMap");

    //        }
    //    }
    //}
}
