using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressTracker : MonoBehaviour
{
    public GameObject player;
    public bool posSaved;
    public static bool SceneWasLoaded;
    public static bool miniBoss1Dead;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void save()
    {
        var xPos = player.transform.position.x;
        var yPos = player.transform.position.y;
        var zPos = player.transform.position.z;
        PlayerPrefs.SetFloat("X", xPos);
        PlayerPrefs.SetFloat("Y", yPos);
        PlayerPrefs.SetFloat("Z", zPos);
        PlayerPrefs.Save();
        posSaved = true;
        Debug.Log("player position saved");
    }


    public void LoadPosition()
    {
        player.transform.position = new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), PlayerPrefs.GetFloat("Z"));
        Debug.Log("player position loaded");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            save();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            LoadPosition();
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("LevelMechanics");
            SceneWasLoaded = true;
            
           
        }

        if(Input.GetKeyDown(KeyCode.Y))
        {
            miniBoss1Dead = true;
           
        }

        
    }
    
}
