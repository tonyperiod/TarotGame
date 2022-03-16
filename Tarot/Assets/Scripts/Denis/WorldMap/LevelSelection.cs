using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class LevelSelection : MonoBehaviour
{
    [SerializeField] private bool unlocked;//default is false
    public GameObject unlockImage;
    public GameObject footstepsImage;
    //public GameObject[] stars;
    private void Update()
    {
        UpdateLevelImage();
        UpdateLevelStatus();
    }

    private void UpdateLevelStatus()
    {
        int previousLevelNum = int.Parse(gameObject.name) - 1;
        if (PlayerPrefs.GetInt("Lv" + previousLevelNum.ToString()) > 0)
        {
            unlocked = true;
        }
    }
    public void UpdateLevelImage()
    {
        if (!unlocked)
        {
            unlockImage.gameObject.SetActive(true);
         //  for (int i = 0; i < stars.Length; i++)
          //  {
            //    stars[i].gameObject.SetActive(false);

         //   }

            footstepsImage.gameObject.SetActive(false);
          //  for (int i = 0; i < stars.Length; i++)
          //  {
          //      stars[i].gameObject.SetActive(true);

        //    }


        }
        else
        {
            unlockImage.gameObject.SetActive(false);
           // for (int i = 0; i < stars.Length; i++)
          //  {
          //      stars[i].gameObject.SetActive(true);

       //     }

            footstepsImage.gameObject.SetActive(true);
        //    for (int i = 0; i < stars.Length; i++)
       //     {
        //        stars[i].gameObject.SetActive(false);

         //   }
         


        }

        
    }
    public void PressSelection(string _LevelName)
    {
        if(unlocked)
        {
            SceneManager.LoadScene(_LevelName);
        }
    }
}
