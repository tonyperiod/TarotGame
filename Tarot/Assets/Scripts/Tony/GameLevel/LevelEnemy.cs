using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnemy : MonoBehaviour
{
    public ScriptableChar thisEnemy;

    public void OnCollisionEnter(Collision collision)
    {
        GameObject thisObj = this.gameObject;

        InterScene.currentEnemy = thisEnemy;
        Debug.Log(thisObj);
        InterScene.deadEnemies.Add(thisObj);
        Debug.Log(InterScene.deadEnemies);
        SceneManager.LoadScene("TonyCardTesting");
    }

}