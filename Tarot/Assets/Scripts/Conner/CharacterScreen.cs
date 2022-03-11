using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterScreen : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("DenisWorldMap"); 
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("ConnerMainMenu");
    }
}
