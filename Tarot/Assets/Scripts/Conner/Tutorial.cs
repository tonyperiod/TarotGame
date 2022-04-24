using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    Transform transform;
    GameObject gameObject; 


    // Start is called before the first frame update
    void Start()
    {
        transform = this.gameObject.transform.GetChild(2); 
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SkipTutorial()
    {
        gameObject.SetActive(false); 
    }
}
