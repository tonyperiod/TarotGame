using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPChange : MonoBehaviour
{
    HPSystem hpSystem;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        GameObject hpsystem = GameObject.Find("PlayerHPText");

    }

    // Update is called once per frame
    void Update()
    {
       
        //hpsystem.transform.GetComponent<Text>().text = "/" + hpsystem.getHP().ToString();
    }
}
