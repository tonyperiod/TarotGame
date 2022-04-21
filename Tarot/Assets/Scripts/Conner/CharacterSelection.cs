using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;

    PlayerReference playerRef;

    void start()
    {

    }

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;

        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }

        characters[selectedCharacter].SetActive(true);
    }

    public void PlayGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene("DenisWorldMap");
        gameObject.transform.GetChild(3).transform.GetComponent<TextMesh>().text = this.GetComponent<PlayerReference>().playerSelectedElem;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("ConnerMainMenu");
    }
}
