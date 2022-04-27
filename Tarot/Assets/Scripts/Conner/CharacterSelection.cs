using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;

    public ScriptableChar[] scriptableCharacterSelection;//tony addon for game functionality

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
        InterScene.currentPlayer = scriptableCharacterSelection[selectedCharacter];//tony addon for game functionality
        SceneManager.LoadScene("DenisWorldMap");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("ConnerMainMenu");
    }


}
