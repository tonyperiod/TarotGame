using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    // Declare public and private variables
    public GameObject gameObject;
    // Get a reference to InterScene parameter
    InterScene interScene;


    // Start is called before the first frame update
    void Start()
    {
        // Use InterScene parameter to Destroy the Tutorial if Tutorial is set to false.
        // Leave the IF part of the statment blank so that it can run the tutorial as normal.
        // The InterScene parameter will only run on level 1 (tutorial will only run on level 1).
       if (InterScene.isTutorial == true)
       {
           
       }
       else
       {
          Destroy(gameObject); 
       }

    }

    public void SkipTutorial()
    {
        // This function will remove the tutorial completely from the screen if the Skip Tutorial option is selected
        InterScene.isTutorial = false;
    } 

}
