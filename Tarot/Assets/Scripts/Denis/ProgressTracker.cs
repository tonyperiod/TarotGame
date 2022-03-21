using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressTracker : MonoBehaviour
{
    public GameObject player;
    //public bool posSaved;
    public static bool SceneWasLoaded;
    public static bool miniBoss1Dead;
    Scene currentLevel;
    public static string levelName;
   

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
       // posSaved = true;
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
            currentLevel = SceneManager.GetActiveScene();
            levelName = currentLevel.name;
        }

    


      //  if(Input.GetKeyDown(KeyCode.Y))
       // {
          //  miniBoss1Dead = true;
           
      //  }

        if(Input.GetKeyDown(KeyCode.U))
        {
            PlayerPrefs.DeleteAll();
        }

        
    }
    
}
