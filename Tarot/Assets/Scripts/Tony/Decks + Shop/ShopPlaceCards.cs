using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPlaceCards : MonoBehaviour
{

    [SerializeField] Shop manager;

    public void CustomStart()
    {
        ShopCardScriptReference cardReference = manager.cardPrefab.GetComponent<ShopCardScriptReference>();

        manager.cardPrefab.tag = "Card";

        for (int i = 0; i <5; i++)
        {
            Debug.Log("place");
            manager.cardPrefab.GetComponent<ShopCardScriptReference>().slot = i;
            Debug.Log(manager.cardPrefab.GetComponent<ShopCardScriptReference>().slot + " round " +i);

            ////finally instantiate
            Instantiate(manager.cardPrefab, manager.pos[i].transform.position, manager.pos[i].transform.rotation);
        }

        manager.cardPrefab.tag = "Untagged";
    }

}
