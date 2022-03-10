using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBattle : MonoBehaviour
{
    public Scene battleScene;
    public Scene winScene;
    public Scene loseScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startBattle(string _LevelName)
    {
        SceneManager.LoadScene(_LevelName);
    }
}
