using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    public GameObject player;
    public GameObject respawn;

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
            InterScene.lastLoc = respawn.transform.position;
            InterScene.isFirstSpawn = false;
        }

        player.transform.position = InterScene.lastLoc;
    }
}