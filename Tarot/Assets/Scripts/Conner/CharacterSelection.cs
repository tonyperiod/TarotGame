using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    // Declare public variables
    public GameObject[] characters;
    public int selectedCharacter = 0;

    public ScriptableChar[] scriptableCharacterSelection; //tony addon for game functionality

    void Start()
    {

    }

    public void NextCharacter()
    {
        // This function tells the game what will happen when the player clicks the next button on the character selection screen.
        // If the next button is selected, then it will move to the next character in the array list. 
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        // This function tells the game what will happen when the player clicks the previous button on the main menu
        // This button will return to the previous character in the array list. 
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;

        // IF Statement to check if the characters are between 0 and 3. 
        if (selectedCharacter < 0)
        {
            // Set character back to default if not equal to 0 - 3.
            selectedCharacter += characters.Length;
        }

        characters[selectedCharacter].SetActive(true);
    }

    public void PlayGame()
    {
        InterScene.currentPlayer = scriptableCharacterSelection[selectedCharacter];//tony addon for game functionality

        // Load Denis's World Map scene if the player click on the Play Game button.
        SceneManager.LoadScene("DenisWorldMap");
    }

    public void BackToMenu()
    {
        // Go back to the main menu scene if the player click on the Main Menu button.
        SceneManager.LoadScene("ConnerMainMenu");
    }


}
