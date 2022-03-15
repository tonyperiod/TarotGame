using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SingleLevel : MonoBehaviour
{

    public GameObject pauseMenu;
    public static bool isPaused;
    public int levelIndex;
    private int currentWinNum = 0;


    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void WinTest(int winNum)
    {
        currentWinNum = winNum;
        if(currentWinNum > PlayerPrefs.GetInt("Lv" + levelIndex))
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, winNum);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();

            }
            else
            {
                PauseGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            WinTest(1);


        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

    }

    public void GoToWorldMap()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("DenisWorldMap");
    }

    public void ExitLevel()
    {
        SceneManager.LoadScene("DenisWorldMap");
    }
   
}
