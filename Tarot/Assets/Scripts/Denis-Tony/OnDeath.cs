using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//custom script
//plays when player dies
public class OnDeath : MonoBehaviour
{
    public static bool SceneWasLoaded;

    public void dead()
    {
        SceneWasLoaded = true;
        StopAllCoroutines();//there was a bug on death


        SceneManager.LoadScene("ConnerMainMenu");//load main menu, there is a script in that scene that resets all parameters 
    }   
}