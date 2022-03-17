using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnWin : MonoBehaviour
{
    public GameObject Enemy; 
    public static bool SceneWasLoaded;
    public int levelIndex;
    private int currentWinNum = 0;
    
    //general rules:
    //do what ya want here, literally just triggering it
    //if you're curious, this script is in the HPHandler

    public void WinLevel(int winNum)
    {
        currentWinNum = winNum;
        if (currentWinNum > PlayerPrefs.GetInt("Lv" + levelIndex))
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, winNum);
        }
    }
    public void win() //just don't change this name of the public void
    {
        Debug.Log("player win");

        // SceneManager.LoadScene("Level1");

        // if (Interactable.enemyType == "normal")
        //{

        // SceneManager.LoadScene("Level1");
        // }
        //else if (Interactable.enemyType == "boss")
        // {
        //    SceneManager.LoadScene("DenisWorldMap");
        // }

       //  EnemyStates s = new EnemyStates();
      //  s.enemy1 = Enemy.SetActive(false);
      //  s.enemy2 = 
        SceneManager.LoadScene("LevelMechanics");
        SceneWasLoaded = true;//change to always load the previously loaded scene
        Enemy.SetActive(false);

        //if (!Enemy.CompareTag("Boss"))
       // {

           


         //   SceneManager.LoadScene("LevelMechanics");
          //  SceneWasLoaded = true;
            
       // }
      //  else if (Enemy.CompareTag("Boss"))
       // {
            
       //     WinLevel(1);
      //      SceneManager.LoadScene("DenisWorldMap");
          
      //  }

        



        StopAllCoroutines();//there was a bug on death (from tony)
    }
}
