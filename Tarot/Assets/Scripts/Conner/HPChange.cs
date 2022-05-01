using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPChange : MonoBehaviour
{
    // Declare public and private variables

    // Reference Tony's hpSystem script so that the getHP and getSH functions can be accessed in this script.
    HPSystem hpSystem;
    public GameObject player;
    public GameObject enemy;
    public GameObject curr_hp;
    public GameObject curr_sh;


    public GameObject enemy_curr_hp;
    public GameObject enemy_curr_sh;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get the text component from the GameObject then set that text component to the HP from Tony's HPSystem Script.
        curr_hp.GetComponent<Text>().text = player.GetComponent<BarsPlayer>().hpsystem.getHP().ToString();
        // Do the same as above but with the shield value. 
        curr_sh.GetComponent<Text>().text = player.GetComponent<BarsPlayer>().shsystem.getSH().ToString();

        // Repeat this process for the enemy's current HP/Shield value.
        enemy_curr_hp.GetComponent<Text>().text = enemy.GetComponent<BarsEnemy>().hpsystem.getHP().ToString();
        enemy_curr_sh.GetComponent<Text>().text = enemy.GetComponent<BarsEnemy>().shsystem.getSH().ToString();

        // Set up a DontDestroyOnLoad so that we can reference these variables in the future.
        DontDestroyOnLoad(curr_hp);
        DontDestroyOnLoad(enemy_curr_hp);
    }

}
