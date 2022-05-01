using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//custom script
//player win
public class OnWin : MonoBehaviour
{
    public void win()
    {
        StopAllCoroutines();//there was a bug on death
        SceneManager.LoadScene("TonyShop");
    }
}