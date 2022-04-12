using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnemy : MonoBehaviour
{
    public ScriptableChar thisEnemy;
    public bool isMiniboss;

    private void Start()
    {
        //destroy if on list
        if (InterScene.deadEnemies.Contains(this.gameObject.name))
            {
            if (this.isMiniboss == true)
                InterScene.isMinibossDead = true;//just in case
            Destroy(this.gameObject);
        }
        //this is to turn on collider if alive
        else
        {
            this.GetComponent<CapsuleCollider>().enabled = true;
            this.GetComponent<SphereCollider>().enabled = true;
        }

        //set the sprite
        GetComponent<SpriteRenderer>().sprite = thisEnemy.ArtworkChibi;
    }

    public void OnCollisionEnter(Collision collision)
    {
        GameObject thisObj = this.gameObject;
        InterScene.deadEnemies.Add(thisObj.name);
        //Debug.Log(InterScene.deadEnemies.Count);

        InterScene.currentEnemy = thisEnemy;

        InterScene.lastLoc = thisObj.transform.position;
        //Debug.Log(InterScene.lastLoc);
        InterScene.currentScene = SceneManager.GetActiveScene().name;
        InterScene.currentSceneNumber = SceneManager.GetActiveScene().buildIndex; // for shop rng manager
        //Debug.Log(InterScene.currentScene);

        //isminibossDead (set it immediatly just in case you win)
        if (InterScene.isMinibossDead == false) //put condition in case player fights minor enemies afterwords
            InterScene.isMinibossDead = isMiniboss;

        SceneManager.LoadScene("TonyCardTesting");
    }
}