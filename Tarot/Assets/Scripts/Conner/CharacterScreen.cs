using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class CharacterScreen : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("ConnerMainMenu");
    }

    public void PlayGame()
    {
       SceneManager.LoadScene("DenisWorldMap");
    }
}
