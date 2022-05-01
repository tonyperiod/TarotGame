using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        // Testing script to see if the character would load into a new scene
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = characterPrefabs[selectedCharacter];
        // The character GameObject will be cloned into this new scene 
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        // Set the clone GameObject in the testing scene to values that are easy to see from the main camera. 
        clone.transform.position = new Vector3(0, 1, 1);
        clone.transform.localScale = new Vector3(1, 1, 1);

    }


}
