using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnemy : MonoBehaviour
{
    public ScriptableChar thisEnemy;

    private void Start()
    {
        //destroy if on list
        if (InterScene.deadEnemies.Contains(this.gameObject.name))
            {
            Destroy(this.gameObject);
        }
        //this is to turn on collider if alive
        else
        {
            this.GetComponent<CapsuleCollider>().enabled = true;
            this.GetComponent<SphereCollider>().enabled = true;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        GameObject thisObj = this.gameObject;
        InterScene.deadEnemies.Add(thisObj.name);
        Debug.Log(InterScene.deadEnemies.Count);

        InterScene.currentEnemy = thisEnemy;

        InterScene.lastLoc = thisObj.transform.position;
        Debug.Log(InterScene.lastLoc);
        InterScene.currentScene = SceneManager.GetActiveScene().name;
        Debug.Log(InterScene.currentScene);

        SceneManager.LoadScene("TonyCardTesting");
    }
}