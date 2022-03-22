using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterScene : MonoBehaviour
{
    //constant
    public static ScriptableChar currentPlayer;//for player element

    // to reset at end of gamelevel-----------------
    
    public static List<string> deadEnemies; //create new list on starting from the char selection
    public static bool isnotfirst;

    //set by enemies------------------
    public static ScriptableChar currentEnemy;//for enemy scriptable objct  
    public static Vector3 lastLoc;
    public static string currentScene;

    public static int goldPlayer;

}
