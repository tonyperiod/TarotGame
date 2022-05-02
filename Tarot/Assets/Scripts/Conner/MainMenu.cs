using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        // If the Play Game button is clicked then the next scene in the build settings will activate
        // The next scene in the build settings will be the Character Selection Screen.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void QuitGame ()
    {
        // Quit game if the Quit Game button is selected.
        Debug.Log("Quit"); 
        // Add a Debug.Log as the game won't close when in the Unity Editor - this is to check this is running.
        Application.Quit(); 

    }
}
