using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

//custom script
//manages counter elements
public class VFXCounter : MonoBehaviour
{
    [SerializeField] EndTurn manager;


    //check if the card would be countered
    public bool check(GameObject c)
    {
        bool isCountered = false; //if not proven otherwise, it is false

        //isCountered = true; //TESTING
        string counterElem, counterElemC;
        bool isplayer = c.GetComponent<CardScriptReference>().isplayer;

        //define counter elemems
        if (isplayer == true)
        {
            counterElem = manager.EElem;
            counterElemC = manager.EElemC;
        }
        else
        {
            counterElem = manager.PElem;
            counterElemC = manager.PElemC;
        }


        //major arcana
        if (manager.isHighP == true)
        {
            counterElem = "nope";
            counterElemC = "nope";
        }


        switch (c.GetComponent<CardScriptReference>().elem)
        {
            case "fire":
               
                    if (counterElem == "water"|| counterElemC == "water")
                    {
                        isCountered = true;
                    }
                break;
          
            case "air":
                if (counterElem == "earth" || counterElemC == "earth")
                {
                    isCountered = true;
                }
                break;
            case "earth":
                if (counterElem == "air" || counterElemC == "air")
                {
                    isCountered = true;
                }
                break;
            case "water":
                if (counterElem == "fire" || counterElemC == "fire")
                {
                    isCountered = true;
                }
                break;

        }
        return isCountered;
    }


    //trigger counter vfx correctly
    public void counter(GameObject card)
    {
        //properties for the vfx
        Vector3 orientation;
        int rotation = 180;
        Texture cardText = card.GetComponent<CardScriptReference>().artWork.texture;

        if (card.GetComponent<CardScriptReference>().isplayer == true)       
            orientation = new Vector3(-30, -5, 5);
       

        else        
            orientation = new Vector3(30, -5, 5);       

        //set the vfx child to active
        card.transform.GetChild(5).gameObject.SetActive(true);

        //set the vfx properties(the chosen values were determined by Denis)
        card.transform.GetChild(5).gameObject.GetComponent<VisualEffect>().SetTexture("CardTexture", cardText);
        card.transform.GetChild(5).gameObject.GetComponent<VisualEffect>().SetVector3("Orientation", orientation);
        card.transform.GetChild(5).gameObject.GetComponent<VisualEffect>().transform.Rotate(0, rotation, 0);

        //make the card under dissapear
        card.GetComponent<SpriteRenderer>().enabled = false;

        //vfx will play
        card.transform.GetChild(5).gameObject.GetComponent<VisualEffect>().enabled = true ;

        //audio
        manager.audioManager.Play("card ripping");
    }
}