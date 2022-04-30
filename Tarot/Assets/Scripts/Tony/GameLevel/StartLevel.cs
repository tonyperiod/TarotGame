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
            InterScene.deadEnemies = new List<string>();
        }

        //load location
        if (InterScene.isFirstSpawn == true)//spawn to level start location if first time opening
        {
            //separate to not start game in ground
            InterScene.lastLoc.x = respawn.transform.position.x;
            InterScene.lastLoc.z = respawn.transform.position.z;
            InterScene.lastLoc.y = respawn.transform.position.y +1;
            InterScene.isFirstSpawn = false;
        }

        player.transform.position = InterScene.lastLoc;//if not first time, spawn to enemy location

        //for testing
        if (InterScene.currentPlayer == null)
            InterScene.currentPlayer = defaultPlayer;
    }
}