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
    public GameObject lights;



    //public GameObject[] stars;
    private void Start()
    {
        UpdateLevelStatus();
        UpdateLevelImage();
    }

    private void UpdateLevelStatus()
    {
        int previousLock = int.Parse(gameObject.name)-1;

        //old version
        //if (PlayerPrefs.GetInt("Lv" + thisLock.ToString()) > 0)
        //{
        //    unlocked = true;
        //}

        //with interscene instead
        Debug.Log(InterScene.defeatedLevels);

        if (previousLock <= InterScene.defeatedLevels)
            unlocked = true;

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

            lights.gameObject.SetActive(false);
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
            lights.gameObject.SetActive(true);


        }


    }
    public void PressSelection(string _LevelName)
    {
        if (unlocked)
        {
            SceneManager.LoadScene(_LevelName);
        }
    }
}
