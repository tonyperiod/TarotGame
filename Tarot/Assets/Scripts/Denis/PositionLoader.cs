using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PositionLoader : MonoBehaviour
{

    public GameObject player;
    public bool posSaved;
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
        if (ProgressTracker.SceneWasLoaded)
        {
            LoadPosition();
            ProgressTracker.SceneWasLoaded = false;
        }
    }
}
