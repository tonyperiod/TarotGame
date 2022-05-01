using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//custom script
//resets the parameters that need to be reset
public class ExitPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && InterScene.isMinibossDead == true)
        {
            InterScene.isMinibossDead = false;
            InterScene.defeatedLevels += 1;
            InterScene.isFirstSpawn = true;//to spawn correctly in next lvl
            InterScene.deadEnemies.Clear();//so it doesn't carry over, bug found

            if (SceneManager.GetActiveScene().name == "Level4") //for demo purposes
                SceneManager.LoadScene("EndOfDemo");
            else
                SceneManager.LoadScene("DenisWorldMap");
        }
    }
}