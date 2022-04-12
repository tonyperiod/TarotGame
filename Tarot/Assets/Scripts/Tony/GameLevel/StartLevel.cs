using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    public GameObject player;
    public GameObject respawn;
    public ScriptableChar defaultPlayer;

    void Awake()
    {
        //set deadenemies list in case -> the actual destroy is on levelenemy
        if (InterScene.deadEnemies == null)
        {
            //Debug.Log("creating new list");
            InterScene.deadEnemies = new List<string>();
        }

        //load location
        if (InterScene.isFirstSpawn == true)
        {
            //separate to not start game in ground
            InterScene.lastLoc.x = respawn.transform.position.x;
            InterScene.lastLoc.z = respawn.transform.position.z;
            InterScene.lastLoc.y = respawn.transform.position.y +1;
            InterScene.isFirstSpawn = false;
        }

        player.transform.position = InterScene.lastLoc;

        //for testing
        if (InterScene.currentPlayer == null)
            InterScene.currentPlayer = defaultPlayer;
    }
}