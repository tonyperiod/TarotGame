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
            if (PlayerPrefs.GetInt("enemyNo") == 1)
            {
                Enemy1.SetActive(false);
            }
            if (PlayerPrefs.GetInt("enemyNo") == 2)
            {
                Enemy2.SetActive(false);
            }
            if (PlayerPrefs.GetInt("enemyNo") == 3)
            {
                Enemy3.SetActive(false);
            }
        }
    }
}
