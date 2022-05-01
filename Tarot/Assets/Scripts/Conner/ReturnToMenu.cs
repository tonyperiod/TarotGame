using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        // If the return to main menu button is selected in the EndOfDemo scene then the Main Menu screen will re-activate.
        SceneManager.LoadScene("ConnerMainMenu");
    }

}
