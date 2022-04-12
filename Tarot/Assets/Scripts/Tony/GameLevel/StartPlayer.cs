using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;


public class StartPlayer : MonoBehaviour
{
    //this should work
    public SpriteLibraryAsset[] spriteLibraries;

    int elemNumber;

    // Start is called before the first frame update
    void Start()
    {
        if (InterScene.currentPlayer == null)
            elemNumber = 1;
        else
        {
            //get player element
            switch (InterScene.currentPlayer.Element)
            {
                case "air":
                    elemNumber = 0;
                    break;
                case "earth":
                    elemNumber = 1;
                    break;
                case "fire":
                    elemNumber = 2;
                    break;
                case "water":
                    elemNumber = 3;
                    break;
            }
        }

        //swap with the sprite library of player
        this.GetComponent<SpriteLibrary>().spriteLibraryAsset = spriteLibraries[elemNumber];
    }

}
