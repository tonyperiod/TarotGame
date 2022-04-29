using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPChange : MonoBehaviour
{
    HPSystem hpSystem;
    public GameObject player;
    public GameObject enemy;
    GameObject hi;
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
        curr_hp.GetComponent<Text>().text = player.GetComponent<BarsPlayer>().hpsystem.getHP().ToString();
        curr_sh.GetComponent<Text>().text = player.GetComponent<BarsPlayer>().shsystem.getSH().ToString();

        enemy_curr_hp.GetComponent<Text>().text = enemy.GetComponent<BarsEnemy>().hpsystem.getHP().ToString();
        enemy_curr_sh.GetComponent<Text>().text = enemy.GetComponent<BarsEnemy>().shsystem.getSH().ToString();

        DontDestroyOnLoad(curr_hp);
        DontDestroyOnLoad(enemy_curr_hp);
    }

}
