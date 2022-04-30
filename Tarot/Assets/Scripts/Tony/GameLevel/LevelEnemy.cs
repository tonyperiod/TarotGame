using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//custom script
//placed on enemies in the world
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
                InterScene.isMinibossDead = true;//just in case, to allow players to exit the game
            Destroy(this.gameObject);
        }
        //this is to turn on collider if alive
        //colliders off, because within the time it takes for code to load player could initiate battle again right after defeating an enemy
        else
        {
            this.GetComponent<CapsuleCollider>().enabled = true;
            this.GetComponent<SphereCollider>().enabled = true;
        }

        //set the sprite
        GetComponent<SpriteRenderer>().sprite = thisEnemy.ArtworkChibi;
    }

    //initiate combat
    public void OnCollisionEnter(Collision collision)
    {
        GameObject thisObj = this.gameObject;
        InterScene.deadEnemies.Add(thisObj.name);//if they are not dead it doesn't matter, as all will reset on loose

        InterScene.currentEnemy = thisEnemy;//for battle scene to get data

        InterScene.lastLoc = thisObj.transform.position;// to teleport the player here on win
        InterScene.currentScene = SceneManager.GetActiveScene().name;//to teleport player into correct scene on win
        InterScene.currentSceneNumber = SceneManager.GetActiveScene().buildIndex; // for shop rng manager
        
        if (InterScene.isMinibossDead == false) //put condition in case player fights minor enemies afterwords and get locked out of the rest of the game
            InterScene.isMinibossDead = isMiniboss;//if enemy is miniboss, set to win in case

        InterScene.fightingMiniboss = isMiniboss;//for the levelLoading

        SceneManager.LoadScene("TonyCardTesting");//battle scene name
    }
}