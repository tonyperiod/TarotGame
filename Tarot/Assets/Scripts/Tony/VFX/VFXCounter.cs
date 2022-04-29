using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXCounter : MonoBehaviour
{
    [SerializeField] EndTurn manager;



    public bool check(GameObject c)
    {
        bool isCountered = false; //if not proven otherwise, it is false

        //isCountered = true; //TESTIIIIIIIIIIIIIIIING
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
    public void counter(GameObject card)
    {
        Vector3 orientation;
        int rotation;

        Debug.Log("counter activate");
        Texture cardText = card.GetComponent<CardScriptReference>().artWork.texture;
        if (card.GetComponent<CardScriptReference>().isplayer == true)
        {
            orientation = new Vector3(-30, -5, 5);
            rotation = 180;
        }

        else
        {
            orientation = new Vector3(30, -5, 5);
            rotation = 180;
        }

        card.transform.GetChild(5).gameObject.SetActive(true);

        card.transform.GetChild(5).gameObject.GetComponent<VisualEffect>().SetTexture("CardTexture", cardText);
        card.transform.GetChild(5).gameObject.GetComponent<VisualEffect>().SetVector3("Orientation", orientation);
        card.transform.GetChild(5).gameObject.GetComponent<VisualEffect>().transform.Rotate(0, rotation, 0);

        card.GetComponent<SpriteRenderer>().enabled = false;

        card.transform.GetChild(5).gameObject.GetComponent<VisualEffect>().enabled = true ;
    }
}
