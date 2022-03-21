using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public GameObject Enemy;
    
    
    //public static string enemyType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
                if (Enemy.name == "EnemyEasy1")
                {
                    PlayerPrefs.SetInt ("enemyNo", 1);
                }
                if (Enemy.name == "EnemyEasy2")
                {
                    PlayerPrefs.SetInt("enemyNo", 2);                  //stores the enemy that was interacted with last, accessed when scene is reloaded by position loader to deactivate them.
                }
                if (Enemy.name == "MiniBoss1")
                {
                    PlayerPrefs.SetInt("enemyNo", 3);
                }
                if (Enemy.name == "Enemy4")
                {
                    PlayerPrefs.SetInt("enemyNo", 4);
                    Debug.Log("enemy4 fight");
                }
                if (Enemy.name == "Enemy5")
                {
                    PlayerPrefs.SetInt("enemyNo", 5);                  //stores the enemy that was interacted with last, accessed when scene is reloaded by position loader to deactivate them.
                }
                if (Enemy.name == "MiniBoss2")
                {
                    PlayerPrefs.SetInt("enemyNo", 6);
                }


            }
        }

       

    }
    private void OnTriggerEnter(Collider collision)
    {

        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player now in range");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player now out of range");
        }
    }
}
