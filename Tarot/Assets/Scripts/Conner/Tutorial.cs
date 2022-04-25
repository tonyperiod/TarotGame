using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject gameObject;
    InterScene interScene;


    // Start is called before the first frame update
    void Start()
    {
       if (InterScene.isTutorial == true)
       {
           
       }
       else
       {
          Destroy(gameObject); 
       }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SkipTutorial()
    {
        InterScene.isTutorial = false;
    } 

    public void NextScreen()
    {
        
    }
}
