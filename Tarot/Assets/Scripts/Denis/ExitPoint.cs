using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPoint : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && InterScene.isMinibossDead == true)
        {
            InterScene.isMinibossDead = false;
            SceneManager.LoadScene("DenisWorldMap");
        }
    }
}
