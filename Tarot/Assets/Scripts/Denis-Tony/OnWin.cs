using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnWin : MonoBehaviour
{
    //general rules:
    //do what ya want here, literally just triggering it
    //if you're curious, this script is in the HPHandler
   
    public void win() //just don't change this name of the public void
    {
        Debug.Log("player win");
        if (Interactable.enemyType == "normal")
        {
            
            SceneManager.LoadScene("Level1");
        }
        else if (Interactable.enemyType == "boss")
        {
            SceneManager.LoadScene("DenisWorldMap");
        }

    }
}
