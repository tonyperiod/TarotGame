using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBattle : MonoBehaviour
{
    public Scene battleScene;
    public Scene winScene;
    public Scene loseScene;

    public void startBattle(string _LevelName)
    {
        SceneManager.LoadScene(_LevelName);
    }
}
