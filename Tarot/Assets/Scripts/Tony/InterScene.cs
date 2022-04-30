using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//custom script
//this saves all parameters used battle/walking parts
public class InterScene : MonoBehaviour
{
    //constant-----------------
    public static ScriptableChar currentPlayer;//for player element, and for sprite in game

    //set game start-----------------
    public static bool isNotNewGame;
    public static bool isTutorial;

    // to reset at end of gamelevel-----------------

    public static List<string> deadEnemies; //create new list on starting from the char selection
    public static bool isFirstSpawn = true;

    //set by enemies------------------
    public static ScriptableChar currentEnemy;//for enemy scriptable objct  
    public static Vector3 lastLoc;
    public static string currentScene; 
    public static int currentSceneNumber; //int to make it easier for the shopRNGManager
    public static int goldPlayer;
    public static bool isMinibossDead;//keep constant in level in case of backtracking
    public static bool fightingMiniboss; //for the scene backdrop loading

    //won battle
    public static int defeatedLevels;
}
