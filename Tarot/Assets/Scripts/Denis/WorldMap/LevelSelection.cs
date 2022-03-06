using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class LevelSelection : MonoBehaviour
{
    [SerializeField] private bool unlocked;//default is false
    public Image unlockImage;
    public Image footstepsImage;
    public GameObject[] stars;
    private void Update()
    {
        UpdateLevelImage();
    }
    public void UpdateLevelImage()
    {
        if (!unlocked)
        {
            unlockImage.gameObject.SetActive(true);
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(false);

            }

            footstepsImage.gameObject.SetActive(false);
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(true);

            }


        }
        else
        {
            unlockImage.gameObject.SetActive(false);
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(true);

            }

            footstepsImage.gameObject.SetActive(true);
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(false);

            }


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