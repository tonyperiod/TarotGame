using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnDeath : MonoBehaviour
{


    //general rules:
    //do what ya want here, literally just triggering it
    //if you're curious, this script is in the HPHandler

    public GameObject player;
   // public bool posSaved;
    public static bool SceneWasLoaded;

    public void dead() //just don't change this name of the public void
    {


        
        SceneManager.LoadScene("Level1");
        SceneWasLoaded = true;
        //OnWin.enemyDead = false;

        StopAllCoroutines();//there was a bug on death (from tony)
    }
   
}
